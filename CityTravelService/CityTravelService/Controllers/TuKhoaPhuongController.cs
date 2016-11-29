using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CityTravelService.Models;

namespace CityTravelService.Controllers
{
    public class TuKhoaPhuongController : ApiController
    {
        // GET: api/TuKhoaPhuong?tukhoaphuong={tukhoaphuong}
        public HttpResponseMessage Get(string tukhoaphuong)
        {
            TuKhoaPhuongDAO daO = new TuKhoaPhuongDAO();
            List<TuKhoaTraVe> result = daO.getTuKhoaPhuong(tukhoaphuong);
            if (result.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var response = Request.CreateResponse<List<TuKhoaTraVe>>(HttpStatusCode.Created, result);
            return response;
        }

        // GET: api/TuKhoaPhuong
        public HttpResponseMessage Get()
        {
            try
            {
                TuKhoaPhuongDAO daO = new TuKhoaPhuongDAO();
                TuKhoaPhuong[] result = new TuKhoaPhuong[daO.getDsTuKhoaPhuong().Count];
                result = daO.getDsTuKhoaPhuong().ToArray();
                var response = Request.CreateResponse<IEnumerable<TuKhoaPhuong>>(HttpStatusCode.Created, result);
                return response;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // POST: api/TuKhoaPhuong
        public HttpResponseMessage Post([FromBody]TuKhoaPhuong tkp)
        {
            TuKhoaPhuongDAO daO = new TuKhoaPhuongDAO();
            bool result = daO.insertTuKhoaPhuong(tkp);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
            // response.Headers.Location = new System.Uri(Request.RequestUri, "/api/DiaDiem/" + tenDD.MaTenDiaDiem.ToString());
            return response;
        }

        // PUT: api/TuKhoaPhuong/5
        public HttpResponseMessage Put([FromBody]TuKhoaPhuong tkp)
        {
            TuKhoaPhuongDAO daO = new TuKhoaPhuongDAO();
            bool result = daO.updateTuKhoaPhuong(tkp.MaTuKhoaPhuong, tkp.TuKhoaPhuong1);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
            return response;

        }

        // DELETE: api/TuKhoaPhuong/5
        public HttpResponseMessage Delete(int id)
        {
            TuKhoaPhuongDAO daO = new TuKhoaPhuongDAO();
            bool result = daO.deleteTuKhoaPhuong(id);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
            return response;
        }
    }
}
