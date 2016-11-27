using CityTravelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CityTravelService.Controllers
{
    public class TuKhoaDichVuController : ApiController
    {
        public bool Test()
        {
            if (HttpContext.Current.Session.Count == 0 || HttpContext.Current.Session["UserOnline"] == null)
            {
                return false;
            }
            return true;
        }
        // GET api/tukhoadichvu
        public IEnumerable<TuKhoaDichVu> Get()
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            TuKhoaDichVuDAO tkdvO = new TuKhoaDichVuDAO();
            TuKhoaDichVu[] tkdv = new TuKhoaDichVu[tkdvO.getDsTuKhoaDichVu().Count];
            tkdv = tkdvO.getDsTuKhoaDichVu().ToArray();
            return tkdv;
        }

        // GET api/tukhoadichvu/5
        public IEnumerable<TuKhoaDichVu> Get(int id)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            TuKhoaDichVuDAO dvO = new TuKhoaDichVuDAO();

            TuKhoaDichVu[] dv = new TuKhoaDichVu[dvO.getDsTuKhoaDichVu(id).Count];
            dv = dvO.getDsTuKhoaDichVu(id).ToArray();
            if (dv.Length == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return dv;
        }

        // POST api/tukhoadichvu
        public bool Post([FromBody]TuKhoaDichVu tkdv)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            TuKhoaDichVuDAO tkdv0 = new TuKhoaDichVuDAO();
            tkdv0.insertTuKhoaDichVu(tkdv);
            return true;
        }

        // PUT api/tukhoadichvu/5
        public bool Put([FromBody]TuKhoaDichVu tkdv)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            TuKhoaDichVuDAO tkdv0 = new TuKhoaDichVuDAO();
            tkdv0.updateTuKhoaDichVu(tkdv);
            return true;
        }

        // DELETE api/tukhoadichvu/5
        public bool Delete(int id)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            TuKhoaDichVuDAO tkdv0 = new TuKhoaDichVuDAO();
            tkdv0.deleteTuKhoaDichVu(id);
            return true;
        }
    }
}
