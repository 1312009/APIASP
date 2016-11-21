using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class DanhGiaDAO : DataProvider
    {
        public List<DanhGia> getDsDanhGia()
        {
            connect();
            string query = "SELECT * FROM DANHGIA";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<DanhGia> arr = new List<DanhGia>();
            foreach (Object o in ls)
            {
                arr.Add((DanhGia)o);
            }
            disconnect();
            return arr;
        }

        public List<DanhGia> getDsDanhGia(int id)
        {
            connect();
            string query = "SELECT * FROM DANHGIA WHERE MaTenDiaDiem = " + id;
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<DanhGia> arr = new List<DanhGia>();
            foreach (Object o in ls)
            {
                arr.Add((DanhGia)o);
            }

            disconnect();
            return arr;
        }

        public List<DanhGia> getDanhGia(string email, int id)
        {
            connect();
            string query = "SELECT * FROM DANHGIA WHERE Email = '" + email + "' AND MaTenDiaDiem = " + id;
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<DanhGia> arr = new List<DanhGia>();
            foreach (Object o in ls)
            {
                arr.Add((DanhGia)o);
            }

            disconnect();
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            DanhGia dg = new DanhGia();
            dg.Email = dt.Rows[i]["Email"].ToString();
            dg.IDAddress = (int)dt.Rows[i]["MaTenDiaDiem"];
            dg.Rate = (dt.Rows[i].IsNull("DanhGia") == true) ? 0.0f : (float)(double)dt.Rows[i]["DanhGia"];

            return (object)dg;
        }

        public bool insertDanhGia(DanhGia dg)
        {
            try
            {
                connect();
                string insertCommand = "INSERT INTO DANHGIA (Email, MaTenDiaDiem, DanhGia) VALUES('"
                    + dg.Email + "', " + dg.IDAddress + ", " + dg.Rate + ")";
                executeNonQuery(insertCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool updateDanhGia(DanhGia dg)
        {
            try
            {
                connect();
                string updateCommand = "UPDATE DANHGIA SET DanhGia = " + dg.Rate +
                    " WHERE Email = '" + dg.Email + "' AND MaTenDiaDiem = " + dg.IDAddress;
                executeNonQuery(updateCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void deleteDanhGia(string email, int id)
        {
            connect();
            string deleteCommand = "DELETE FROM DANHGIA WHERE Email = '" + email + "' AND MaTenDiaDiem = " + id;
            executeNonQuery(deleteCommand);
            disconnect();
        }
    }
}