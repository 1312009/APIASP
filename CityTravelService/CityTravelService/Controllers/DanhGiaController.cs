using CityTravelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityTravelService.Controllers
{
    public class DanhGiaController : ApiController
    {
        // GET api/danhgia
        public IEnumerable<DanhGia> Get()
        {
            DanhGiaDAO dgO = new DanhGiaDAO();

            DanhGia[] dg = new DanhGia[dgO.getDsDanhGia().Count];
            dg = dgO.getDsDanhGia().ToArray();
            return dg;
        }

        // GET: api/DanhGia/5
        //public IEnumerable<DanhGia> Get(int id)
        //{
        //    DanhGiaDAO dgO = new DanhGiaDAO();

        //    DanhGia[] dg = new DanhGia[dgO.getDsDanhGia(id).Count];
        //    dg = dgO.getDsDanhGia(id).ToArray();
        //    //if (dg.Length == 0)
        //    //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

        //    return dg;

        //}

        public float Get(int madiadiem)
        {
            DanhGiaDAO dgO = new DanhGiaDAO();

            return dgO.getDanhGia(madiadiem);
            //if (dg.Length == 0)
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // GET: api/DanhGia?email=example@gmail.com&id=1217
        public DanhGia Get(string email, int id)
        {
            DanhGiaDAO dgO = new DanhGiaDAO();

            DanhGia[] dg = new DanhGia[dgO.getDanhGia(email, id).Count];
            dg = dgO.getDanhGia(email, id).ToArray();
            //if (dg.Length == 0)
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            return dg[0];
        }

        // POST: api/DanhGia
        public bool Post([FromBody]DanhGia dg)
        {
            DanhGiaDAO dgO = new DanhGiaDAO();
            return dgO.insertDanhGia(dg);
            //if (dgO.insertDanhGia(dg))
            //{
            //    var response = Request.CreateResponse<DanhGia>(HttpStatusCode.Created, dg);
            //    response.Headers.Location = new System.Uri(Request.RequestUri, "/api/DanhGia?email=" + dg.Email.ToString() + "&id=" + dg.IDAddress.ToString());
            //    return response;
            //}
            //else
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error");
            //}
        }

        // PUT: api/DanhGia/5
        public bool Put([FromBody]DanhGia dg)
        {
            DanhGiaDAO dgO = new DanhGiaDAO();
            return dgO.updateDanhGia(dg);
            //if (dgO.updateDanhGia(dg))
            //{
            //    var response = Request.CreateResponse<DanhGia>(HttpStatusCode.Created, dg);
            //    response.Headers.Location = new System.Uri(Request.RequestUri, "/api/DanhGia?email=" + dg.Email.ToString() + "&id=" + dg.IDAddress.ToString());
            //    return response;
            //}
            //else
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error");
            //}
        }

        // DELETE: api/DanhGia?email=example@gmail.com&id=1217
        public bool Delete(string email, int id)
        {
            DanhGiaDAO dgO = new DanhGiaDAO();
            DanhGia[] dg = new DanhGia[dgO.getDanhGia(email, id).Count];
            dg = dgO.getDanhGia(email, id).ToArray();
            if (dg.Length == 0)
                return false;
            dgO.deleteDanhGia(email, id);
            return true;
        }
    }
}
