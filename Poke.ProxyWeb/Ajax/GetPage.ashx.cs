



using MySql.Data.MySqlClient;
using RM.Common.DotNetCode;
using RM.Common.DotNetEncrypt;
using RM.Common.DotNetJson;
using RM.MySQLBusines;
using RM.MySQLBusines.DAL;
using RM.MySQLBusines.IDAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Poke.ProxyWeb.Ajax
{
    /// <summary>
    /// GetUserPage 的摘要说明
    /// </summary>
    public class GetPage : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {
            var pageindex = Convert.ToInt32(context.Request["pageIndex"]);
            var pageSize = Convert.ToInt32(context.Request["pageSize"]);

           

            var datemin = context.Request["datemin"];
            var datemax = context.Request["datemax"];
            var uid = context.Request["uid"];

            I_Proxy_DAO user_idao = new Proxy_DAL();

            int count = 0;
            StringBuilder SqlWhere = new StringBuilder();
            IList<MySqlParameter> IList_param = new List<MySqlParameter>();
            SqlWhere.Append(" and cardtype = 2");
            SqlWhere.Append(" and proxyid = ?proxyid");
            IList_param.Add(new MySqlParameter("@proxyid", UserID));
            if (datemin != "" || datemax != "")
            {
                SqlWhere.Append(" and createdatetime >= ?BeginBuilTime");
                SqlWhere.Append(" and createdatetime <= ?endBuilTime");
                IList_param.Add(new MySqlParameter("?BeginBuilTime", CommonHelper.GetDateTime(datemin.ToString())));
                IList_param.Add(new MySqlParameter("?endBuilTime", CommonHelper.GetDateTime(datemax.ToString()).AddDays(1.0)));
            }
            if (uid != "")
            {
                SqlWhere.Append(" and uid = ?uid");
                IList_param.Add(new MySqlParameter("?uid", uid));
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select SUM(A.card) from game_proxy_cardlog A LEFT JOIN game_user B
on A.extend_01 = B.id where 1=1");
            strSql.Append(SqlWhere);

            var _o = MySqlDataFactory.MySqlDataBase().ExecuteScalar(strSql.ToString(), IList_param.ToArray());

            DataTable dt = user_idao.Getgame_proxy_cardlogPage(SqlWhere, IList_param, pageindex, pageSize, ref count);
            string s = JsonHelper.ToJson(dt, Encoding.UTF8);
            var obj = new { total = count, items = dt,sumcard=_o };

            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            context.Response.End();
        }


    }
}