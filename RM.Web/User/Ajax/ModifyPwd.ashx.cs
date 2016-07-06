

using RM.Busines;
using RM.Busines.DAL;
using RM.Busines.IDAO;
using RM.Common.DotNetBean;
using RM.Common.DotNetEncrypt;
using RM.Web.User.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RM.Web.User.Ajax
{
    /// <summary>
    /// UserMoenyInfo 的摘要说明
    /// </summary>
    public class ModifyPwd : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {


            ZS_User_IDAO user_idao = new ZS_User_Dal();
            string action = context.Request["ac"];
            string pwda = context.Request["pwda"];
            string pwdb = context.Request["pwdb"].ToString().Trim();
            string pwdc = context.Request["pwdc"].ToString().Trim();
            result _model = new result();
            if (pwdb != pwdc)
            {
                _model.res_code = -101;
                _model.res_msg = "确认密码不一致";
                context.Response.Clear();
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(_model));
                context.Response.End();

            }



            if (action == "pwda")
            {


                Hashtable htuser = DataFactory.SqlDataBase().GetHashtableById("ZS_User", "Account", UserAccount);

                if (htuser["PWDA"].ToString() != Md5Helper.MD5(pwda, 32))
                {
                    _model.res_code = -101;
                    _model.res_msg = "原登录密码不正确！";
                }
                else
                {
                    Hashtable htU = new Hashtable();
                    htU["PWDA"] = Md5Helper.MD5(pwdb, 32);
                   

                    bool IsOk = DataFactory.SqlDataBase().Submit_AddOrEdit("ZS_User", "Account", UserAccount, htU);

                    if (IsOk)
                    {
                       
                        _model.res_msg = "登录密码修改成功！";
                    }
                    else
                    {
                        _model.res_code = -101;
                        _model.res_msg = "登录密码修改失败！";
                    }
                }
               


            }
            else if (action == "pwdb")
            {

                Hashtable htuser = DataFactory.SqlDataBase().GetHashtableById("ZS_User", "Account", UserAccount);

                if (htuser["PWDB"].ToString() != Md5Helper.MD5(pwda, 32))
                {
                    _model.res_code = -101;
                    _model.res_msg = "原二级密码不正确！";
                }
                else
                {
                    Hashtable htU = new Hashtable();
                    htU["PWDB"] = Md5Helper.MD5(pwdb, 32);


                    bool IsOk = DataFactory.SqlDataBase().Submit_AddOrEdit("ZS_User", "Account", UserAccount, htU);

                    if (IsOk)
                    {

                        _model.res_msg = "二级密码修改成功！";
                    }
                    else
                    {
                        _model.res_code = -101;
                        _model.res_msg = "二级密码修改失败！";
                    }
                }
              


            }
            RequestSession.AddSessionZSUser(null);
            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(_model));
            context.Response.End();


        }


    }
}