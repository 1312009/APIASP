using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using CityTravelService.Models;

namespace CityTravelService.Controllers
{
	[Auth(PerMissionName = "Admin")]
    public class DiaDiemController : ApiController
    {
        // POST: api/TenDiaDiem
        //Them dia diem
        public HttpResponseMessage Post([FromBody]TenDiaDiem tenDD)
        {
            TenDiaDiemDAO ddO = new TenDiaDiemDAO();
            bool result = ddO.insertTenDiaDiem(tenDD);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
            // response.Headers.Location = new System.Uri(Request.RequestUri, "/api/DiaDiem/" + tenDD.MaTenDiaDiem.ToString());
            return response;
        }

        // PUT: api/TenDIADIEM/{id}
        //chinh sua ten dia diem
        public HttpResponseMessage Put([FromBody]TenDiaDiem tenDD)
        {
            TenDiaDiemDAO ddO = new TenDiaDiemDAO();
            bool result = ddO.updateTenDiaDiem(tenDD.MaTenDiaDiem, tenDD.TenDiaDiem1);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
            return response;
        }


        // GET: api/tenDiaDiem
        public HttpResponseMessage Get()
        {
            try
            {
                TenDiaDiemDAO ddO = new TenDiaDiemDAO();
                TenDiaDiem[] result = new TenDiaDiem[ddO.getAllTenDiaDiem().Count];
                result = ddO.getAllTenDiaDiem().ToArray();
                var response = Request.CreateResponse<IEnumerable<TenDiaDiem>>(HttpStatusCode.Created, result);
                return response;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //GET: api/TenDiaDiem/5
        public HttpResponseMessage Delete(int id, [FromBody]string tendiadiem)
        {
            TenDiaDiemDAO ddO = new TenDiaDiemDAO();
            bool result = ddO.DeleteTenDiaDiem(id, tendiadiem);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
            return response;
        }
    }
}
