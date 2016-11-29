using CityTravelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityTravelService.Controllers
{
    public class TuKhoaQuanHuyenController : ApiController
    {
        // GET: api/TuKhoaQuanHuyen
        public IEnumerable<TuKhoaQuanHuyen> Get()
        {
            TuKhoaQuanHuyenDAO qhO = new TuKhoaQuanHuyenDAO();


            TuKhoaQuanHuyen[] tkqh = new TuKhoaQuanHuyen[qhO.getDsTuKhoaQuanHuyen().Count];
            tkqh = qhO.getDsTuKhoaQuanHuyen().ToArray();
            return tkqh;
        }

        // GET api/tukhoadichvu/5
        public List<TuKhoaTraVe> Get(string tentukhoa)
        {
            TuKhoaQuanHuyenDAO qhO = new TuKhoaQuanHuyenDAO();

            List<TuKhoaTraVe> tk = qhO.getTuKhoaQuanHuyen(tentukhoa);
            if (tk == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return tk;
        }

        // POST api/tukhoadichvu
        public HttpResponseMessage Post([FromBody]TuKhoaQuanHuyen value)
        {
            TuKhoaQuanHuyenDAO qhO = new TuKhoaQuanHuyenDAO();
            bool ret = qhO.insertTuKhoaQuanHuyen(value);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, ret);
            return response;
        }

        // PUT api/dulieu/5
        public HttpResponseMessage Put([FromBody]TuKhoaQuanHuyen tkq)
        {
            TuKhoaQuanHuyenDAO dvO = new TuKhoaQuanHuyenDAO();
            bool ret = dvO.updateTuKhoaQuanHuyen(tkq);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, ret);
            return response;
        }

        // DELETE api/dulieu/5
        public HttpResponseMessage Delete(int id)
        {
            TuKhoaQuanHuyenDAO qhO = new TuKhoaQuanHuyenDAO();
            bool ret = qhO.deleteTuKhoaQuanHuyen(id);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, ret);
            return response;
        }
    }
}
