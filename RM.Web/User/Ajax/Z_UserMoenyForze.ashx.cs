

using RM.Busines;
using RM.Busines.DAL;
using RM.Busines.IDAO;
using RM.Common.DotNetCode;
using RM.Common.DotNetEncrypt;
using RM.Web.User.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace RM.Web.User.Ajax
{
    /// <summary>
    /// GetUserPage 的摘要说明
    /// </summary>
    public class Z_UserMoenyForze : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {
            var pageindex = Convert.ToInt32(context.Request["pageIndex"]);
            var pageSize = Convert.ToInt32(context.Request["pageSize"]);

            ZS_User_IDAO user_idao = new ZS_User_Dal();

            int count = 0;
            StringBuilder SqlWhere = new StringBuilder();
            IList<SqlParam> IList_param = new List<SqlParam>();
            SqlWhere.Append(" and Account = @Account");
            IList_param.Add(new SqlParam("@Account", UserAccount));
            //if (this.BeginBuilTime.Value != "" || this.endBuilTime.Value != "")
            //{
            //    SqlWhere.Append(" and Sys_LoginLog_Time >= @BeginBuilTime");
            //    SqlWhere.Append(" and Sys_LoginLog_Time <= @endBuilTime");
            //    IList_param.Add(new SqlParam("@BeginBuilTime", CommonHelper.GetDateTime(this.BeginBuilTime.Value)));
            //    IList_param.Add(new SqlParam("@endBuilTime", CommonHelper.GetDateTime(this.endBuilTime.Value).AddDays(1.0)));
            //}
            //if (this.txt_Search.Value != "")
            //{
            //    SqlWhere.Append(" and SYS_USER = @SYS_USER");
            //    IList_param.Add(new SqlParam("@SYS_USER", this.txt_Search.Value));
            //}
            DataTable dt = user_idao.GetZ_UserMoenyForzePage(SqlWhere, IList_param, pageindex, pageSize, ref count);

            var obj = new { total = count, items = dt };

            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            context.Response.End();
        }


    }
}