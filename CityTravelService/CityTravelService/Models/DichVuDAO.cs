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
            string query = "SELECT* FROM TENDIADIEM JOIN DULIEU ON TENDIADIEM.MaTenDiaDiem = DULIEU.MaTenDiaDiem JOIN DUONG ON DUONG.MaDuong = DULIEU.MaDuong JOIN PHUONG ON PHUONG.MaPhuong = DULIEU.MaPhuong JOIN QUANHUYEN ON QUANHUYEN.MaQuanHuyen = DULIEU.MaQuanHuyen JOIN TINHTHANH ON TINHTHANH.MaTinhThanh = DULIEU.MaTinhThanh JOIN DICHVU ON DICHVU.MaDichVu = DULIEU.MaDichVu";
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
            string query = "SELECT* FROM TENDIADIEM JOIN DULIEU ON TENDIADIEM.MaTenDiaDiem = DULIEU.MaTenDiaDiem JOIN DUONG ON DUONG.MaDuong = DULIEU.MaDuong JOIN PHUONG ON PHUONG.MaPhuong = DULIEU.MaPhuong JOIN QUANHUYEN ON QUANHUYEN.MaQuanHuyen = DULIEU.MaQuanHuyen JOIN TINHTHANH ON TINHTHANH.MaTinhThanh = DULIEU.MaTinhThanh JOIN DICHVU ON DICHVU.MaDichVu = DULIEU.MaDichVu WHERE DICHVU.MaDichVu = " + id;
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
            DichVu dd = new DichVu();
            dd.ID = (int)dt.Rows[i]["MaDichVu"];
            dd.Name = dt.Rows[i]["TenDichVu"].ToString();
            dd.Hinh = dt.Rows[i]["Hinh"].ToString();

            dd.dulieu.MaDuLieu = dt.Rows[i].IsNull("MaDuLieu") ? 0 : (int)dt.Rows[i]["MaDuLieu"];
            dd.dulieu.MaDichVu = dt.Rows[i].IsNull("MaDichVu") ? 0 : (int)dt.Rows[i]["MaDichVu"];
            dd.dulieu.MaTenDiaDiem = dt.Rows[i].IsNull("MaTenDiaDiem") ? 0 : (int)dt.Rows[i]["MaTenDiaDiem"];
            dd.dulieu.SoNha = dt.Rows[i]["SoNha"].ToString();
            dd.dulieu.MaDuong = dt.Rows[i].IsNull("MaDuong") ? 0 : (int)dt.Rows[i]["MaDuong"];
            dd.dulieu.MaPhuong = dt.Rows[i].IsNull("MaPhuong") ? 0 : (int)dt.Rows[i]["MaPhuong"];
            dd.dulieu.MaQuanHuyen = dt.Rows[i].IsNull("MaQuanHuyen") ? 0 : (int)dt.Rows[i]["MaQuanHuyen"];
            dd.dulieu.MaTinhThanh = dt.Rows[i].IsNull("MaTinhThanh") ? 0 : (int)dt.Rows[i]["MaTinhThanh"];
            dd.dulieu.KinhDo = dt.Rows[i].IsNull("KinhDo") ? 0.0f : (double)dt.Rows[i]["KinhDo"];
            dd.dulieu.ViDo = dt.Rows[i].IsNull("ViDo") ? 0.0f : (double)dt.Rows[i]["ViDo"];
            dd.dulieu.ChuThich = dt.Rows[i]["ChuThich"].ToString();
            dd.dulieu.DanhGia = dt.Rows[i].IsNull("DanhGia") ? 0 : (int)dt.Rows[i]["DanhGia"];

            return (object)dd;
        }

        public bool insertDichVu(DichVu dd)
        {
            try
            {
                connect();
                string insertCommand = "INSERT INTO DICHVU VALUES(N'" +
                    dd.Name + "', '" +
                    dd.Hinh + "')";
                executeNonQuery(insertCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool updateDichVu(DichVu dd)
        {
            try
            {
                connect();
                //string updateCommand = "UPDATE DICHVU SET TenDichVu = N'" + dd.Name +
                //    "', Hinh = '" + dd.Hinh + "' WHERE MaDichVu = " + dd.ID;

                string updateCommand = string.Format("UPDATE DICHVU SET TenDichVu = N'" + dd.Name +
                    "', Hinh = '" + dd.Hinh + "' WHERE MaDichVu = " + dd.ID);

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