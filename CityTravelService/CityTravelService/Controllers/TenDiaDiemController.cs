using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using CityTravelService.Models;
using CityTravelService.Session;

namespace CityTravelService.Controllers
{
	
    public class TenDiaDiemController : ApiController
    {
        // POST: api/TenDiaDiem
        //Them dia diem
        //[Auth(PerMissionName = "Admin")]
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

        public HttpResponseMessage Get(int ma_ten_diadiem)
        {
            try
            {
                TenDiaDiemDAO ddO = new TenDiaDiemDAO();
                TenDiaDiem result = ddO.getTenDiaDiem(ma_ten_diadiem);
                var response = Request.CreateResponse<TenDiaDiem>(HttpStatusCode.Created, result);
                return response;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //GET: api/TenDiaDiem/5
        public HttpResponseMessage Delete(int id)
        {
            TenDiaDiemDAO ddO = new TenDiaDiemDAO();
            bool result = ddO.DeleteTenDiaDiem(id);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
            return response;
        }
    }
}
