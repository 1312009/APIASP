using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class BinhLuanKhanh
    {
        public int MaDuLieu { get; set; }
        public string MaBinhLuan { get; set; }
        public int IdUser { get; set; }
        public string NoiDung { get; set; }
        public DateTime ThoiGian { get; set; }
        public int TrangThai { get; set; }

        public string Ho { get; set; }
        public string Ten { get; set; }

        public string Hinh { get; set; }
        //public BinhLuanKhanh binhluankhanh;
    }
}