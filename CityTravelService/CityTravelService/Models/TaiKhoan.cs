using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class TaiKhoan
    {
        public string Email { set; get; }
        public string PassWord { set; get; }
        public string LastName { set; get; }
        public string FirtName { set; get; }
        public string Phone { set; get; }
        public int Sex { set; get; }
        public DateTime Birth { set; get; }
        public string Address { set; get; }
        public string Picture { set; get; }
        public string Role { get; set; }
        public int IdUser { get; set; }
        public string Provider { get; set; }


    }
}