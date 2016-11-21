using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CityTravelService.Models
{
    public class DichVuDAO : DataProvider
    {
        public List<DichVu> getDsDichVu()
        {
            connect();
            string query = "SELECT * FROM DICHVU";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<DichVu> arr = new List<DichVu>();
            foreach(Object o in ls) {
                arr.Add((DichVu)o);
            }
            disconnect();
            return arr;
        }

        public List<DichVu> getDsDichVu(int id)
        {
            connect();
            string query = "SELECT * FROM DICHVU WHERE MaDichVu = " + id;
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<DichVu> arr = new List<DichVu>();
            foreach (Object o in ls)
            {
                arr.Add((DichVu)o);
            }

            disconnect();
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            DichVu dv = new DichVu();
            dv.ID = (int)dt.Rows[i]["MaDichVu"];
            dv.Name = dt.Rows[i]["TenDichVu"].ToString();
            dv.Picture = dt.Rows[i]["Hinh"].ToString();

            return (object)dv;
        }

        public void insertDichVu(DichVu dv)
        {
            connect();
            string insertCommand = "INSERT INTO DICHVU (TenDichVu, Hinh) VALUES('" + dv.Name + "', '" + dv.Picture + "')";
            executeNonQuery(insertCommand);
            disconnect();
        }

        public void updateDichVu(DichVu dv)
        {
            connect();
            string updateCommand = "UPDATE DICHVU SET TenDichVu = '" + dv.Name +
                "', Hinh = '" + dv.Picture +  "' WHERE MaDichVu = " + dv.ID;
            executeNonQuery(updateCommand);
            disconnect();
        }

        public void deleteDichVu(int id)
        {
            connect();
            string deleteCommand = "DELETE FROM DICHVU WHERE MaDichVu = " + id;
            executeNonQuery(deleteCommand);
            disconnect();
        }
    }
}