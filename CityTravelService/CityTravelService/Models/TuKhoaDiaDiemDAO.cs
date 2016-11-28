using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class TuKhoaDiaDiemDAO: DataProvider
    {
        public List<TuKhoaDiaDiem> getDsTuKhoaDiaDiem()
        {
            connect();
            string query = "SELECT * FROM TUKHOADIADIEM";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<TuKhoaDiaDiem> arr = new List<TuKhoaDiaDiem>();
            foreach (Object o in ls)
            {
                arr.Add((TuKhoaDiaDiem)o);
            }
            disconnect();
            return arr;
        }

        public List<TuKhoaTraVe> getTuKhoaDiaDiem(string tukhoa)
        {
            try
            {
                connect();

                string query = "SELECT * FROM TUKHOADIADIEM";
                adapter = new SqlDataAdapter(query, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                ArrayList ls = ConvertDataSetToArrayList(dataset);
                List<TuKhoaTraVe> arr = new List<TuKhoaTraVe>();
                //List<int> dem = new List<int>();

                foreach (Object o in ls)
                {
                    TuKhoaTraVe tk = new TuKhoaTraVe();
                    TuKhoaDiaDiem tt = (TuKhoaDiaDiem)o;
                    ApproximatString A = new ApproximatString(tt.TuKhoaTenDiaDiem);
                    int C = A.SoSanh(tukhoa);
                    if (C != -1)
                    {
                        if (arr.Count == 0)
                        {

                            tk.ma = tt.MaTenDiaDiem;
                            tk.saiso = C;
                            tk.bang = 2;
                            arr.Add(tk);
                        }
                        else
                        {
                            for (int i = 0; i < arr.Count; i++)
                            {
                                if (arr[i].saiso > C)
                                {
                                    tk.ma = tt.MaTenDiaDiem;
                                    tk.saiso = C;
                                    tk.bang = 2;
                                    if (arr[i].ma != tt.MaTenDiaDiem)
                                    {
                                        arr.Insert(i, tk);
                                    }
                                    else
                                    {
                                        arr[i] = tk;
                                    }
                                    i = arr.Count;
                                }
                            }
                        }
                    }
                }
                disconnect();
                return arr;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            TuKhoaDiaDiem tk = new TuKhoaDiaDiem();
            tk.MaTuKhoaTenDiaDiem = dt.Rows[i].IsNull("MaTuKhoaTenDiaDiem") == true ? 0 : (int)dt.Rows[i]["MaTuKhoaTenDiaDiem"];
            tk.TuKhoaTenDiaDiem = dt.Rows[i]["TuKhoaTenDiaDiem"].ToString();
            tk.MaTenDiaDiem = dt.Rows[i].IsNull("MaTenDiaDiem") == true ? 0 : (int)dt.Rows[i]["MaTenDiaDiem"];

            return (object)tk;
        }

        public bool updateTuKhoaDiaDiem(TuKhoaDiaDiem tk)
        {
            try
            {
                connect();
                string updateCommand = "UPDATE TUKHOADIADIEM SET TuKhoaTenDiaDiem = '" + tk.TuKhoaTenDiaDiem +
                    "', MaTenDiaDiem = " + tk.MaTenDiaDiem + " WHERE MaTuKhoaTenDiaDiem = " + tk.MaTuKhoaTenDiaDiem;
                executeNonQuery(updateCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void deleteTuKhoaDiaDiem(int id)
        {
            connect();
            string deleteCommand = "DELETE FROM TUKHOADIADIEM WHERE MaTuKhoaTenDiaDiem = " + id;
            executeNonQuery(deleteCommand);
            disconnect();
        }

        public void deleteTuKhoaDiaDiemByMaDiaDiem(int maDD)
        {
            connect();
            string deleteCommand = "DELETE FROM TUKHOADIADIEM WHERE MaDiaDiem = " + maDD;
            executeNonQuery(deleteCommand);
            disconnect();
        }

    }
}