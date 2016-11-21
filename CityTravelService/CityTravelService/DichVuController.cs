using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CityTravelService.Models;
using CityTravelService.Entity;

namespace CityTravelService.Controllers
{
    public class DichVuController : ApiController
    {
        // GET: api/DichVu
        public IEnumerable<DICHVU> Get()
        {
            DichVuDAO dvO = new DichVuDAO();

            DICHVU[] dv = new DICHVU[dvO.getDsDichVu().Count];
            dv = dvO.getDsDichVu().ToArray();
            return dv;
        }

        // GET: api/DichVu/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DichVu
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DichVu/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DichVu/5
        public void Delete(int id)
        {
        }
    }
}
