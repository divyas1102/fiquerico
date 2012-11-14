using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FiqueRico.BL.FB
{
    public class FacebookLogin : IHttpHandler 
    {
        public void ProcessRequest(HttpContext context)
        {
            var accessToken = context.Request["accessToken"];
            context.Session["AccessToken"] = accessToken;

            context.Response.Redirect("/MyUrlHere");
        }

        public bool IsReusable
        {
            get { return false; }
        }

    }
}
