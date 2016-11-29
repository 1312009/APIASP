using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
            dv.Hinh = dt.Rows[i]["Hinh"].ToString();

            return (object)dv;
        }

        public bool insertDichVu(DichVu dv)
        {
            try
            {
                connect();
                string insertCommand = "INSERT INTO DICHVU VALUES(N'" +
                    dv.Name + "', '" +
                    dv.Hinh + "')";
                executeNonQuery(insertCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool updateDichVu(DichVu dv)
        {
            try
            {
                connect();
                //string updateCommand = "UPDATE DICHVU SET TenDichVu = N'" + dv.Name +
                //    "', Hinh = '" + dv.Hinh + "' WHERE MaDichVu = " + dv.ID;

                string updateCommand = string.Format("UPDATE DICHVU SET TenDichVu = N'" + dv.Name +
                    "', Hinh = '" + dv.Hinh + "' WHERE MaDichVu = " + dv.ID);

                executeNonQuery(updateCommand);
                disconnect();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteDichVu(int id)
        {
            try
            {
                connect();
                //string deleteCommand = "DELETE FROM DICHVU WHERE MaDichVu=" + id;
                string deleteCommand = string.Format("DELETE FROM DICHVU WHERE [MaDichVu]= '{0}'", id);
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