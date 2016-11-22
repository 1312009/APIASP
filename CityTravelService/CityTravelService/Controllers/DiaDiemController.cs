using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CityTravelService.Models;

namespace CityTravelService.Controllers
{
    public class DiaDiemController : ApiController
    {
        // POST: api/DiaDiem
        //Them dia diem
        //public HttpResponseMessage Post([FromBody]TenDiaDiem tenDD)
        //{
        //    DiaDiem ddO = new DiaDiem();
        //    bool result = ddO.insertDiaDiem(tenDD);
        //    var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
        //       // response.Headers.Location = new System.Uri(Request.RequestUri, "/api/DiaDiem/" + tenDD.MaTenDiaDiem.ToString());
        //    return response;
        //}

        // PUT: api/DIADIEM/{id}
        //chinh sua ten dia diem
        //public HttpResponseMessage Put(int id, [FromBody]string value)
        //{
        //    TenDiaDiemDAO ddO = new TenDiaDiemDAO();
        //    bool result = ddO.updateDiaDiem(id, value);
        //    var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
        //    return response;
        //}


        // GET: api/DiaDiem
        public HttpResponseMessage Get()
        {
            //try
            //{
                DiaDiemDAO ddO = new DiaDiemDAO();
                DiaDiem[] result = new DiaDiem[ddO.getDsDiaDiem().Count];
                result = ddO.getDsDiaDiem().ToArray();
                var response = Request.CreateResponse<IEnumerable<DiaDiem>>(HttpStatusCode.Created, result);
                return response;
            //}
            //catch (Exception e)
            //{
            //    return new HttpResponseMessage(HttpStatusCode.NotFound);
            //}
        }

        //GET: api/DiaDiem/5
        //public HttpResponseMessage Delete(int id, [FromBody]string tendiadiem)
        //{
        //    TenDiaDiemDAO ddO = new TenDiaDiemDAO();
        //    bool result = ddO.DeleteDiaDiem(id, tendiadiem);
        //    var response = Request.CreateResponse<bool>(HttpStatusCode.Created, result);
        //    return response;
        //}
    }
}
