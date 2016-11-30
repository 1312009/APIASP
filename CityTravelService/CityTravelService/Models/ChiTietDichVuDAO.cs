using CityTravelService.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class ChiTietDichVuDAO : DataProvider
    {

        public List<ChiTietDichVu> get_All_ChiTiet_DichVu()
        {
            connect();
            string query = @"select * from CHITIET_DULIEU";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<ChiTietDichVu> arr = new List<ChiTietDichVu>();
            foreach (Object o in ls)
            {
                arr.Add((ChiTietDichVu)o);
            }
            return arr;
        }
        public List<ChiTietDichVu> get_ChiTiet_DichVu(int ma_dulieu)
        {
            connect();
            string query = string.Format("select * where MaDuLieu = {0}", ma_dulieu);
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<ChiTietDichVu> arr = new List<ChiTietDichVu>();
            foreach (Object o in ls)
            {
                arr.Add((ChiTietDichVu)o);
            }
            return arr;
        }

        public bool insert_ChiTiet_DichVu(ChiTietDichVu dichvu)
        {
            connect();
            try
            {
                string insertCommand = string.Format(" insert into CHITIET_DULIEU(MaDuLieu, MaChiTiet) values ({0},{1})", dichvu.ma_dulieu, dichvu.ma_chitiet);

                executeNonQuery(insertCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool delete_ChiTiet_DichVu(ChiTietDichVu dv)
        {
            try
            {
                connect();
                string deleteCommand = string.Format("DELETE FROM CHITIET_DULIEU WHERE MaDuLieu = {0} and MaChiTiet = {1}", dv.ma_dulieu, dv.ma_chitiet);
                executeNonQuery(deleteCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool update_ChiTiet_DichVu(ChiTietDichVu dv)
        {
            try
            {
                connect();
                string deleteCommand = string.Format("UPDATE CHITIET_DULIEU SET MaChiTiet = {0} WHERE MaDuLieu = {1}", dv.ma_chitiet, dv.ma_dulieu);
                executeNonQuery(deleteCommand);
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
            ChiTietDichVu chitiet_dulieu = new ChiTietDichVu();
            chitiet_dulieu.ma_dulieu = (int)dt.Rows[i]["MaDuLieu"];
            chitiet_dulieu.ma_chitiet = (int)dt.Rows[i]["MaChiTiet"];
            return (object)chitiet_dulieu;
        }
        


    }
}