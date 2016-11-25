using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class TuKhoaDuongDAO: DataProvider
    {
        public List<TuKhoaDuong> getDsTuKhoaDuong()
        {
            connect();
            string query = "SELECT * FROM TUKHOADUONG";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<TuKhoaDuong> arr = new List<TuKhoaDuong>();
            foreach (Object o in ls)
            {
                arr.Add((TuKhoaDuong)o);
            }
            disconnect();
            return arr;
        }

        public List<TuKhoaTraVe> getTuKhoaMaDuong(string tukhoa)
        {
            try
            {
                connect();

                string query = "SELECT * FROM TUKHOADUONG";
                adapter = new SqlDataAdapter(query, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                ArrayList ls = ConvertDataSetToArrayList(dataset);
                List<TuKhoaTraVe> arr = new List<TuKhoaTraVe>();
                //List<int> dem = new List<int>();

                foreach (Object o in ls)
                {
                    TuKhoaTraVe tk = new TuKhoaTraVe();
                    TuKhoaDuong tt = (TuKhoaDuong)o;
                    ApproximatString A = new ApproximatString(tt.TuKhoaDuong1);
                    int C = A.SoSanh(tukhoa);
                    if (C != -1)
                    {
                        if (arr.Count == 0)
                        {

                            tk.ma = tt.MaDuong;
                            tk.saiso = C;
                            tk.bang = 3;
                            arr.Add(tk);
                        }
                        else
                        {
                            for (int i = 0; i < arr.Count; i++)
                            {
                                if (arr[i].saiso > C)
                                {
                                    tk.ma = tt.MaDuong;
                                    tk.saiso = C;
                                    tk.bang = 3;
                                    if (arr[i].ma != tt.MaDuong)
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
            TuKhoaDuong dl = new TuKhoaDuong();
            dl.MaTuKhoaDuong = (int)dt.Rows[i]["MaTuKhoaDuong"];
            dl.TuKhoaDuong1 = dt.Rows[i]["TuKhoaDuong"].ToString();
            dl.MaDuong = dt.Rows[i].IsNull("MaDuong")? 0 : (int)dt.Rows[i]["MaDuong"];
            return (object)dl;
        }

        public bool insertTuKhoaDuong(TuKhoaDuong dl)
        {
            connect();
            try
            {
                string insertCommand = @"INSERT INTO TUKHOADUONG (TuKhoaDuong, MaDuong)
                                    VALUES (N'" + dl.TuKhoaDuong1 + "'," + dl.MaDuong + ")";

                executeNonQuery(insertCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteTuKhoaDuong(int matukhoa)
        {
            try
            {
                connect();
                string deleteCommand = "DELETE FROM TUKHOADUONG WHERE MaDuLieu = '" + matukhoa + "'";
                executeNonQuery(deleteCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool update_DuLieu(string tentukhoa, int matukhoa)
        {
            try
            {
                connect();
                string deleteCommand = "UPDATE TUKHOADUONG SET TuKhoaDuong = N'" + tentukhoa + "' WHERE MaTuKhoaDuong = " + matukhoa;
                executeNonQuery(deleteCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}