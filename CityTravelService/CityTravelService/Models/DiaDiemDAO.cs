using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class DiaDiemDAO : DataProvider
    {
        public List<DiaDiem> getDsDiaDiem()
        {
            connect();
            string query = "SELECT * FROM TENDIADIEM JOIN DULIEU ON TENDIADIEM.MaTenDiaDiem = DULIEU.MaTenDiaDiem JOIN DUONG ON DUONG.MaDuong = DULIEU.MaDuong JOIN PHUONG ON PHUONG.MaPhuong = DULIEU.MaPhuong JOIN QUANHUYEN ON QUANHUYEN.MaQuanHuyen = DULIEU.MaQuanHuyen JOIN TINHTHANH ON TINHTHANH.MaTinhThanh = DULIEU.MaTinhThanh";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<DiaDiem> arr = new List<DiaDiem>();
            foreach (Object o in ls)
            {
                arr.Add((DiaDiem)o);
            }
            disconnect();
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            DiaDiem dd = new DiaDiem();
            dd.ten.MaTenDiaDiem = dt.Rows[i].IsNull("MaTenDiaDiem") == true? 0 : (int)dt.Rows[i]["MaTenDiaDiem"];
            dd.ten.TenDiaDiem1 = dt.Rows[i]["TenDiaDiem"].ToString();
            dd.duong.MaDuong = dt.Rows[i].IsNull("MaDuong") == true ? 0 : (int)dt.Rows[i]["MaDuong"];
            dd.duong.TenDuong = dt.Rows[i]["TenDuong"].ToString();
            dd.phuong.MaPhuong = dt.Rows[i].IsNull("MaPhuong") == true ? 0 : (int)dt.Rows[i]["MaPhuong"];
            dd.phuong.TenPhuong = dt.Rows[i]["TenPhuong"].ToString();
            dd.quanhuyen.MaQuanHuyen = dt.Rows[i].IsNull("MaQuanHuyen") == true ? 0 : (int)dt.Rows[i]["MaQuanHuyen"];
            dd.quanhuyen.TenQuanHuyen = dt.Rows[i]["TenQuanHuyen"].ToString();
            dd.tinhthanh.MaTinhThanh = dt.Rows[i].IsNull("MaTinhThanh") == true ? 0 : (int)dt.Rows[i]["MaTinhThanh"];
            dd.tinhthanh.TenTinhThanh = dt.Rows[i]["TenTinhThanh"].ToString();

            return (object)dd;
        }
    }
}