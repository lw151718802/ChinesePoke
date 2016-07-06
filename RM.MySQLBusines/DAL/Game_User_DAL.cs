using RM.Common.DotNetData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.MySQLBusines.DAL
{
    public class Game_User_DAL
    {
        public Hashtable GetGame_User(string uid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from game_user where uid='" + uid + "'");

            DataTable dt = MySqlDataFactory.MySqlDataBase().ExecuteDataTable(strSql.ToString());
            return DataTableHelper.DataTableToHashtable(dt);
        }
    }
}
