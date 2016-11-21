using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CityTravelService.Entity;

namespace CityTravelService.Models
{
    public class DiaDiemDAO : DataProvider
    {

        public bool insertDiaDiem(TENDIADIEM tenDD)
        {
            try {
                connect();
                string insertCommand = "INSERT INTO TENDIADIEM VALUES( N'" +
                    tenDD.TenDiaDiem + "')";
                executeNonQuery(insertCommand);
                disconnect();
                return true;
            }catch(Exception e) {
                return false;
            }
            
        }

        public bool updateDiaDiem(int matenDiaDiem, string TenDiaDiemMoi)
        {
            try
            {
                connect();
                string updatecommand = "update TENDIADIEM set TenDiaDiem = " + " N'"
                                        + TenDiaDiemMoi + "' where MaTenDiaDiem = " + matenDiaDiem;
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
            TENDIADIEM tenDD = new TENDIADIEM();
            tenDD.MaTenDiaDiem = (int)dt.Rows[i]["MaTenDiaDiem"];
            tenDD.TenDiaDiem = dt.Rows[i]["TenDiaDiem"].ToString();
            return (object)tenDD;
        }

        public List<TENDIADIEM> getAllDiaDiem()
        {
                connect();
                string query = "select * from TENDIADIEM";
                adapter = new SqlDataAdapter(query, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                ArrayList ls = ConvertDataSetToArrayList(dataset);
                List<TENDIADIEM> listDD = new List<TENDIADIEM>();
                foreach (Object o in ls)
                {
                    listDD.Add((TENDIADIEM)o);
                }
                disconnect();
                return listDD;
            
        }

        public TENDIADIEM getDiaDiem(int matendiadiem)
        {
            connect();
            string query = "SELECT * FROM MaTenDiaDiem = " + matendiadiem;
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<TENDIADIEM> arr = new List<TENDIADIEM>();
            foreach (Object o in ls)
            {
                arr.Add((TENDIADIEM)o);
            }
            TENDIADIEM dt = arr[0];
            return dt;
        }

        public bool DeleteDiaDiem(int id, string tendiadiem)
        {
            try
            {
                connect();
                DULIEU_DAO dlDao = new DULIEU_DAO();
                List<DULIEU> arr = new List<DULIEU>();
                arr = dlDao.getDuLieu(id);
                foreach (DULIEU i in arr)
                {
                    dlDao.delete_DuLieu(i.MaDuLieu);
                }
                string deleteCommand = "DELETE FROM TENDIADIEM WHERE TenDiaDiem = N'" + tendiadiem + "'";
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