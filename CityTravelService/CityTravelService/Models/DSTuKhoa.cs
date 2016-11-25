using System.Collections.Generic;

namespace CityTravelService.Models
{
    public class DSTuKhoa
    {
        public TuKhoaDichVuDAO dvO { get; set; }
        public TuKhoaDiaDiemDAO ddO { get; set; }
        public TuKhoaDuongDAO tdO { get; set; }
        public TuKhoaPhuongDAO tpO { get; set; }
        public TuKhoaQuanHuyenDAO qhO { get; set; }
        public TuKhoaTinhThanhDAO ttO { get; set; }


        List<TuKhoaTraVe> dvTV;
        List<TuKhoaTraVe> ddTV;
        List<TuKhoaTraVe> tdTV;
        List<TuKhoaTraVe> tpTV;
        List<TuKhoaTraVe> qhTV;
        List<TuKhoaTraVe> ttTV;

        int dem;
        public DSTuKhoa(string str)
        {
            dvO = new TuKhoaDichVuDAO();
            ddO = new TuKhoaDiaDiemDAO();
            tdO = new TuKhoaDuongDAO();
            tpO = new TuKhoaPhuongDAO();
            qhO = new TuKhoaQuanHuyenDAO();
            ttO = new TuKhoaTinhThanhDAO();

            dvTV = dvO.getTuKhoaDichVu(str);
            ddTV = ddO.getTuKhoaDiaDiem(str);
            tdTV = tdO.getTuKhoaMaDuong(str);
            tpTV = tpO.getTuKhoaPhuong(str);
            qhTV = qhO.getTuKhoaQuanHuyen(str);
            ttTV = ttO.getTuKhoaTinhThanh(str);
            dem = 0;
        }

        public List<TuKhoaTraVe> getTuKhoaTraVe()
        {
            List<TuKhoaTraVe> arr = new List<TuKhoaTraVe>();

            TuKhoaTraVe TV = dvTV.Count == 0 ? null : dvTV[0];
            TV = TV == null ? ddTV[0] : TV;
            TV = TV == null ? tdTV[0] : TV;
            TV = TV == null ? tpTV[0] : TV;
            TV = TV == null ? qhTV[0] : TV;
            TV = TV == null ? ttTV[0] : TV;

            bool flat = true;
            int t = TV.bang;
            do
            {
                //Dich Vu
                if (dvTV.Count != 0 && TV.saiso >= dvTV[0].saiso)
                {
                    t = dvTV[0].bang;
                    TV = dvTV[0];
                }
                //Dia Diem
                if (ddTV.Count != 0 && TV.saiso >= ddTV[0].saiso)
                {
                    t = ddTV[0].bang;
                    TV = ddTV[0];
                }
                //Duong
                if (tdTV.Count != 0 && TV.saiso >= tdTV[0].saiso)
                {
                    t = tdTV[0].bang;
                    TV = tdTV[0];
                }
                //Phuong
                if (tpTV.Count != 0 && TV.saiso >= tpTV[0].saiso)
                {
                    t = tpTV[0].bang;
                    TV = tpTV[0];
                }
                //Quan Huyen
                if (qhTV.Count != 0 && TV.saiso >= qhTV[0].saiso)
                {
                    t = qhTV[0].bang;
                    TV = qhTV[0];
                }
                //Thanh Pho
                if (ttTV.Count != 0 && TV.saiso >= ttTV[0].saiso)
                {
                    t = ttTV[0].bang;
                    TV = ttTV[0];
                }
                if (dem == 5)
                {
                    if (dvTV.Count != 0)
                        arr.AddRange(dvTV.ToArray());
                    if (ddTV.Count != 0)
                        arr.AddRange(ddTV.ToArray());
                    if (tdTV.Count != 0)
                        arr.AddRange(tdTV.ToArray());
                    if (tpTV.Count != 0)
                        arr.AddRange(tpTV.ToArray());
                    if (qhTV.Count != 0)
                        arr.AddRange(qhTV.ToArray());
                    if (ttTV.Count != 0)
                        arr.AddRange(ttTV.ToArray());
                    break;
                }
                arr.Add(TV);
                switch (t)
                {
                    case 1:
                        dvTV.RemoveAt(0);
                        TV = ddTV.Count != 0 ? ddTV[0] : tdTV.Count != 0? tdTV[0] : tpTV.Count != 0? tpTV[0] : qhTV.Count != 0 ? qhTV[0] : ttTV.Count != 0 ? ttTV[0] : dvTV[0];
                        if (dvTV.Count == 0)
                            dem++;
                        break;
                    case 2:
                        ddTV.RemoveAt(0);
                        TV = tdTV.Count != 0 ? tdTV[0] : tpTV.Count != 0 ? tpTV[0] : qhTV.Count != 0 ? qhTV[0] : ttTV.Count != 0 ? ttTV[0] : dvTV.Count != 0? dvTV[0] : ddTV[0];
                        if (ddTV.Count == 0)
                            dem++;
                        break;
                    case 3:
                        tdTV.RemoveAt(0);
                        TV = tpTV.Count != 0 ? tpTV[0] : qhTV.Count != 0 ? qhTV[0] : ttTV.Count != 0 ? ttTV[0] : dvTV.Count != 0 ? dvTV[0] : ddTV.Count != 0? ddTV[0] : tdTV[0];
                        if (tdTV.Count == 0)
                            dem++;
                        break;
                    case 4:
                        tpTV.RemoveAt(0);
                        TV = qhTV.Count != 0 ? qhTV[0] : ttTV.Count != 0 ? ttTV[0] : dvTV.Count != 0 ? dvTV[0] : ddTV.Count != 0 ? ddTV[0] : tdTV.Count != 0? tdTV[0] : tpTV[0];
                        if (tpTV.Count == 0)
                            dem++;
                        break;
                    case 5:
                        qhTV.RemoveAt(0);
                        TV = ttTV.Count != 0 ? ttTV[0] : dvTV.Count != 0 ? dvTV[0] : ddTV.Count != 0 ? ddTV[0] : tdTV.Count != 0 ? tdTV[0] : tpTV.Count != 0? tpTV[0] : qhTV[0];
                        if (qhTV.Count == 0)
                            dem++;
                        break;
                    case 6:
                        ttTV.RemoveAt(0);
                        TV = dvTV.Count != 0 ? dvTV[0] : ddTV.Count != 0 ? ddTV[0] : tdTV.Count != 0 ? tdTV[0] : tpTV.Count != 0 ? tpTV[0] : qhTV.Count != 0? qhTV[0] : ttTV[0];
                        if (ttTV.Count == 0)
                            dem++;
                        break;
                }
                if (dvTV.Count == 0 && ddTV.Count == 0 && tdTV.Count == 0 && tpTV.Count == 0 && qhTV.Count == 0 && ttTV.Count == 0) flat = false;
            } while (flat);

            return arr;
        }

        public bool Check()
        {
            if (dvTV.Count == 0) dem++;
            if (ddTV.Count == 0) dem++;
            if (tdTV.Count == 0) dem++;
            if (tpTV.Count == 0) dem++;
            if (qhTV.Count == 0) dem++;
            if (ttTV.Count == 0) dem++;
            if (dvTV.Count == 0 && ddTV.Count == 0 && tdTV.Count == 0 && tpTV.Count == 0 && qhTV.Count == 0 && ttTV.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}