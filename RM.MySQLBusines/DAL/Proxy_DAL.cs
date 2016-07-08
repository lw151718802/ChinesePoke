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


        public DataTable Getgame_proxy_cardlogPage(StringBuilder SqlWhere, IList<MySqlParameter> IList_param, int pageIndex, int pageSize, ref int count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select A.*,B.`name`,B.uid from game_proxy_cardlog A LEFT JOIN game_user B
on A.extend_01 = B.id where 1=1");
            strSql.Append(SqlWhere);
            return MySqlDataFactory.MySqlDataBase().GetPageList(strSql.ToString(), IList_param.ToArray(), "createdatetime", "Desc", pageIndex, pageSize, ref count);
        }

    }
}
