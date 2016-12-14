using CityTravelServer.Models;
using CityTravelService.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityTravelServer.Controllers
{
    [RoutePrefix("api/BinhLuan")]
    public class BinhLuanController : ApiController
    {
        // GET: api/BinhLuan
        [Route("")]
        [HttpGet]
        public IEnumerable<BinhLuan> Get()
        {
            BinhLuanDAO blO = new BinhLuanDAO();

            BinhLuan[] bl = new BinhLuan[blO.getDsBinhLuan().Count];
            bl = blO.getDsBinhLuan().ToArray();
            return bl;
        }
        [Route("")]
        [HttpGet]
        // GET: api/BinhLuan/5
        public IEnumerable<BinhLuan> Get(string id)
        {
            BinhLuanDAO blO = new BinhLuanDAO();

            BinhLuan[] bl = new BinhLuan[blO.getDsBinhLuan(id).Count];
            bl = blO.getDsBinhLuan(id).ToArray();
            if (bl.Length == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return bl;
        }

        // POST: api/BinhLuan
        [Route("")]
        [HttpPost]
        public bool Post(BinhLuan bl)
        {
           
            BinhLuanDAO blO = new BinhLuanDAO();
            return blO.insertBinhLuan(bl);
        }
        [Route("")]
        [HttpPut]
        // PUT: api/BinhLuan/5
        public bool Put(string id)
        {
            BinhLuanDAO bl0 = new BinhLuanDAO();
            return bl0.updateBinhLuan(id);
        }
        [Route("")]
        [HttpDelete]
        // DELETE: api/BinhLuan/5
        public bool Delete(string id)
        {
            BinhLuanDAO blO = new BinhLuanDAO();
            return blO.deleteBinhLuan(id);
        }
    }
}
