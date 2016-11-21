using CityTravelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityTravelService.Controllers
{
    public class ChiTietDuLieuController : ApiController
    {

        CHITIET_DULIEU ChiTiet_DuLieu;
        // GET api/chitietdulieu
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public IEnumerable<CHITIET_DULIEU> Get(int ma_dulieu)
        {
            ChiTiet_DuLieu = new CHITIET_DULIEU();
            CHITIET_DULIEU[] chitiet = new CHITIET_DULIEU[ChiTiet_DuLieu.get_DuLieu_ChiTiet(ma_dulieu).Count];
            chitiet = ChiTiet_DuLieu.get_DuLieu_ChiTiet(ma_dulieu).ToArray();
            if (chitiet.Length == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return chitiet;
        }
        // GET api/chitietdulieu/5
        
        // POST api/chitietdulieu
        public void Post([FromBody]string value)
        {
        }

        // PUT api/chitietdulieu/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/chitietdulieu/5
        public void Delete(int id)
        {
        }
    }
}
