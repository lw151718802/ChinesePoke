

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
    /// checkaccount 的摘要说明
    /// </summary>
    public class AddTrans : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {
            ZS_User_IDAO user_idao = new ZS_User_Dal();

            string loginpwd = context.Request["loginpwd"];
            string recaccount = context.Request["recaccount"];
            string tomoney = context.Request["tomoney"];


            Hashtable ht = new Hashtable();


            ht["Account"] = UserAccount;
            ht["RecAccount "] = recaccount;
            ht["Tomoney"] = decimal.Parse(tomoney);
            ht["LoginPwd"] = Md5Helper.MD5(loginpwd, 32);
            ht["OUT_Code"] = "";
            ht["OUT_Msg"] = "";


            Hashtable refht = new Hashtable();
            user_idao.AddPR_TransfByProc(ht, ref refht);

            result _model = new result();
            if (refht["OUT_Code"].ToString() != "200")
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