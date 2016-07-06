using MySql.Data.MySqlClient;
using RM.Common.DotNetEncrypt;
using RM.MySQLBusines.IDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.MySQLBusines.DAL
{
    public  class Proxy_DAL: I_Proxy_DAO
    {
        public DataTable UserLogin(string name, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from game_proxy where ");
            strSql.Append("mobile=?User_Account ");
            strSql.Append("and password=?User_Pwd ");
            strSql.Append("and deleteflag = 1 ");
            MySqlParameter[] para = new MySqlParameter[]
            {
                new MySqlParameter("?User_Account", name),
                 new MySqlParameter("?User_Pwd", pwd)
              //  new MySqlParameter("?User_Pwd", Md5Helper.MD5(pwd, 32))
            };
            return MySqlDataFactory.MySqlDataBase().ExecuteDataTable(strSql.ToString(), para);
        }
    }
}
