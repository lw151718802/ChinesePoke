using RM.Common.DotNetBean;
using RM.MySQLBusines.DAL;
using RM.MySQLBusines.IDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Poke.ProxyWeb.Ajax
{
    /// <summary>
    /// LoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {


            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";
            string Action = context.Request["action"];
            string user_Account = context.Request["user_Account"];

            user_Account = user_Account.ToUpper();

            string userPwd = context.Request["userPwd"];
            string code = context.Request["code"];
            I_Proxy_DAO user_idao = new Proxy_DAL();
           
            //if (code.ToLower() != context.Session["dt_session_code"].ToString().ToLower())
            //{
            //    context.Response.Write("1");
            //    context.Response.End();
            //}
            DataTable dtlogin = user_idao.UserLogin(user_Account.Trim(), userPwd.Trim());
            if (dtlogin != null)
            {
               
                if (dtlogin.Rows.Count != 0)
                {
                    
                        RequestSession.AddSessionUser(new SessionUser
                        {
                            UserId = dtlogin.Rows[0]["id"].ToString(),
                            UserAccount = dtlogin.Rows[0]["mobile"].ToString(),
                            UserName = dtlogin.Rows[0]["name"].ToString(),
                            UserPwd = dtlogin.Rows[0]["password"].ToString()
                        });
                        context.Response.Write("3");
                        context.Response.End();
                  

                }
                else
                {
                    context.Response.Write("4");
                    context.Response.End();
                }
            }
            else
            {
                context.Response.Write("5");
                context.Response.End();
            }

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