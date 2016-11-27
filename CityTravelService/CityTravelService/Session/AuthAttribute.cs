using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CityTravelService.Session
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public string PerMissionName { get; set; }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string isOnl = "";
            if (HttpContext.Current.Session["UserOnline"] != null)
            {
                isOnl = HttpContext.Current.Session["UserOnline"].ToString();
            }
            if (isOnl == "On")
            {
                string Auth = (string)HttpContext.Current.Session["Auth"];
                if (PerMissionName == Auth)
                {
                    return true;
                }
            }
            return false;
        }
    }
}