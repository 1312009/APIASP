using CityTravelServer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class Point
    {
        public float x { get; set; }
        public float y { get; set; }
    }
    public class DiaDiemDAO : DataProvider
    {
        public List<DiaDiem> getDsDiaDiem()
        {
            connect();
            string query = "SELECT * FROM TENDIADIEM JOIN DULIEU ON TENDIADIEM.MaTenDiaDiem = DULIEU.MaTenDiaDiem JOIN DUONG ON DUONG.MaDuong = DULIEU.MaDuong JOIN PHUONG ON PHUONG.MaPhuong = DULIEU.MaPhuong JOIN QUANHUYEN ON QUANHUYEN.MaQuanHuyen = DULIEU.MaQuanHuyen JOIN TINHTHANH ON TINHTHANH.MaTinhThanh = DULIEU.MaTinhThanh JOIN DICHVU ON DICHVU.MaDichVu = DULIEU.MaDichVu";
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

        public List<DiaDiem> getDsDiaDiem(string str)
        {
            List<DiaDiem> diadiem = getDsDiaDiem();
            List<DiaDiem> arr = new List<DiaDiem>();
            string[] arrListStr = str.Split(',');
            for (int i = 0; i < arrListStr.Length; i++)
            {
                arrListStr[i] = arrListStr[i].Trim();
                if (arr.Count == 10) break;
                try {
                    DSTuKhoa dstk = new DSTuKhoa(arrListStr[i]);
                    if (!dstk.Check()) return null;
                    List<TuKhoaTraVe> ttTV = dstk.getTuKhoaTraVe();

                    int j = 0;
                    while (diadiem.Count != 0)
                    {
                        if (arr.Count == 10) break;
                        for (int o = 0; o < diadiem.Count; o++)
                        {
                            if (ttTV[j].bang == 1 && diadiem[o].dichvu.ID == ttTV[j].ma && arr.Count < 10)
                            {
                                arr.Add(diadiem[o]);
                                diadiem.Remove(diadiem[o]);
                                o--;
                            }
                            if (ttTV[j].bang == 2 && diadiem[o].ten.MaTenDiaDiem == ttTV[j].ma && arr.Count < 10)
                            {
                                arr.Add(diadiem[o]);
                                diadiem.Remove(diadiem[o]);
                                o--;
                            }
                            if (ttTV[j].bang == 3 && diadiem[o].duong.MaDuong == ttTV[j].ma && arr.Count < 10)
                            {
                                arr.Add(diadiem[o]);
                                diadiem.Remove(diadiem[o]);
                                o--;
                            }
                            if (ttTV[j].bang == 4 && diadiem[o].phuong.MaPhuong == ttTV[j].ma && arr.Count < 10)
                            {
                                arr.Add(diadiem[o]);
                                diadiem.Remove(diadiem[o]);
                                o--;
                            }
                            if (ttTV[j].bang == 5 && diadiem[o].quanhuyen.MaQuanHuyen == ttTV[j].ma && arr.Count < 10)
                            {
                                arr.Add(diadiem[o]);
                                diadiem.Remove(diadiem[o]);
                                o--;
                            }
                            if (ttTV[j].bang == 6 && diadiem[o].tinhthanh.MaTinhThanh == ttTV[j].ma && arr.Count < 10)
                            {
                                arr.Add(diadiem[o]);
                                diadiem.Remove(diadiem[o]);
                                o--;
                            }
                            if (arr.Count == 10) break;
                        }
                        j++;
                    }
                }
                catch (Exception e) { }
            }
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            DiaDiem dd = new DiaDiem();
            dd.dichvu.ID = dt.Rows[i].IsNull("MaDichVu") == true ? 0 : (int)dt.Rows[i]["MaDichVu"];
            dd.dichvu.Name = dt.Rows[i]["TenDichVu"].ToString();
            dd.dichvu.Hinh = dt.Rows[i]["Hinh"].ToString();
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

            dd.dichvu.dulieu.MaDuLieu = dt.Rows[i].IsNull("MaDuLieu") ? 0 : (int)dt.Rows[i]["MaDuLieu"];
            dd.dichvu.dulieu.MaDichVu = dt.Rows[i].IsNull("MaDichVu") ? 0 : (int)dt.Rows[i]["MaDichVu"];
            dd.dichvu.dulieu.MaTenDiaDiem = dt.Rows[i].IsNull("MaTenDiaDiem") ? 0 : (int)dt.Rows[i]["MaTenDiaDiem"];
            dd.dichvu.dulieu.SoNha = dt.Rows[i]["SoNha"].ToString();
            dd.dichvu.dulieu.MaDuong = dt.Rows[i].IsNull("MaDuong") ? 0 : (int)dt.Rows[i]["MaDuong"];
            dd.dichvu.dulieu.MaPhuong = dt.Rows[i].IsNull("MaPhuong") ? 0 : (int)dt.Rows[i]["MaPhuong"];
            dd.dichvu.dulieu.MaQuanHuyen = dt.Rows[i].IsNull("MaQuanHuyen") ? 0 : (int)dt.Rows[i]["MaQuanHuyen"];
            dd.dichvu.dulieu.MaTinhThanh = dt.Rows[i].IsNull("MaTinhThanh") ? 0 : (int)dt.Rows[i]["MaTinhThanh"];
            dd.dichvu.dulieu.KinhDo = dt.Rows[i].IsNull("KinhDo") ? 0.0f : (double)dt.Rows[i]["KinhDo"];
            dd.dichvu.dulieu.ViDo = dt.Rows[i].IsNull("ViDo") ? 0.0f : (double)dt.Rows[i]["ViDo"];
            dd.dichvu.dulieu.ChuThich = dt.Rows[i]["ChuThich"].ToString();
            dd.dichvu.dulieu.DanhGia = dt.Rows[i].IsNull("DanhGia") ? 0 : (int)dt.Rows[i]["DanhGia"];

            return (object)dd;
        }

        public float Distance(Point a, Point b)
        {
            float result = (float)Math.Sqrt(Math.Pow((double)(a.x - b.x), 2) + Math.Pow((double)(a.y - b.y), 2));
            return result;
        }


    }
}