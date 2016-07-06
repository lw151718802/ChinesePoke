


using RM.Busines;
using RM.Busines.DAL;
using RM.Busines.IDAO;
using RM.Common.DotNetEncrypt;
using RM.Web.User.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RM.Web.User.Ajax
{
    /// <summary>
    /// checkaccount 的摘要说明
    /// </summary>
    public class GetUserStatDetail : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {
            ZS_User_IDAO user_idao = new ZS_User_Dal();

            DataSet ds = user_idao.GetDataSetPR_UserBaseStat(UserAccount);



            var obj = new { lgininfo = ds.Tables[0], relname = UserName,t1 = ds.Tables[1],t2 = ds.Tables[2],t3 = ds.Tables[3] };
          
           

            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            context.Response.End();
        }


    }
}