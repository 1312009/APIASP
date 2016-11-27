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
            DichVuDAO ddO = new DichVuDAO();

            DichVu[] dd = new DichVu[ddO.getDsDichVu().Count];
            dd = ddO.getDsDichVu().ToArray();
            return dd;
        }

        // GET: api/DichVu/5
        public IEnumerable<DichVu> Get(int id)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            DichVuDAO ddO = new DichVuDAO();

            DichVu[] dd = new DichVu[ddO.getDsDichVu(id).Count];
            dd = ddO.getDsDichVu(id).ToArray();
            if (dd.Length == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return dd;
        }

        // POST: api/DichVu
        [Auth(PerMissionName = "Admin")]
        public void Post([FromBody]DichVu dd)
        {
            DichVuDAO dd0 = new DichVuDAO();
            dd0.insertDichVu(dd);
        }

        // PUT: api/DichVu/5
        //public HttpResponseMessage Put([FromBody]DichVu dd)
        //{
        //    DichVuDAO ddO = new DichVuDAO();
        //    ddO.updateDichVu(dd);
        //    var response = Request.CreateResponse<DichVu>(HttpStatusCode.Created, dd);
        //    response.Headers.Location = new System.Uri(Request.RequestUri, "/api/DichVu/" + dd.ID);
        //    return response;
        //}

        // PUT: api/DichVu/5
        [Auth(PerMissionName = "Admin")]
        public void Put([FromBody]DichVu dd)
        {
            DichVuDAO dd0 = new DichVuDAO();
            dd0.updateDichVu(dd);
        }

        // DELETE: api/DichVu/5
        [Auth(PerMissionName = "Admin")]
        public void Delete(int id)
        {
            DichVuDAO dd0 = new DichVuDAO();
            dd0.deleteDichVu(id);
        }
    }
}
