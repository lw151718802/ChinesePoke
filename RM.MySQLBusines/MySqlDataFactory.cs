using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RM.Common.DotNetConfig;
using RM.MySQL;
namespace RM.MySQLBusines
{
     public class MySqlDataFactory
    {

        public static IDMySqlHelper MySqlDataBase()
        {
            return new MySqlHelper(ConfigHelper.GetAppSettings("MySql_Con"));
        }
    }
}
