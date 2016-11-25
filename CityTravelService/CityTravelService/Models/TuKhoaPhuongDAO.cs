using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class TuKhoaPhuongDAO: DataProvider
    {
        public List<TuKhoaPhuong> getDsTuKhoaPhuong()
        {
            connect();
            string query = "select * from TUKHOAPHUONG";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<TuKhoaPhuong> listDD = new List<TuKhoaPhuong>();
            foreach (Object o in ls)
            {
                listDD.Add((TuKhoaPhuong)o);
            }
            disconnect();
            return listDD;
        }

        public List<TuKhoaTraVe> getTuKhoaPhuong(string tukhoa)
        {
            try
            {
                connect();

                string query = "SELECT * FROM TUKHOAPHUONG";
                adapter = new SqlDataAdapter(query, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                ArrayList ls = ConvertDataSetToArrayList(dataset);
                List<TuKhoaTraVe> arr = new List<TuKhoaTraVe>();
                //List<int> dem = new List<int>();

                foreach (Object o in ls)
                {
                    TuKhoaTraVe tk = new TuKhoaTraVe();
                    TuKhoaPhuong tt = (TuKhoaPhuong)o;
                    ApproximatString A = new ApproximatString(tt.TuKhoaPhuong1);
                    int C = A.SoSanh(tukhoa);
                    if (C != -1)
                    {
                        if (arr.Count == 0)
                        {

                            tk.ma = tt.MaPhuong;
                            tk.saiso = C;
                            tk.bang = 4;
                            arr.Add(tk);
                        }
                        else
                        {
                            for (int i = 0; i < arr.Count; i++)
                            {
                                if (arr[i].saiso > C)
                                {
                                    tk.ma = tt.MaPhuong;
                                    tk.saiso = C;
                                    tk.bang = 4;
                                    if (arr[i].ma != tt.MaPhuong)
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
        public bool insertTuKhoaPhuong(TuKhoaPhuong tkp)
        {
            try
            {
                connect();
                string insertCommand = "INSERT INTO TUKHOAPHUONG VALUES( N'" +
                    tkp.TuKhoaPhuong1 + "'," + tkp.MaPhuong + ")";
                executeNonQuery(insertCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool updateTuKhoaPhuong(int matukhoaphuong, string tukhoaphuong)
        {
            try
            {
                connect();
                string updatecommand = "update TUKHOAPHUONG set TuKhoaPhuong = " + " N'"
                                        + tukhoaphuong + "' where MaTuKhoaPhuong = " + matukhoaphuong;
                executeNonQuery(updatecommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteTuKhoaPhuong(int id)
        {
            try
            {
                connect();
                string updatecommand = "DELETE FROM TUKHOAPHUONG WHERE MaTuKhoaPhuong = " + id;
                executeNonQuery(updatecommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            TuKhoaPhuong tkp = new TuKhoaPhuong();
            tkp.MaTuKhoaPhuong = (int)dt.Rows[i]["MaTuKhoaPhuong"];
            tkp.TuKhoaPhuong1 = dt.Rows[i]["TuKhoaPhuong"].ToString();
            tkp.MaPhuong = (int)dt.Rows[i]["MaPhuong"];
            return (object)tkp;
        }
    }
}