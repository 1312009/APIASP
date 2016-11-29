using System.Collections.Generic;
using CityTravelService.Models;
using System.Web.Http;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using System;
using System.Net.Mail;
using System.Configuration;
using CityTravelService.Session;
using System.Web;

namespace CityTravelService.Controllers
{
    [RoutePrefix("api/TaiKhoan")]
    public class TaiKhoanController : ApiController
    {
        public bool Test()
        {
            if (HttpContext.Current.Session.Count == 0 || HttpContext.Current.Session["UserOnline"] == null)
            {
                return false;
            }
            return true;
        }
        #region GET
        // GET: api/TaiKhoan
        [Auth(PerMissionName = "Admin")]
        [Route("")]
        [HttpGet]
        public IEnumerable<TaiKhoan> Get()
        {
            TaiKhoanDAO tkO = new TaiKhoanDAO();
            TaiKhoan[] tk = new TaiKhoan[tkO.getDsTaiKhoan().Count];
            tk = tkO.getDsTaiKhoan().ToArray();
            return tk;
        }
        [Route("Logout")]
        [HttpGet]
        public bool Logout()
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            HttpContext.Current.Session["AccountId"] = null;
            HttpContext.Current.Session["UserOnline"] = null;
            HttpContext.Current.Session["Auth"] = null;
            return true;
        }
        // GET: api/TaiKhoan/5
        [Route("")]
        [HttpGet]
        public TaiKhoan Get(int IdUser)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            TaiKhoanDAO tkO = new TaiKhoanDAO();
            TaiKhoan tk = new TaiKhoan();
            tk =tkO.getTaiKhoan(IdUser);
            //if (tk.Length == 0)
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            return tk;
        }

        // api đăng nhập
        // GET: 
        [Route("")]
        [HttpGet]
        public TaiKhoan Get(string email, string password)
        {
            TaiKhoanDAO tkO = new TaiKhoanDAO();
            TaiKhoan tk;
            tk = tkO.getTaiKhoan(email, password);
            return tk;
        }
        #endregion

        #region POST
        // POST: api/TaiKhoan
        [Route("")]
        [HttpPost]
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
        [Route("")]
        [HttpPut]
        public bool Put([FromBody]TaiKhoan tk)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)); return false;
            }
            TaiKhoanDAO tkO = new TaiKhoanDAO();
            //tkO.updateTaiKhoan(tk);
            /*var response = Request.CreateResponse<TaiKhoan>(HttpStatusCode.Created, tk);
            response.Headers.Location = new System.Uri(Request.RequestUri, "/api/TaiKhoan/" + tk.Email.ToString());*/
            return tkO.updateTaiKhoan(tk);
        }
        [Route("ChangPassword")]
        [HttpPut]
        public bool  ChangPassword(int IdUser,string passwordold,string passwordnew)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            TaiKhoanDAO tk0 = new TaiKhoanDAO();
            return tk0.changePassword(IdUser, passwordold, passwordnew);

        }
        #endregion
        #region DELETE
        // DELETE: api/TaiKhoan/5
        [Route("")]
        [HttpDelete]
        public bool Delete(int id)
        {
            if (Test() == false)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            TaiKhoanDAO tkO = new TaiKhoanDAO();
            TaiKhoan tk = new TaiKhoan();
            tk = tkO.getTaiKhoan(id);
            if (tk == null)
                return false;
            /*throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));*/
            return tkO.deleteTaiKhoan(id); //False: Khi no la khoa ngoại.
        }
        #endregion
        #region
        //FORGETPASSWORD:api/TaiKhoan/Forget
        [Route("Forget")]
        [HttpPut]
        public bool ForegetPassword(string email)
        {
            string temp = CreatePassword();
            MailMessage mailMessag = new MailMessage(ConfigurationManager.AppSettings.Get("Email"), email);
            mailMessag.Subject = "Gửi lại mật khẩu";
            mailMessag.Body = "Mật khẩu mới của bạn là: " + temp;
            SmtpClient client = new SmtpClient();
            client.Send(mailMessag);
            TaiKhoanDAO tkO = new TaiKhoanDAO();
            TaiKhoan tk = new TaiKhoan();
            int id = tkO.getTaiKhoan(email);
            tk = tkO.getTaiKhoan(id);
            if (tk==null)
                return false;
            tkO.updatePassword(temp, id);
            return true;
        }
        public string CreatePassword()
        {
            string _allowedChars = "ABCDEFGHIJKMNOPQRSTUVWXYZ0123456789";

            Random randNum = new Random();

            char[] chars = new char[6];

            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < 6; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
                if (chars[i] == '0' || chars[i] == '1' || chars[i] == '2' || chars[i] == '3' || chars[i] == '4'
              || chars[i] == '5' || chars[i] == '6' || chars[i] == '7' || chars[i] == '8' || chars[i] == '9')
                {
                    _allowedChars = "ABCDEFGHIJKMNOPQRSTUVWXYZ";
                }
            }
            return new string(chars);
        }

        #endregion
    }
}