using RM.Common.DotNetConfig;
using RM.Common.DotNetEncrypt;
using RM.MySQLBusines.DAL;
using RM.MySQLBusines.IDAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poke.ProxyWeb.Ajax
{
    /// <summary>
    /// AddUser 的摘要说明
    /// </summary>
    public class NoticeHandle : HandleBase
    {



        public override void AjaxProcess(HttpContext context)
        {
            
            I_Notice_DAO dal = new Notice_DAL();

            object _notice = dal.GetNotice(6);




            context.Response.Clear();
            context.Response.Write(_notice);
            context.Response.End();
        }


    }
}