using CityTravelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CityTravelService.Controllers
{
    [RoutePrefix("api/ChiTietDichVu")]
    public class ChiTietDichVuController : ApiController
    {

        ChiTietDichVuDAO ChiTiet_DichVu;
        public bool Test()
        {
            //if (HttpContext.Current.Session.Count == 0 || HttpContext.Current.Session["UserOnline"] == null)
            //{
            //    return false;
            //}
            return true;
        }
        // GET api/chitietdulieu
        [Route("")]
        [HttpGet]
        public IEnumerable<ChiTietDichVu> Get_All_DanhSach_DichVu()
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            ChiTiet_DichVu = new ChiTietDichVuDAO();
            ChiTietDichVu[] chitiet = new ChiTietDichVu[ChiTiet_DichVu.get_All_ChiTiet_DichVu().Count];
            chitiet = ChiTiet_DichVu.get_All_ChiTiet_DichVu().ToArray();
            if (chitiet.Length == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return chitiet;
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<ChiTietDichVu> Get_DanhSach_DichVu(int ma_dulieu)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            ChiTiet_DichVu = new ChiTietDichVuDAO();
            ChiTietDichVu[] chitiet = new ChiTietDichVu[ChiTiet_DichVu.get_ChiTiet_DichVu(ma_dulieu).Count];
            chitiet = ChiTiet_DichVu.get_ChiTiet_DichVu(ma_dulieu).ToArray();
            if (chitiet.Length == 0)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return chitiet;
        }
      
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]ChiTietDichVu value)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            ChiTiet_DichVu = new ChiTietDichVuDAO();
            bool ret = ChiTiet_DichVu.insert_ChiTiet_DichVu(value);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, ret);
            return response;
        }

        // PUT api/chitietdulieu/5
        [Route("")]
        [HttpPut]
        public HttpResponseMessage Put(int ma_dulieu, [FromBody]ChiTietDichVu value)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            ChiTiet_DichVu = new ChiTietDichVuDAO();
            bool ret = ChiTiet_DichVu.update_ChiTiet_DichVu(value);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, ret);
            return response;
        }

        // DELETE api/chitietdulieu/5
        [Route("")]
        [HttpDelete]
        public HttpResponseMessage Delete(int ma_dulieu, [FromBody]ChiTietDichVu value)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            ChiTiet_DichVu = new ChiTietDichVuDAO();
            bool ret = ChiTiet_DichVu.delete_ChiTiet_DichVu(value);
            var response = Request.CreateResponse<bool>(HttpStatusCode.Created, ret);
            return response;
        }
    }
}
