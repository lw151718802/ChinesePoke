
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using RM.Busines.DAL;
using RM.Busines.IDAO;
using RM.Common.DotNetBean;
using RM.Common.DotNetCode;
using RM.Common.DotNetUI;

namespace RM.Web.App_Code
{
    public class UserPageBase : Page
    {
     
        protected override void OnLoad(EventArgs e)
        {
            if (RequestSession.GetSessionZSUser() == null)
            {
      
              

                Response.Write("<script>parent.document.location.href='/User/login.html';</script>");
            }
            if (null == this.Session["Token"])
            {
                WebHelper.SetToken();
            }
        
            base.OnLoad(e);
        }
      

    }
}