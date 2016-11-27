using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CityTravelService.Models;
using System.Web;
namespace CityTravelService.Controllers
{
    public class DiaDiemController : ApiController
    {
        public bool Test()
        {
            if (HttpContext.Current.Session.Count == 0 || HttpContext.Current.Session["UserOnline"] == null)
            {
                return false;
            }
            return true;
        }
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
        public IEnumerable<DiaDiem> Get()
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            try
            {
                DiaDiemDAO ddO = new DiaDiemDAO();
                DiaDiem[] result = new DiaDiem[ddO.getDsDiaDiem().Count];
                result = ddO.getDsDiaDiem().ToArray();
                //var response = Request.CreateResponse<IEnumerable<DiaDiem>>(HttpStatusCode.Created, result);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public HttpResponseMessage Get(string str)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            try
            {
                DiaDiemDAO ddO = new DiaDiemDAO();
                DiaDiem[] result = new DiaDiem[ddO.getDsDiaDiem(str).Count];
                result = ddO.getDsDiaDiem(str).ToArray();
                var response = Request.CreateResponse<IEnumerable<DiaDiem>>(HttpStatusCode.Created, result);
                return response;
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
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
