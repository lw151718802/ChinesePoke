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
    /// checkpwd 的摘要说明
    /// </summary>
    public class checkpwd : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {
            string Action = context.Request["action"];


            string userPwd = context.Request["pwd"];

            result _model = new result();


            SessionZSUser _user = RequestSession.GetSessionZSUser();
            if (_user == null)
            {
                _model.res_code = 0;
                _model.res_msg = "用户未登陆";

            }
            else
            {
                ZS_User_IDAO user_idao = new ZS_User_Dal();

                DataTable dtlogin = user_idao.CheckRePWD(_user.UserAccount.ToString(), userPwd.Trim());

                if (dtlogin == null || dtlogin.Rows.Count == 0)
                {
                    _model.res_code = 0;
                    _model.res_msg = "二级密码不正确";
                }
            }

            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(_model));
            context.Response.End();
        }

     
    }
}