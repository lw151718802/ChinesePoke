





using RM.Common.DotNetConfig;
using RM.Common.DotNetEncrypt;
using RM.MySQLBusines;
using RM.MySQLBusines.DAL;
using RM.MySQLBusines.IDAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Poke.ProxyWeb.Ajax
{
    /// <summary>
    /// AddUser 的摘要说明
    /// </summary>
    public class Game_UserHandler : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {

            string Action = context.Request["action"];




            string uid = context.Request["uid"];
            Game_User_DAL dal = new Game_User_DAL();
            Hashtable ht = dal.GetGame_User(uid);
            if (ht == null || ht.Count == 0)
            {
                res_code = -100;
                res_msg = "玩家不存在";

                var obj = new { res_code = res_code, res_msg = res_msg };

                context.Response.Clear();
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
                context.Response.End();

            }
            else { 

                if (Action == "charge")
                {
                    int card = int.Parse(context.Request["card"]);
                    Hashtable htproxy = MySqlDataFactory.MySqlDataBase().GetHashtableById("game_proxy", "id", UserID);
                    int cardcount = int.Parse(htproxy["card"].ToString());

                    if (cardcount < card)
                    {
                        res_code = -100;
                        res_msg = "可用卡数量不足";
                    }
                    else {

                        addCard(card, uid, ht["id"].ToString(), ht["name"].ToString(),cardcount,int.Parse(ht["card"].ToString()));

                    }

                    var obj = new { res_code = res_code, res_msg = res_msg,card=(cardcount- card) };

                    context.Response.Clear();
                    context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
                    context.Response.End();
                }   
                else
                { 
               

               
                    var obj = new { res_code = res_code, res_msg = res_msg, gameuser = ht };

                    context.Response.Clear();
                    context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
                    context.Response.End();
                }

            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private bool addCard(int card,string uid,string gameuserid,string username,int totalcard,int gameusercardcount)
        {
            string sql1 = "insert into game_proxy_cardlog(proxyid,card,cardremark,cardtype,createdatetime,extend_01) values(" + UserID + "," + (-card) + ",'',2,now(),'"+ gameuserid + "')";
            string sql2 = "insert into game_user_log(userid,card,proxyid,logdate) values(" + uid + "," + (card) + ","+ UserID + ",now())";
            string sql3 = "update game_proxy set card =" + (totalcard - card) + "  where id=" + UserID ;
            string sql4 = "update game_user set card =" + (gameusercardcount + card) + "  where id=" + gameuserid;
            List<string> list = new List<string>();
            list.Add(sql1);
            list.Add(sql2);
            list.Add(sql3);
            list.Add(sql4);
            MySqlDataFactory.MySqlDataBase().ExecuteNoQueryTran(list);

            return false;
        }


    }
}