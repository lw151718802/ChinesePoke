using MySql.Data.MySqlClient;
using RM.Common.DotNetData;
using RM.Common.DotNetEncrypt;
using RM.MySQLBusines.IDAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RM.MySQLBusines.DAL
{
    public class Notice_DAL : I_Notice_DAO
    {
        public Hashtable GetNotice(int NoticeType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select  * from game_systemnotice where ");
            strSql.Append(" NoticeType=?NoticeType ");
            strSql.Append("order by CreateTime desc");
            MySqlParameter[] para = new MySqlParameter[]
            {
                new MySqlParameter("?NoticeType", NoticeType)
            };

          


            DataTable dt = MySqlDataFactory.MySqlDataBase().ExecuteDataTable(strSql.ToString(), para);
            return DataTableHelper.DataTableToHashtable(dt);
          
        }
    }
}
