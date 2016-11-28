using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace CityTravelService.Models
{
    public class TenDiaDiemDAO : DataProvider
    {

        public bool insertTenDiaDiem(TenDiaDiem tenDD)
        {
            try
            {
                connect();
                string insertCommand = "INSERT INTO TENDIADIEM VALUES( N'" +
                    tenDD.TenDiaDiem1 + "')";
                executeNonQuery(insertCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool updateTenDiaDiem(int matenDiaDiem, string TenDiaDiemMoi)
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
            TenDiaDiem tenDD = new TenDiaDiem();
            tenDD.MaTenDiaDiem = (int)dt.Rows[i]["MaTenDiaDiem"];
            tenDD.TenDiaDiem1 = dt.Rows[i]["TenDiaDiem"].ToString();
            return (object)tenDD;
        }

        public List<TenDiaDiem> getAllTenDiaDiem()
        {
            connect();
            string query = "select * from TENDIADIEM";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<TenDiaDiem> listDD = new List<TenDiaDiem>();
            foreach (Object o in ls)
            {
                listDD.Add((TenDiaDiem)o);
            }
            disconnect();
            return listDD;

        }

        public TenDiaDiem getTenDiaDiem(int matendiadiem)
        {
            connect();
            string query = "SELECT * FROM MaTenDiaDiem = " + matendiadiem;
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<TenDiaDiem> arr = new List<TenDiaDiem>();
            foreach (Object o in ls)
            {
                arr.Add((TenDiaDiem)o);
            }
            TenDiaDiem dt = arr[0];
            return dt;
        }

        public bool DeleteTenDiaDiem(int id, string tendiadiem)
        {
            try
            {
                connect();
                DuLieuDAO dlDao = new DuLieuDAO();
                TuKhoaDiaDiemDAO tkddDao = new TuKhoaDiaDiemDAO();
                List<DuLieu> arr = new List<DuLieu>();
                arr = dlDao.getDuLieu(id);
                foreach (DuLieu i in arr)
                {
                    dlDao.delete_DuLieu(i.MaDuLieu);
                }
                tkddDao.deleteTuKhoaDiaDiemByMaDiaDiem(id);
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