using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CityTravelService.Models;

namespace CityTravelService.Controllers
{
    public class DichVuController : ApiController
    {
        #region GET
        // GET: api/DichVu
        public IEnumerable<DichVu> Get()
        {
            DichVuDAO dvO = new DichVuDAO();

            DichVu[] dv = new DichVu[dvO.getDsDichVu().Count];
            dv = dvO.getDsDichVu().ToArray();
            return dv;
        }

        // GET: api/DichVu/5
        public IEnumerable<DichVu> Get(int id)
        {
            DichVuDAO dvO = new DichVuDAO();

            DichVu[] dv = new DichVu[dvO.getDsDichVu(id).Count];
            dv = dvO.getDsDichVu(id).ToArray();
            if (dv.Length == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return dv;
        }
        #endregion

        #region POST
        // POST: api/DichVu
        public HttpResponseMessage Post([FromBody]DichVu dv)
        {
            DichVuDAO dvO = new DichVuDAO();
            dvO.insertDichVu(dv);
            var response = Request.CreateResponse<DichVu>(HttpStatusCode.Created, dv);
            response.Headers.Location = new System.Uri(Request.RequestUri, "/api/DichVu/" + dv.ID.ToString());
            return response;
        }
        #endregion

        #region PUT
        // PUT: api/DichVu/5
        public HttpResponseMessage Put([FromBody]DichVu dv)
        {
            DichVuDAO dvO = new DichVuDAO();
            dvO.updateDichVu(dv);
            var response = Request.CreateResponse<DichVu>(HttpStatusCode.Created, dv);
            response.Headers.Location = new System.Uri(Request.RequestUri, "/api/DichVu/" + dv.ID.ToString());
            return response;
        }
        #endregion

        #region DELETE
        // DELETE: api/DichVu/5
        public DichVu Delete(int id)
        {
            DichVuDAO dvO = new DichVuDAO();
            DichVu[] dv = new DichVu[dvO.getDsDichVu(id).Count];
            dv = dvO.getDsDichVu(id).ToArray();
            if (dv.Length == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            dvO.deleteDichVu(id);
            return dv[0];
        }
        #endregion
    }
}
