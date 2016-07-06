using RM.Busines.DAL;
using RM.Busines.IDAO;
using RM.Common.DotNetBean;
using RM.Common.DotNetCode;
using RM.Common.DotNetJson;
using RM.Common.DotNetUI;
using RM.Web.User.Model;
using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
namespace RM.Web.User.Ajax
{
    /// <summary>
    /// islogin 的摘要说明
    /// </summary>
    public class islogin : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";


            result _model = new result();
           

            if (RequestSession.GetSessionZSUser() == null)
            {
                _model.res_code = 0;
                context.Session.Abandon();
                context.Session.Clear();
                
            }

            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(_model));
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}