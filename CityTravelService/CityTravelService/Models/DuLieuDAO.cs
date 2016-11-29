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
    public class DuLieuDAO : DataProvider
    {
        public List<DuLieu> get_Ds_DuLieu()
        {
            connect();
            string query = "SELECT * FROM DULIEU";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<DuLieu> arr = new List<DuLieu>();
            foreach (Object o in ls)
            {
                arr.Add((DuLieu)o);
            }
            disconnect();
            return arr;
        }

        public List<DuLieu> getDuLieu(int MaTenDiaDiem)
        {
            connect();
            string query = "SELECT * FROM DULIEU WHERE MaTenDiaDiem = " + MaTenDiaDiem;
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<DuLieu> arr = new List<DuLieu>();
            foreach (Object o in ls)
            {
                arr.Add((DuLieu)o);
            }
            return arr;
        }

        public List<DuLieu> get_DuLieu(int ma_dulieu)
        {
            connect();
            string query = "SELECT * FROM DULIEU where MaDuLieu = " + ma_dulieu;
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<DuLieu> arr = new List<DuLieu>();
            foreach (Object o in ls)
            {
                arr.Add((DuLieu)o);
            }
            return arr;
        }
        
        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            int danhgia = 0;
            string mabinhluan = "";
            DuLieu dl = new DuLieu();
            dl.MaDuLieu = (int)dt.Rows[i]["MaDuLieu"];
            dl.MaDichVu = (int)dt.Rows[i]["MaDichVu"];
            dl.MaTenDiaDiem = (int)dt.Rows[i]["MaTenDiaDiem"];
            dl.SoNha = dt.Rows[i]["SoNha"].ToString().Trim();
            dl.MaDuong = (int)dt.Rows[i]["MaDuong"];
            dl.MaPhuong = (int)dt.Rows[i]["MaPhuong"];
            dl.MaQuanHuyen = (int)dt.Rows[i]["MaQuanHuyen"];
            dl.MaTinhThanh = (int)dt.Rows[i]["MaTinhThanh"];
            dl.KinhDo = (double)dt.Rows[i]["KinhDo"];
            dl.ViDo = (double)dt.Rows[i]["ViDo"];
            dl.ChuThich = dt.Rows[i]["ChuThich"].ToString().Trim();
            danhgia = dl.DanhGia == null ? 0 : (int)dl.DanhGia;
            dl.DanhGia = danhgia;
            mabinhluan = dl.MaBinhLuan == null ? "" : dl.MaBinhLuan;
            dl.MaBinhLuan = mabinhluan;

            return (object)dl;
        }

        public bool insert_DuLieu(DuLieu dl)
        {
            connect();
            try
            {
                string insertCommand = @"INSERT INTO DULIEU (MaDichVu, MaTenDiaDiem, SoNha, MaDuong, MaPhuong, MaQuanHuyen, MaTinhThanh, KinhDo, ViDo, ChuThich)
                                    VALUES (" + dl.MaDichVu + "," + dl.MaTenDiaDiem + ", N'" + dl.SoNha + "'," + dl.MaDuong + "," + dl.MaPhuong + "," + dl.MaQuanHuyen + "," + dl.MaTinhThanh + "," + dl.KinhDo + "," + dl.ViDo + ", N'" + dl.ChuThich + "')";

                executeNonQuery(insertCommand);
                disconnect();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool delete_DuLieu(int ma_dulieu)
        {
            try
            {
                connect();
                string deleteCommand = "DELETE FROM DULIEU WHERE MaDuLieu = '" + ma_dulieu + "'";
                executeNonQuery(deleteCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool update_DuLieu(int ma_dulieu, string sonha)
        {
            try
            {
                connect();
                string deleteCommand = "UPDATE DULIEU SET SoNha = N'" + sonha + "' WHERE MaDuLieu = " + ma_dulieu;
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