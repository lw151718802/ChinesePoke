using RM.Busines;
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
    public class checkaccount : HandleBase
    {

       

        public override void AjaxProcess(HttpContext context)
        {
           
            string account = context.Request["account"];

            Hashtable ht = DataFactory.SqlDataBase().GetHashtableById("ZS_User", "Account", account);
            ZS_User _model = new ZS_User();
            if (ht.Count > 0 && ht != null && ht["ISUsed".ToUpper()].ToString()=="1")
            {


                _model.RealName = ht["RealName".ToUpper()].ToString();

            }
            else
            {
                _model.res_code = -101;
                _model.res_msg = "账号不存在或账号异常";
            }
            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(_model));
            context.Response.End();
        }


    }
}