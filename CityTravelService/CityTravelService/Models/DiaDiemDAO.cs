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
            string query = "SELECT * FROM TENDIADIEM JOIN DULIEU ON TENDIADIEM.MaTenDiaDiem = DULIEU.MaTenDiaDiem JOIN DICHVU ON DICHVU.MaDichVu = DULIEU.MaDichVu JOIN DUONG ON DUONG.MaDuong = DULIEU.MaDuong JOIN PHUONG ON PHUONG.MaPhuong = DULIEU.MaPhuong JOIN QUANHUYEN ON QUANHUYEN.MaQuanHuyen = DULIEU.MaQuanHuyen JOIN TINHTHANH ON TINHTHANH.MaTinhThanh = DULIEU.MaTinhThanh";
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
            TuKhoaDichVuDAO tdO = new TuKhoaDichVuDAO();
            List<TuKhoaDichVu> tkdv = tdO.getDsTuKhoaDichVu();
            List<DiaDiem> diadiem = getDsDiaDiem();
            List<DiaDiem> arr = new List<DiaDiem>();
            List<DiaDiem> arr1 = new List<DiaDiem>();
            List<string> arrListStr = new List<string>();
            arrListStr.Add("");
            arrListStr.Add(str);
            int mdv = 0; string sd = "";
            for (int i = 0; i < tkdv.Count; i++)
            {
                if(str == tkdv[i].TenTuKhoaDichVu)
                {
                    foreach (DiaDiem o in diadiem)
                    {
                        if (tkdv[i].MaDichVu == o.dichvu.ID)
                            arr.Add(o);
                    }
                    if (arr.Count != 0) return arr;
                }
                else
                {
                    if(str.Contains(tkdv[i].TenTuKhoaDichVu) && tkdv[i].TenTuKhoaDichVu.Length > sd.Length)
                    {
                        string s1 = str.Substring(0, str.IndexOf(tkdv[i].TenTuKhoaDichVu));
                        int t1 = str.IndexOf(tkdv[i].TenTuKhoaDichVu) + tkdv[i].TenTuKhoaDichVu.Length;
                        string s2 = str.Substring(t1, str.Length - t1);
                        mdv = tkdv[i].MaDichVu;
                        sd = tkdv[i].TenTuKhoaDichVu;
                        arrListStr[0] = s1 + s2;
                    }
                }
            }

            for (int i = 0; i < diadiem.Count; i++)
            {
                if(mdv == diadiem[i].dichvu.ID)
                {
                    arr1.Add(diadiem[i]);
                }
            }

            try
            {
                arrListStr[0] = arrListStr[0].Trim();
                DSTuKhoa dstk = new DSTuKhoa(arrListStr[0]);
                if (!dstk.Check()) return null;
                List<TuKhoaTraVe> ttTV = dstk.getTuKhoaTraVe();

                int j = 0;
                while (arr1.Count != 0)
                {
                    if (arr.Count == 10) break;
                    for (int o = 0; o < arr1.Count; o++)
                    {
                        if (ttTV[j].bang == 1 && arr1[o].dichvu.ID == ttTV[j].ma && arr.Count < 10)
                        {
                            arr.Add(arr1[o]);
                            arr1.Remove(arr1[o]);
                            o--;
                        }
                        if (ttTV[j].bang == 2 && arr1[o].ten.MaTenDiaDiem == ttTV[j].ma && arr.Count < 10)
                        {
                            arr.Add(arr1[o]);
                            arr1.Remove(arr1[o]);
                            o--;
                        }
                        if (ttTV[j].bang == 3 && arr1[o].duong.MaDuong == ttTV[j].ma && arr.Count < 10)
                        {
                            arr.Add(arr1[o]);
                            arr1.Remove(arr1[o]);
                            o--;
                        }
                        if (ttTV[j].bang == 4 && arr1[o].phuong.MaPhuong == ttTV[j].ma && arr.Count < 10)
                        {
                            arr.Add(arr1[o]);
                            arr1.Remove(arr1[o]);
                            o--;
                        }
                        if (ttTV[j].bang == 5 && arr1[o].quanhuyen.MaQuanHuyen == ttTV[j].ma && arr.Count < 10)
                        {
                            arr.Add(arr1[o]);
                            arr1.Remove(arr1[o]);
                            o--;
                        }
                        if (ttTV[j].bang == 6 && arr1[o].tinhthanh.MaTinhThanh == ttTV[j].ma && arr.Count < 10)
                        {
                            arr.Add(arr1[o]);
                            arr1.Remove(arr1[o]);
                            o--;
                        }
                        if (arr.Count == 10) break;
                    }
                    j++;
                }
            }
            catch (Exception e) { }

            if (arr.Count == 0)
            {
                try
                {
                    arrListStr[1] = arrListStr[1].Trim();
                    DSTuKhoa dstk = new DSTuKhoa(arrListStr[1]);
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

        public DiaDiem getDLDiaDiem(int madulieu)
        {
            List<DiaDiem> diadiem = getDsDiaDiem();
            for (int i = 0; i < diadiem.Count; i++)
            {
                if (madulieu == diadiem[i].MaDuLieu)
                    return diadiem[i];
            }

            return null;
        }



        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            DiaDiem dd = new DiaDiem();
            dd.MaDuLieu = dt.Rows[i].IsNull("MaDuLieu") == true ? 0 : (int)dt.Rows[i]["MaDuLieu"];

            dd.ten.MaTenDiaDiem = dt.Rows[i].IsNull("MaTenDiaDiem") == true? 0 : (int)dt.Rows[i]["MaTenDiaDiem"];
            dd.ten.TenDiaDiem1 = dt.Rows[i]["TenDiaDiem"].ToString();

            dd.dichvu.ID = dt.Rows[i].IsNull("MaDichVu") == true ? 0 : (int)dt.Rows[i]["MaDichVu"];
            dd.dichvu.Name = dt.Rows[i]["TenDichVu"].ToString();
            dd.dichvu.Hinh = dt.Rows[i]["Hinh"].ToString();

            dd.duong.MaDuong = dt.Rows[i].IsNull("MaDuong") == true ? 0 : (int)dt.Rows[i]["MaDuong"];
            dd.duong.TenDuong = dt.Rows[i]["TenDuong"].ToString();

            dd.phuong.MaPhuong = dt.Rows[i].IsNull("MaPhuong") == true ? 0 : (int)dt.Rows[i]["MaPhuong"];
            dd.phuong.TenPhuong = dt.Rows[i]["TenPhuong"].ToString();

            dd.quanhuyen.MaQuanHuyen = dt.Rows[i].IsNull("MaQuanHuyen") == true ? 0 : (int)dt.Rows[i]["MaQuanHuyen"];
            dd.quanhuyen.TenQuanHuyen = dt.Rows[i]["TenQuanHuyen"].ToString();

            dd.tinhthanh.MaTinhThanh = dt.Rows[i].IsNull("MaTinhThanh") == true ? 0 : (int)dt.Rows[i]["MaTinhThanh"];
            dd.tinhthanh.TenTinhThanh = dt.Rows[i]["TenTinhThanh"].ToString();

            dd.KinhDo = dt.Rows[i].IsNull("KinhDo") == true ? 0.0d : (double)dt.Rows[i]["KinhDo"];
            dd.ViDo = dt.Rows[i].IsNull("ViDo") == true ? 0.0d : (double)dt.Rows[i]["ViDo"];
            dd.ChuThich = dt.Rows[i]["ChuThich"].ToString();
            DanhGiaDAO dgO = new DanhGiaDAO();
            dd.DanhGia = dgO.getDanhGia(dd.MaDuLieu);
            return (object)dd;
        }
    }
}