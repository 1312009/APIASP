using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class TuKhoaTinhThanhDAO: DataProvider
    {
        public List<TuKhoaTinhThanh> getDsTuKhoaTinhThanh()
        {
            connect();
            string query = "SELECT * FROM TUKHOATINHTHANH";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<TuKhoaTinhThanh> arr = new List<TuKhoaTinhThanh>();
            foreach (Object o in ls)
            {
                arr.Add((TuKhoaTinhThanh)o);
            }
            disconnect();
            return arr;
        }

        public List<TuKhoaTraVe> getTuKhoaTinhThanh(string tukhoa)
        {
            try
            {
                connect();
                
                string query = "SELECT * FROM TUKHOATINHTHANH";
                adapter = new SqlDataAdapter(query, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                ArrayList ls = ConvertDataSetToArrayList(dataset);
                List<TuKhoaTraVe> arr = new List<TuKhoaTraVe>();
                //List<int> dem = new List<int>();

                foreach (Object o in ls)
                {
                    TuKhoaTraVe tk = new TuKhoaTraVe();
                    TuKhoaTinhThanh tt = (TuKhoaTinhThanh)o;
                    ApproximatString A = new ApproximatString(tt.TuKhoaTinhThanh1);
                    int C = A.SoSanh(tukhoa);
                    if (C != -1)
                    {
                        if (arr.Count == 0)
                        {

                            tk.ma =tt.MaTinhThanh;
                            tk.saiso = C;
                            tk.bang = 6;
                            arr.Add(tk);
                        }
                        else
                        {
                            for (int i = 0; i < arr.Count; i++)
                            {
                                if (arr[i].saiso > C)
                                {
                                    tk.ma = tt.MaTinhThanh;
                                    tk.saiso = C;
                                    tk.bang = 6;
                                    if (arr[i].ma != tt.MaTinhThanh)
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
            TuKhoaTinhThanh tk = new TuKhoaTinhThanh();
            tk.MaTuKhoaTinhThanh = dt.Rows[i].IsNull("MaTuKhoaTinhThanh") == true ? 0 : (int)dt.Rows[i]["MaTuKhoaTinhThanh"];
            tk.TuKhoaTinhThanh1 = dt.Rows[i]["TuKhoaTinhThanh"].ToString();
            tk.MaTinhThanh = dt.Rows[i].IsNull("MaTinhThanh") == true ? 0 : (int)dt.Rows[i]["MaTinhThanh"];

            return (object)tk;
        }

        public bool updateTuKhoaTinhThanh(TuKhoaTinhThanh tk)
        {
            try
            {
                connect();
                string updateCommand = "UPDATE TUKHOATINHTHANH SET TuKhoaTinhThanh = '" + tk.TuKhoaTinhThanh1 +
                    "', MaTinhThanh = " + tk.MaTinhThanh + " WHERE MaTuKhoaTinhThanh = " + tk.MaTuKhoaTinhThanh;
                executeNonQuery(updateCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void deleteTuKhoaTinhThanh(int id)
        {
            connect();
            string deleteCommand = "DELETE FROM TUKHOATINHTHANH WHERE MaTuKhoaTinhThanh = " + id;
            executeNonQuery(deleteCommand);
            disconnect();
        }

    }
}