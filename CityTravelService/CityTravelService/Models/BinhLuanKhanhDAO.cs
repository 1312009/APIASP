using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class BinhLuanKhanhDAO : DataProvider
    {
        public List<BinhLuanKhanh> getDsBinhLuan()
        {
            connect();
            string query = "SELECT * FROM BINHLUAN JOIN TAIKHOAN ON TAIKHOAN.IdUser = BINHLUAN.IdUser WHERE TrangThai =" + 0;
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<BinhLuanKhanh> arr = new List<BinhLuanKhanh>();
            foreach (Object o in ls)
            {
                arr.Add((BinhLuanKhanh)o);
            }
            disconnect();
            return arr;
        }

        public List<BinhLuanKhanh> getDsBinhLuan(int id)
        {
            connect();
            string query = "SELECT * FROM BINHLUAN JOIN TAIKHOAN ON TAIKHOAN.IdUser = BINHLUAN.IdUser WHERE TrangThai =" + 0 + "AND MaDuLieu = " + id;
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<BinhLuanKhanh> arr = new List<BinhLuanKhanh>();
            foreach (Object o in ls)
            {
                arr.Add((BinhLuanKhanh)o);
            }

            disconnect();
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            BinhLuanKhanh bl = new BinhLuanKhanh();

            bl.MaDuLieu = dt.Rows[i].IsNull("MaDuLieu") == true ? 0 : (int)dt.Rows[i]["MaDuLieu"];
            bl.MaBinhLuan = dt.Rows[i]["MaBinhLuan"].ToString();
            bl.IdUser = (int)dt.Rows[i]["IdUser"];
            bl.NoiDung = dt.Rows[i]["NoiDung"].ToString();
            bl.ThoiGian = (DateTime)dt.Rows[i]["ThoiGian"];
            bl.TrangThai = dt.Rows[i].IsNull("TrangThai") == true ? 0 : (int)dt.Rows[i]["TrangThai"];

            bl.Ho = dt.Rows[i]["Ho"].ToString();
            bl.Ten = dt.Rows[i]["Ten"].ToString();
            bl.Hinh = dt.Rows[i]["Hinh"].ToString();

            return (object)bl;
        }
    }
}