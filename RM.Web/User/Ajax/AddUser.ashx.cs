using RM.Busines;
using RM.Busines.DAL;
using RM.Busines.IDAO;
using RM.Common.DotNetEncrypt;
using RM.Web.User.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM.Web.User.Ajax
{
    /// <summary>
    /// AddUser 的摘要说明
    /// </summary>
    public class AddUser : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {
            string buymoney = context.Request["buymoney"];
            string realname = context.Request["realname"];
            string idno = context.Request["idno"];
            string bankname = context.Request["bankname"];
            string bankaddress = context.Request["bankaddress"];
            string bankcardno = context.Request["bankcardno"];
            string email = context.Request["email"];
            string phone = context.Request["phone"];
            string recman = UserAccount;
           
            ZS_User_IDAO user_idao = new ZS_User_Dal();
            Hashtable ht = new Hashtable();

          
            ht["StudioMan"] = UserAccount;
            ht["RecMan"] = recman;
            ht["RealName"] = realname;
            ht["Phone"] = phone;

            ht["PWDA"] = Md5Helper.MD5("123456", 32);
            ht["PWDB"] = Md5Helper.MD5("123456", 32);
            ht["RegMoney"] = int.Parse(buymoney) * 10000;
            ht["UserType"] = 1;
            ht["Email"] = email;
            ht["BankName"] = bankname;
            ht["BankAddress"] = bankaddress;
            ht["BankCardNO"] = bankcardno;
            ht["IDNO"] = idno;

            ht["OUT_UserAccount"] = "";
            ht["OUT_Code"] = "";
            ht["OUT_Msg"] = "";


            Hashtable refht = new Hashtable();
            user_idao.AddUserByProc(ht, ref refht);










            //   Hashtable ht = DataFactory.SqlDataBase().GetHashtableById("ZS_User", "Account", account);
            ZS_User _model = new ZS_User();
            if (refht["OUT_Code"].ToString() == "200")
            {
                _model.Account = refht["OUT_UserAccount"].ToString();
            }
            else
            {
                _model.res_code = -101;
                _model.res_msg = refht["OUT_Msg"].ToString();
            }



            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(_model));
            context.Response.End();
        }


    }
}