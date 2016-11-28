using CityTravelService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CityTravelServer.Models
{
    public class BinhLuanDAO : DataProvider
    {
        public List<BinhLuan> getDsBinhLuan()
        {
            connect();
            string query = "SELECT * FROM BINHLUAN";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<BinhLuan> arr = new List<BinhLuan>();
            foreach (Object o in ls)
            {
                arr.Add((BinhLuan)o);
            }
            disconnect();
            return arr;
        }

        public List<BinhLuan> getDsBinhLuan(string id)
        {
            connect();
            string query = "SELECT * FROM BINHLUAN WHERE MaBinhLuan = '" + id + "'";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<BinhLuan> arr = new List<BinhLuan>();
            foreach (Object o in ls)
            {
                arr.Add((BinhLuan)o);
            }

            disconnect();
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            BinhLuan bl = new BinhLuan();
            bl.MaBinhLuan = dt.Rows[i]["MaBinhLuan"].ToString();
            bl.Email = dt.Rows[i]["Email"].ToString();
            bl.NoiDung = dt.Rows[i]["NoiDung"].ToString();
            bl.ThoiGian = (DateTime)dt.Rows[i]["ThoiGian"];
            bl.MaDuLieu = (int)dt.Rows[i]["MaDuLieu"];
            bl.TrangThai = (int)dt.Rows[i]["TrangThai"];

            return (object)bl;
        }

        public bool insertBinhLuan(BinhLuan bl)
        {
            try
            {
                connect();
                string insertCommand = "INSERT INTO BINHLUAN VALUES(" +
                    bl.MaDuLieu + ", '" +
                    bl.MaBinhLuan + "', '" +
                    bl.Email + "', N'" +
                    bl.NoiDung + "', '" +
                    bl.ThoiGian.Year + "-" + bl.ThoiGian.Month + "-" + bl.ThoiGian.Day + " " + bl.ThoiGian.Hour + ":" + bl.ThoiGian.Minute + ":" + bl.ThoiGian.Second + "'," +
                    bl.TrangThai + ")";
                executeNonQuery(insertCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool updateBinhLuan(string mabinhluan)
        {
            try
            {
                connect();

                string updateCommand = string.Format("UPDATE BINHLUAN SET TrangThai = 1 WHERE MaBinhLuan = '" + mabinhluan + "'");

                executeNonQuery(updateCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool deleteBinhLuan(string id)
        {
            try
            {
                connect();
                string deleteCommand = "DELETE FROM BINHLUAN WHERE MaBinhLuan = '" + id + "'";
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