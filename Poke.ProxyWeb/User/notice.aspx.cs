using RM.MySQLBusines;
using RM.MySQLBusines.DAL;
using RM.MySQLBusines.IDAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Poke.ProxyWeb.User
{
    public partial class notice : System.Web.UI.Page
    {

        protected string title;
        protected string time;
        protected string content;
        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (!base.IsPostBack)
            {
                this.InitData();
            }

        }

        private void InitData()
        {
            I_Notice_DAO dal = new Notice_DAL();

            Hashtable ht = dal.GetNotice(6);

            if (ht.Count > 0 && ht != null)
            {
                title = ht["NoticeTitle"].ToString();
                time = ht["CreateTime"].ToString();
                content = ht["NoticeContent"].ToString();



            }
        }


    }
}