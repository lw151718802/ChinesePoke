


using RM.Common.DotNetConfig;
using RM.Common.DotNetEncrypt;
using RM.MySQLBusines;
using RM.MySQLBusines.DAL;
using RM.MySQLBusines.IDAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poke.ProxyWeb.Ajax
{
    /// <summary>
    /// AddUser 的摘要说明
    /// </summary>
    public class ProxyInfoHandler : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {

            string Action = context.Request["action"];
           

            Hashtable ht = MySqlDataFactory.MySqlDataBase().GetHashtableById("game_proxy", "id", UserID);
            if (ht == null || ht.Count == 0)
            {
                res_code = -100;
                res_msg = "网络延时，请刷新";
            }
            var obj = new { res_code = res_code, res_msg = res_msg, proxy = ht };

            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            context.Response.End();



        }


    }
}