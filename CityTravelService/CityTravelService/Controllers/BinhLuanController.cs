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
        public void Post([FromBody]BinhLuan bl)
        {
            BinhLuanDAO blO = new BinhLuanDAO();
            blO.insertBinhLuan(bl);
        }
        [Route("")]
        [HttpPut]
        // PUT: api/BinhLuan/5
        public void Put([FromBody]string bl)
        {
            BinhLuanDAO bl0 = new BinhLuanDAO();
            bl0.updateBinhLuan(bl);
        }
        [Route("")]
        [HttpDelete]
        // DELETE: api/BinhLuan/5
        public void Delete(string id)
        {
            BinhLuanDAO blO = new BinhLuanDAO();
            blO.deleteBinhLuan(id);
        }
    }
}
