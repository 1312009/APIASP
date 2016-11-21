using System.Collections.Generic;
using CityTravelService.Models;
using System.Web.Http;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using System;

namespace CityTravelService.Controllers
{
    public class TaiKhoanController : ApiController
    {
        #region GET
        // GET: api/TaiKhoan
        public IEnumerable<TaiKhoan> Get()
        {
            TaiKhoanDAO tkO = new TaiKhoanDAO();

            TaiKhoan[] tk = new TaiKhoan[tkO.getDsTaiKhoan().Count];
            tk = tkO.getDsTaiKhoan().ToArray();
            return tk;
        }

        // GET: api/TaiKhoan/5
        public IEnumerable<TaiKhoan> Get(string id)
        {
            TaiKhoanDAO tkO = new TaiKhoanDAO();

            TaiKhoan[] tk = new TaiKhoan[tkO.getDsTaiKhoan(id).Count];
            tk = tkO.getDsTaiKhoan(id).ToArray();
            if (tk.Length == 0)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            return tk;
        }

        // api đăng nhập
        // GET: 
        public HttpResponseMessage Get(string email, string password)
        {
            TaiKhoanDAO tkO = new TaiKhoanDAO();

            TaiKhoan[] tk = new TaiKhoan[tkO.getDsTaiKhoan(email).Count];
            tk = tkO.getDsTaiKhoan(email).ToArray();
            if (tk.Length == 0)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            if (tk[0].MatKhau == password)
            {
                var response = Request.CreateResponse<bool>(HttpStatusCode.Created, true);
                return response;
            }
            else
            {
                var response = Request.CreateResponse<bool>(HttpStatusCode.Created, false);
                return response;
            }
           
          
        }
        #endregion

        #region POST
        // POST: api/TaiKhoan
        public bool Post([FromBody]TaiKhoan tk)
        {
            TaiKhoanDAO tkO = new TaiKhoanDAO();
            //tkO.insertTaiKhoan(tk);
            /*var response = Request.CreateResponse<TaiKhoan>(HttpStatusCode.Created, tk);
            response.Headers.Location = new System.Uri(Request.RequestUri, "/api/TaiKhoan/" + tk.Email.ToString());*/
            return tkO.insertTaiKhoan(tk);
        }
        #endregion

        #region PUT
        // PUT: api/TaiKhoan/5
        public bool Put([FromBody]TaiKhoan tk)
        {
            TaiKhoanDAO tkO = new TaiKhoanDAO();
            //tkO.updateTaiKhoan(tk);
            /*var response = Request.CreateResponse<TaiKhoan>(HttpStatusCode.Created, tk);
            response.Headers.Location = new System.Uri(Request.RequestUri, "/api/TaiKhoan/" + tk.Email.ToString());*/
            return tkO.updateTaiKhoan(tk);
        }
        #endregion

        #region DELETE
        // DELETE: api/TaiKhoan/5
        public bool Delete(string id)
        {
            TaiKhoanDAO tkO = new TaiKhoanDAO();
            TaiKhoan[] tk = new TaiKhoan[tkO.getDsTaiKhoan(id).Count];
            tk = tkO.getDsTaiKhoan(id).ToArray();
            if (tk.Length == 0)
                return false;
            /*throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));*/
            tkO.deleteTaiKhoan(id);
            return true;
        }
        #endregion
    }
}