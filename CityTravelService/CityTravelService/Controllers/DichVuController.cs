using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CityTravelService.Models;
using CityTravelService.Session;
using System.Web;

namespace CityTravelService.Controllers
{
    public class DichVuController : ApiController
    {
        public bool Test()
        {
            if (HttpContext.Current.Session.Count == 0 || HttpContext.Current.Session["UserOnline"] == null)
            {
                return false;
            }
            return true;
        }
        // GET: api/DichVu
        public IEnumerable<DichVu> Get()
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            DichVuDAO dvO = new DichVuDAO();

            DichVu[] dv = new DichVu[dvO.getDsDichVu().Count];
            dv = dvO.getDsDichVu().ToArray();
            return dv;
        }

        // GET: api/DichVu/5
        public IEnumerable<DichVu> Get(int id)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            DichVuDAO dvO = new DichVuDAO();

            DichVu[] dv = new DichVu[dvO.getDsDichVu(id).Count];
            dv = dvO.getDsDichVu(id).ToArray();
            if (dv.Length == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return dv;
        }

        // POST: api/DichVu
        [Auth(PerMissionName = "Admin")]
        public void Post([FromBody]DichVu dv)
        {
            DichVuDAO dv0 = new DichVuDAO();
            dv0.insertDichVu(dv);
        }

        // PUT: api/DichVu/5
        //public HttpResponseMessage Put([FromBody]DichVu dv)
        //{
        //    DichVuDAO dvO = new DichVuDAO();
        //    dvO.updateDichVu(dv);
        //    var response = Request.CreateResponse<DichVu>(HttpStatusCode.Created, dv);
        //    response.Headers.Location = new System.Uri(Request.RequestUri, "/api/DichVu/" + dv.ID);
        //    return response;
        //}

        // PUT: api/DichVu/5
        [Auth(PerMissionName = "Admin")]
        public void Put([FromBody]DichVu dv)
        {
            DichVuDAO dv0 = new DichVuDAO();
            dv0.updateDichVu(dv);
        }

        // DELETE: api/DichVu/5
        [Auth(PerMissionName = "Admin")]
        public void Delete(int id)
        {
            DichVuDAO dv0 = new DichVuDAO();
            dv0.deleteDichVu(id);
        }
    }
}
