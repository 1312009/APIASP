using CityTravelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityTravelService.Controllers
{
    public class BinhLuanKHController : ApiController
    {
        public IEnumerable<BinhLuanDung> Get()
        {
            BinhLuanDungDAO blO = new BinhLuanDungDAO();

            BinhLuanDung[] result = new BinhLuanDung[blO.getDsBinhLuan().Count];
            result = blO.getDsBinhLuan().ToArray();
            return result;
        }

        // GET: api/BinhLuanKhanh/5
        public IEnumerable<BinhLuanDung> Get(int id)
        {
            BinhLuanDungDAO blO = new BinhLuanDungDAO();

            BinhLuanDung[] bl = new BinhLuanDung[blO.getDsBinhLuan(id).Count];
            bl = blO.getDsBinhLuan(id).ToArray();
            if (bl.Length == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return bl;
        }
    }
}
