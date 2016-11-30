using CityTravelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityTravelService.Controllers
{
    public class BinhLuanAdminController : ApiController
    {
        // GET: api/BinhLuanKhanh
        public IEnumerable<BinhLuanKhanh> Get()
        {
            BinhLuanKhanhDAO blO = new BinhLuanKhanhDAO();

            BinhLuanKhanh[] result = new BinhLuanKhanh[blO.getDsBinhLuan().Count];
            result = blO.getDsBinhLuan().ToArray();
            return result;
        }

        // GET: api/BinhLuanKhanh/5
        public IEnumerable<BinhLuanKhanh> Get(int id)
        {
            BinhLuanKhanhDAO blO = new BinhLuanKhanhDAO();

            BinhLuanKhanh[] bl = new BinhLuanKhanh[blO.getDsBinhLuan(id).Count];
            bl = blO.getDsBinhLuan(id).ToArray();
            if (bl.Length == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return bl;
        }

        //// POST: api/BinhLuanKhanh
        //public bool Post([FromBody]BinhLuanKhanh bl)
        //{
        //    BinhLuanKhanhDAO blO = new BinhLuanKhanhDAO();
        //    return blO.insertBinhLuan(bl);
        //}

        //// PUT: api/BinhLuanKhanh/5
        //public void Put([FromBody]BinhLuanKhanh bl)
        //{
        //    BinhLuanKhanhDAO bl0 = new BinhLuanKhanhDAO();
        //    bl0.updateBinhLuan(bl);
        //}

        //// DELETE: api/BinhLuanKhanh/5
        //public void Delete(string id)
        //{
        //    BinhLuanKhanhDAO blO = new BinhLuanKhanhDAO();
        //    blO.deleteBinhLuan(id);
        //}
    }
}
