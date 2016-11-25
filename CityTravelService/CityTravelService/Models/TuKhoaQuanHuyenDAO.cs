using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class TuKhoaQuanHuyenDAO: DataProvider
    {
        public List<TuKhoaQuanHuyen> getDsTuKhoaQuanHuyen()
        {
            connect();
            string query = "SELECT * FROM TUKHOAQUANHUYEN";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<TuKhoaQuanHuyen> arr = new List<TuKhoaQuanHuyen>();
            foreach (Object o in ls)
            {
                arr.Add((TuKhoaQuanHuyen)o);
            }
            disconnect();
            return arr;
        }

        public List<TuKhoaTraVe> getTuKhoaQuanHuyen(string tukhoa)
        {
            try
            {
                connect();

                string query = "SELECT * FROM TUKHOAQUANHUYEN";
                adapter = new SqlDataAdapter(query, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                ArrayList ls = ConvertDataSetToArrayList(dataset);
                List<TuKhoaTraVe> arr = new List<TuKhoaTraVe>();
                //List<int> dem = new List<int>();

                foreach (Object o in ls)
                {
                    TuKhoaTraVe tk = new TuKhoaTraVe();
                    TuKhoaQuanHuyen tt = (TuKhoaQuanHuyen)o;
                    ApproximatString A = new ApproximatString(tt.TuKhoaQuanHuyen1);
                    int C = A.SoSanh(tukhoa);
                    if (C != -1)
                    {
                        if (arr.Count == 0)
                        {

                            tk.ma = tt.MaQuanHuyen;
                            tk.saiso = C;
                            tk.bang = 5;
                            arr.Add(tk);
                        }
                        else
                        {
                            for (int i = 0; i < arr.Count; i++)
                            {
                                if (arr[i].saiso > C)
                                {
                                    tk.ma = tt.MaQuanHuyen;
                                    tk.saiso = C;
                                    tk.bang = 5;
                                    if (arr[i].ma != tt.MaQuanHuyen)
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
            TuKhoaQuanHuyen tk = new TuKhoaQuanHuyen();
            tk.MaTuKhoaQuanHuyen = dt.Rows[i].IsNull("MaTuKhoaQuanHuyen") == true ? 0 : (int)dt.Rows[i]["MaTuKhoaQuanHuyen"];
            tk.TuKhoaQuanHuyen1 = dt.Rows[i]["TuKhoaQuanHuyen"].ToString();
            tk.MaQuanHuyen = dt.Rows[i].IsNull("MaQuanHuyen") == true ? 0 : (int)dt.Rows[i]["MaQuanHuyen"];

            return (object)tk;
        }

        public bool updateTuKhoaQuanHuyen(TuKhoaQuanHuyen tk)
        {
            try
            {
                connect();
                string updateCommand = "UPDATE TUKHOAQUANHUYEN SET TuKhoaQuanHuyen = '" + tk.TuKhoaQuanHuyen1 +
                    "', MaQuanHuyen = " + tk.MaQuanHuyen + " WHERE MaTuKhoaQuanHuyen = " + tk.MaTuKhoaQuanHuyen;
                executeNonQuery(updateCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void deleteTuKhoaQuanHuyen(int id)
        {
            connect();
            string deleteCommand = "DELETE FROM TUKHOAQUANHUYEN WHERE MaTuKhoaQuanHuyen = " + id;
            executeNonQuery(deleteCommand);
            disconnect();
        }

    }
}