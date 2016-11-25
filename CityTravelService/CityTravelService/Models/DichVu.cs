using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class DichVu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Hinh { get; set; }

        public DuLieu dulieu;

        public DichVu() {
            dulieu = new DuLieu();
        }


    }
}