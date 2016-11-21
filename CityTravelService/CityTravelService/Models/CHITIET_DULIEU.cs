using CityTravelService.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class CHITIET_DULIEU : DataProvider
    {
        public int ma_dulieu { get; set; }
        public string ten_dichvu { get; set; }
        public string ten_diadiem { get; set; }
        public string sonha { get; set; }
        public string tenduong { get; set; }
        public string tenphuong { get; set; }
        public string tenquanhuyen { get; set; }
        public string tentinhthanh { get; set; }

        public List<CHITIET_DULIEU> get_DuLieu_ChiTiet(int ma_dulieu)
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
            List<CHITIET_DULIEU> arr = new List<CHITIET_DULIEU>();
            foreach (Object o in ls)
            {
                arr.Add((CHITIET_DULIEU)o);
            }
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            CHITIET_DULIEU chitiet_dulieu = new CHITIET_DULIEU();
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