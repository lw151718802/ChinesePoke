

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
    public class ZS_UserMoneyFlow : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {
            var pageindex = Convert.ToInt32(context.Request["pageIndex"]);
            var pageSize = Convert.ToInt32(context.Request["pageSize"]);

            int mtype = Convert.ToInt32(context.Request["t"]);


            ZS_User_IDAO user_idao = new ZS_User_Dal();

            int count = 0;
            StringBuilder SqlWhere = new StringBuilder();
            IList<SqlParam> IList_param = new List<SqlParam>();
            SqlWhere.Append(" and Account = @Account");
            IList_param.Add(new SqlParam("@Account", UserAccount));

            //收入
            if (mtype == 100)
            {
                SqlWhere.Append(" and U_Money > @U_Money");
                IList_param.Add(new SqlParam("@U_Money", 0));
            }
            else if (mtype == 200) //支出
            {
                SqlWhere.Append(" and U_Money < @U_Money");
                IList_param.Add(new SqlParam("@U_Money", 0));
            }
            else if (mtype != 500)
            {
                SqlWhere.Append(" and MoneyType = @MoneyType");
                IList_param.Add(new SqlParam("@MoneyType", mtype));
            }
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
                DataTable dt = user_idao.GetUserMoneyFlowPage(SqlWhere, IList_param, pageindex, pageSize, ref count);

            var obj = new { total = count, items = dt };

            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            context.Response.End();
        }


    }
}