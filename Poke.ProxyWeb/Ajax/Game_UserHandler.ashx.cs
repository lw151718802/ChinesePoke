

using RM.Common.DotNetBean;
using RM.MySQLBusines.DAL;
using RM.MySQLBusines.IDAO;
using System;
using System.Collections;
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
    public class Game_UserHandler : IHttpHandler, IRequiresSessionState
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
     

            string uid = context.Request["uid"];

            Game_User_DAL dal = new Game_User_DAL();

        

            Hashtable _hs = dal.GetGame_User(uid);

            var obj = new { res_code = 1, res_msg = "", Game_User = _hs };

            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
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