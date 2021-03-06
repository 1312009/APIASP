﻿using CityTravelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CityTravelService.Controllers
{
    public class DanhGiaController : ApiController
    {
        public bool Test()
        {
            //if (HttpContext.Current.Session.Count == 0 || HttpContext.Current.Session["UserOnline"] == null)
            //{
            //    return false;
            //}
            return true;
        }
        // GET api/danhgia
        public IEnumerable<DanhGia> Get()
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
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
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            DanhGiaDAO dgO = new DanhGiaDAO();

            return dgO.getDanhGia(madiadiem);
            //if (dg.Length == 0)
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // GET: api/DanhGia?email=example@gmail.com&id=1217
        public DanhGia Get(int IdUser, int id)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            DanhGiaDAO dgO = new DanhGiaDAO();

            DanhGia[] dg = new DanhGia[dgO.getDanhGia(IdUser, id).Count];
            dg = dgO.getDanhGia(IdUser, id).ToArray();
            //if (dg.Length == 0)
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            return dg[0];
        }

        // POST: api/DanhGia
        public bool Post([FromBody]DanhGia dg)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
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
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
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
        public bool Delete(int IdUser, int id)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            DanhGiaDAO dgO = new DanhGiaDAO();
            DanhGia[] dg = new DanhGia[dgO.getDanhGia(IdUser, id).Count];
            dg = dgO.getDanhGia(IdUser, id).ToArray();
            if (dg.Length == 0)
                return false;
            dgO.deleteDanhGia(IdUser, id);
            return true;
        }
    }
}
