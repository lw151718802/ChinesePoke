using RM.Busines.DAL;
using RM.Busines.IDAO;
using RM.Common.DotNetBean;
using RM.Common.DotNetCode;
using RM.Common.DotNetJson;
using RM.Common.DotNetUI;
using System;
using System.Data;
using System.Web;
using System.Web.SessionState;

namespace RM.Web.User.Ajax
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
            string userPwd = context.Request["userPwd"];
            string code = context.Request["code"];
            ZS_User_IDAO user_idao = new ZS_User_Dal();
            IPScanerHelper objScan = new IPScanerHelper();

            if (code.ToLower() != context.Session["dt_session_code"].ToString().ToLower())
            {
                context.Response.Write("1");
                context.Response.End();
            }
            DataTable dtlogin = user_idao.UserLogin(user_Account.Trim(), userPwd.Trim());
            if (dtlogin != null)
            {
                objScan.DataPath = context.Server.MapPath("/Themes/IPScaner/QQWry.Dat");
                objScan.IP = RequestHelper.GetIP();
                string OWNER_address = objScan.IPLocation();
                if (dtlogin.Rows.Count != 0)
                {
                    user_idao.SysLoginLog(user_Account, "1", OWNER_address);
                    RequestSession.AddSessionZSUser(new SessionZSUser
                    {
                        UserId = dtlogin.Rows[0]["ID"].ToString(),
                        UserAccount = dtlogin.Rows[0]["Account"].ToString(),
                        UserName = dtlogin.Rows[0]["RealName"].ToString() + "(" + dtlogin.Rows[0]["Account"].ToString() + ")",
                        UserPwd = dtlogin.Rows[0]["PWDA"].ToString()
                    });
                    context.Response.Write("3");
                    context.Response.End();

                 }
                else
                {
                    user_idao.SysLoginLog(user_Account, "0", OWNER_address);
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