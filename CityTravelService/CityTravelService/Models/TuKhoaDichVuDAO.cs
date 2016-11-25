using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CityTravelService.Models
{
    public class TuKhoaDichVuDAO : DataProvider
    {
        public List<TuKhoaDichVu> getDsTuKhoaDichVu()
        {
            connect();
            string query = "SELECT * FROM TUKHOADICHVU";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<TuKhoaDichVu> arr = new List<TuKhoaDichVu>();
            foreach (Object o in ls)
            {
                arr.Add((TuKhoaDichVu)o);
            }
            disconnect();
            return arr;
        }

        public List<TuKhoaDichVu> getDsTuKhoaDichVu(int id)
        {
            connect();
            string query = string.Format("SELECT * FROM TUKHOADICHVU WHERE [MaTuKhoaDichVu]= '{0}'", id);
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<TuKhoaDichVu> arr = new List<TuKhoaDichVu>();
            foreach (Object o in ls)
            {
                arr.Add((TuKhoaDichVu)o);
            }

            disconnect();
            return arr;
        }

        public List<TuKhoaTraVe> getTuKhoaDichVu(string tukhoa)
        {
            try
            {
                connect();

                string query = "SELECT * FROM TUKHOADICHVU";
                adapter = new SqlDataAdapter(query, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                ArrayList ls = ConvertDataSetToArrayList(dataset);
                List<TuKhoaTraVe> arr = new List<TuKhoaTraVe>();
                //List<int> dem = new List<int>();

                foreach (Object o in ls)
                {
                    TuKhoaDichVu tt = (TuKhoaDichVu)o;
                    TuKhoaTraVe dv = new TuKhoaTraVe();
                    ApproximatString A = new ApproximatString(tt.TenTuKhoaDichVu);
                    int C = A.SoSanh(tukhoa);
                    if (C != -1)
                    {
                        if (arr.Count == 0)
                        {
                            dv.ma = tt.MaDichVu;
                            dv.saiso = C;
                            dv.bang = 1;
                            arr.Add(dv);
                        }
                        else
                        {
                            for (int i = 0; i < arr.Count; i++)
                            {
                                if (arr[i].saiso > C)
                                {
                                    dv.ma = tt.MaDichVu;
                                    dv.saiso = C;
                                    dv.bang = 1;
     
                                    if (arr[i].ma != dv.ma) arr.Insert(i, dv);
                                    else arr[i] = dv;
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
            TuKhoaDichVu tkdv = new TuKhoaDichVu();
            tkdv.MaTuKhoaDichVu = (int)dt.Rows[i]["MaTuKhoaDichVu"];
            tkdv.TenTuKhoaDichVu = dt.Rows[i]["TenTuKhoaDichVu"].ToString();
            tkdv.MaDichVu = (int)dt.Rows[i]["MaDichVu"];

            return (object)tkdv;
        }

        public bool insertTuKhoaDichVu(TuKhoaDichVu bl)
        {
            try
            {
                connect();
                string insertCommand = "INSERT INTO TUKHOADICHVU VALUES(N'" +
                    bl.TenTuKhoaDichVu + "', '" +
                    bl.MaDichVu + "')";
                executeNonQuery(insertCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool updateTuKhoaDichVu(TuKhoaDichVu tkdv)
        {
            try
            {
                connect();

                string updateCommand = string.Format("UPDATE TUKHOADICHVU SET TenTuKhoaDichVu = N'" + tkdv.TenTuKhoaDichVu +
                    "' WHERE MaTuKhoaDichVu = " + tkdv.MaTuKhoaDichVu);

                executeNonQuery(updateCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool deleteTuKhoaDichVu(int id)
        {
            try
            {
                connect();
                string deleteCommand = string.Format("DELETE FROM TUKHOADICHVU WHERE [MaTuKhoaDichVu]= '{0}'", id);
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