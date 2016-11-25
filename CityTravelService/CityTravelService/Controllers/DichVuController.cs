﻿using System;
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
        // GET: api/DichVu
        public IEnumerable<DichVu> Get()
        {
            DichVuDAO ddO = new DichVuDAO();

            DichVu[] dd = new DichVu[ddO.getDsDichVu().Count];
            dd = ddO.getDsDichVu().ToArray();
            return dd;
        }

        // GET: api/DichVu/5
        public IEnumerable<DichVu> Get(int id)
        {
            DichVuDAO ddO = new DichVuDAO();

            DichVu[] dd = new DichVu[ddO.getDsDichVu(id).Count];
            dd = ddO.getDsDichVu(id).ToArray();
            if (dd.Length == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return dd;
        }

        // POST: api/DichVu
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
        public void Put([FromBody]DichVu dd)
        {
            DichVuDAO dd0 = new DichVuDAO();
            dd0.updateDichVu(dd);
        }

        // DELETE: api/DichVu/5
        public void Delete(int id)
        {
            DichVuDAO dd0 = new DichVuDAO();
            dd0.deleteDichVu(id);
        }
    }
}
