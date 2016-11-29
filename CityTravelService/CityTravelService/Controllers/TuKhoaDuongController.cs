using CityTravelService.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityTravelService.Controllers
{
    public class TuKhoaDuongController : ApiController
    {
        // GET api/tukhoadichvu
        public IEnumerable<TuKhoaDuong> Get()
        {
            TuKhoaDuongDAO tkdvO = new TuKhoaDuongDAO();


            TuKhoaDuong[] tkdv = new TuKhoaDuong[tkdvO.getDsTuKhoaDuong().Count];
            tkdv = tkdvO.getDsTuKhoaDuong().ToArray();
            return tkdv;
        }

        // GET api/tukhoadichvu/5
        public List<TuKhoaTraVe> Get(string tentukhoa)
        {
            TuKhoaDuongDAO dvO = new TuKhoaDuongDAO();

            List <TuKhoaTraVe> tk = dvO.getTuKhoaMaDuong(tentukhoa);
            if (tk == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return tk;
        }

        // POST api/tukhoadichvu
        public HttpResponseMessage Post([FromBody]TuKhoaDuong value)
        {
            TuKhoaDuongDAO dvO = new TuKhoaDuongDAO();
            bool ret = dvO.insertTuKhoaDuong(value);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, ret);
            return response;
        }

        // PUT api/dulieu/5
        public HttpResponseMessage Put([FromBody]TuKhoaDuong tkd)
        {
            TuKhoaDuongDAO dvO = new TuKhoaDuongDAO();
            bool ret = dvO.update_DuLieu(tkd.TuKhoaDuong1, tkd.MaDuong);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, ret);
            return response;
        }

        // DELETE api/dulieu/5
        public HttpResponseMessage Delete(int id)
        {
            TuKhoaDuongDAO dvO = new TuKhoaDuongDAO();
            bool ret = dvO.deleteTuKhoaDuong(id);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, ret);
            return response;
        }
    }
}