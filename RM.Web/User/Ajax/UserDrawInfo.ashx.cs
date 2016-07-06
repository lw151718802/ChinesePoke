using RM.Busines;
using RM.Busines.DAL;
using RM.Busines.IDAO;
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
    public class UserDrawInfo : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {


            ZS_User_IDAO user_idao = new ZS_User_Dal();
            string action = context.Request["ac"];

            if (action == "info")
            {
                StringBuilder sql1 = new StringBuilder("select ISNULL(sum(U_Money),0) from  ZS_UserMoneyFlow where Account='" + UserAccount + "'");

                decimal moeny1 = user_idao.GetUserMoeny(sql1);

                StringBuilder sql2 = new StringBuilder("select ISNULL( sum(DrawSumMoney),0)  from ZS_UserDraw  where  DrawStatus = 0  and  Account='" + UserAccount + "'");

                decimal moeny2 = user_idao.GetUserMoeny(sql2);

                decimal money = moeny1 - moeny2;
                if (money < 0) money = 0;

                Hashtable ht = user_idao.GetZS_UserBankInfo(UserAccount);
                Hashtable htRate = DataFactory.SqlDataBase().GetHashtableById("ZS_Config", "RateKey", "DRAW");

                var obj = new
                {
                    res_code = 1,
                    Account = UserAccount,
                    Money = money,
                    RealName = ht["RealName".ToUpper()],
                    BankName = ht["BankName".ToUpper()],
                    BankAddress = ht["BankAddress".ToUpper()],
                    BankCardNO = ht["BankCardNO".ToUpper()],
                    Rate = htRate["Rate".ToUpper()]
                };
                context.Response.Clear();
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
                context.Response.End();
            }
            else if (action == "add")
            {

                string loginpwd = context.Request["loginpwd"];
                string RealName = context.Request["RealName"];
                string DrawSumMoney = context.Request["DrawSumMoney"];
                string bankname = context.Request["bankname"];
                string bankaddress = context.Request["bankaddress"];
                string bankcardno = context.Request["bankcardno"];



                Hashtable ht = new Hashtable();


                ht["Account"] = UserAccount;
                ht["BankName"] = bankname;
                ht["BandAddress"] = bankaddress;
                ht["BandCardNO"] = bankcardno;
                ht["RealName"] = RealName;
                ht["DrawSumMoney"] = decimal.Parse(DrawSumMoney);
                ht["LoginPwd"] = Md5Helper.MD5(loginpwd, 32);

                ht["OUT_Code"] = "";
                ht["OUT_Msg"] = "";


                Hashtable refht = new Hashtable();
                user_idao.AddUserDrawByProc(ht, ref refht);

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
            else if (action == "back")
            {
                string id = context.Request["id"];
                Hashtable htRate = DataFactory.SqlDataBase().GetHashtableById("ZS_UserDraw", "ID", id);
                result _model = new result();
                if (htRate == null || htRate.Count == 0)
                {
                    _model.res_code = -101;
                    _model.res_msg = "该提现记录不存在！";
                }
                else if (htRate["DrawStatus".ToUpper()].ToString() != "0" || htRate["Account".ToUpper()].ToString() != UserAccount)
                {
                    _model.res_code = -101;
                    _model.res_msg = "该提现不能被撤销！";
                }
                else 
                {
                    DateTime now = System.DateTime.Now;
                    Hashtable ht = new Hashtable();
                    ht["DrawStatus"] = 4;
                    ht["DrawStatusDesc"] = "撤销";
                    ht["DrawOverTime"] = now;
                    
                    bool IsOk = DataFactory.SqlDataBase().Submit_AddOrEdit("ZS_UserDraw", "ID", id, ht);

                    if (IsOk)
                    {
                        _model.ctime = DateTime.Parse(now.ToShortTimeString());
                        _model.res_msg = "撤销成功！";
                    }
                    else
                    {
                        _model.res_code = -101;
                        _model.res_msg = "撤销失败！";
                    }
                }

                context.Response.Clear();
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(_model));
                context.Response.End();

            }

            context.Response.Clear();
            context.Response.Write("");
            context.Response.End();

        }


    }
}