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
        

        public List<ChiTietDichVu> get_DuLieu_ChiTiet(int ma_dulieu)
        {
            connect();
            string query = @"select dl.MaDuLieu, dv.TenDichVu, tdd.TenDiaDiem, dl.SoNha, d.TenDuong, p.TenPhuong, qh.TenQuanHuyen, tt.TenTinhThanh
                            from DULIEU dl join DICHVU dv on (dl.MaDichVu = dv.MaDichVu) join TENDIADIEM tdd on (dl.MaTenDiaDiem = tdd.MaTenDiaDiem)
                            join DUONG d on (dl.MaDuong = d.MaDuong) join PHUONG p on (dl.MaPhuong = p.MaPhuong) join QUANHUYEN qh on (dl.MaQuanHuyen = qh.MaQuanHuyen)
                            join TINHTHANH tt on (dl.MaTinhThanh = tt.MaTinhThanh)
                            where dl.MaDuLieu = " + ma_dulieu;
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

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            ChiTietDichVu chitiet_dulieu = new ChiTietDichVu();
            chitiet_dulieu.ma_dulieu = (int)dt.Rows[i]["MaDuLieu"];
            chitiet_dulieu.ten_dichvu = dt.Rows[i]["TenDichVu"].ToString();
            chitiet_dulieu.ten_diadiem = dt.Rows[i]["TenDiaDiem"].ToString();
            chitiet_dulieu.sonha = dt.Rows[i]["SoNha"].ToString().Trim();
            chitiet_dulieu.tenduong = dt.Rows[i]["TenDuong"].ToString();
            chitiet_dulieu.tenphuong = dt.Rows[i]["TenPhuong"].ToString();
            chitiet_dulieu.tenquanhuyen = dt.Rows[i]["TenQuanHuyen"].ToString();
            chitiet_dulieu.tentinhthanh = dt.Rows[i]["TenTinhThanh"].ToString();
            return (object)chitiet_dulieu;
        }
        


    }
}