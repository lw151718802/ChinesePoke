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
    /// GetUserInfo 的摘要说明
    /// </summary>
    public class GetUserInfo : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {

            string account = context.Request["account"];

            Hashtable ht = DataFactory.SqlDataBase().GetHashtableById("ZS_User", "Account", account);


          
            ZS_User _model = new ZS_User();
            if (ht.Count > 0 && ht != null )
            {

                //ht["ISUsed".ToUpper()].ToString()
                _model.RealName = ht["RealName".ToUpper()].ToString();
                _model.Account = ht["Account".ToUpper()].ToString();
                _model.RegMoney = int.Parse(ht["RegMoney".ToUpper()].ToString())/10000;
                _model.RegDate = DateTime.Parse(ht["RegDate".ToUpper()].ToString());
                _model.RecMan = ht["RecMan".ToUpper()].ToString();
                _model.Phone = ht["Phone".ToUpper()].ToString();

            }
            else
            {

            }
            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(_model));
            context.Response.End();
        }


    }
}