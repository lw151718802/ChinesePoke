using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM.Web.User.Model
{
    [Serializable]
    public class result
    {
        public int res_code=1;
        public string res_msg;

        public DateTime ctime;
    }
}