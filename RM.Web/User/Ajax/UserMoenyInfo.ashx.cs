using RM.Busines;
using RM.Busines.DAL;
using RM.Busines.IDAO;
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
    public class UserMoenyInfo : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {

   


            ZS_User_IDAO user_idao = new ZS_User_Dal();

            StringBuilder sql1 = new StringBuilder("select ISNULL(sum(U_Money),0) from  ZS_UserMoneyFlow where Account='" + UserAccount + "'");

            decimal moeny1 = user_idao.GetUserMoeny(sql1);

            StringBuilder sql2 = new StringBuilder("select ISNULL( sum(DrawSumMoney),0)  from ZS_UserDraw  where  DrawStatus = 0  and  Account='" + UserAccount + "'");

            decimal moeny2 = user_idao.GetUserMoeny(sql2);

            decimal money = moeny1 - moeny2;
            if (money < 0) money = 0;



            UserMoeny _model = new UserMoeny();
            _model.Account = UserAccount;
            _model.UserMoney = money;

            context.Response.Clear();
            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(_model));
            context.Response.End();
        }


    }
}