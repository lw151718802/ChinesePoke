using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MySQLWEB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          DataTable _dt=  RM.MySQLBusines.MySqlDataFactory.MySqlDataBase().ExecuteDataTable("select * from game_user");
        }
    }
}