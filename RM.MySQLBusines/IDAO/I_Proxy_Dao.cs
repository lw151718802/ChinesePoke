using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.MySQLBusines.IDAO
{
    public interface I_Proxy_DAO
    {
        DataTable UserLogin(string name, string pwd);

        DataTable Getgame_proxy_cardlogPage(StringBuilder SqlWhere, IList<MySqlParameter> IList_param, int pageIndex, int pageSize, ref int count);
    }
}
