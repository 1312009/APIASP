using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CityTravelService.Entity;
using CityTravelService.Models;

namespace CityTravelService.Controllers
{
    public class DiaDiemController : ApiController
    {
        // POST: api/DiaDiem
        //Them dia diem
        public HttpResponseMessage Post([FromBody]TENDIADIEM tenDD)
        {
            DiaDiemDAO ddO = new DiaDiemDAO();
            bool result = ddO.insertDiaDiem(tenDD);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
               // response.Headers.Location = new System.Uri(Request.RequestUri, "/api/DiaDiem/" + tenDD.MaTenDiaDiem.ToString());
            return response;
        }

        // PUT: api/DIADIEM/{id}
        //chinh sua ten dia diem
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            DiaDiemDAO ddO = new DiaDiemDAO();
            bool result = ddO.updateDiaDiem(id, value);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
            return response;
        }


        // GET: api/DiaDiem
        public HttpResponseMessage Get()
        {
            try
            {
                DiaDiemDAO ddO = new DiaDiemDAO();
                TENDIADIEM[] result = new TENDIADIEM[ddO.getAllDiaDiem().Count];
                result = ddO.getAllDiaDiem().ToArray();
                var response = Request.CreateResponse<IEnumerable<TENDIADIEM>>(HttpStatusCode.Created, result);
                return response;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //GET: api/DiaDiem/5
        public HttpResponseMessage Delete(int id, [FromBody]string tendiadiem)
        {
            DiaDiemDAO ddO = new DiaDiemDAO();
            bool result = ddO.DeleteDiaDiem(id, tendiadiem);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
            return response;
        }
    }
}
