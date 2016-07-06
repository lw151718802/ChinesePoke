using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.MySQL
{
    public interface  IDMySqlHelper
    {
        int ExecuteNonQuery(string SQLString);
      
        int ExecuteNonQuery(string SQLString, params MySqlParameter[] cmdParms);
        bool ExecuteNoQueryTran(List<String> SQLStringList);
        object ExecuteScalar(string SQLString);
        object ExecuteScalar(string SQLString, params MySqlParameter[] cmdParms);
        MySqlDataReader ExecuteReader(string strSQL);
        MySqlDataReader ExecuteReader(string SQLString, params MySqlParameter[] cmdParms);
        DataTable ExecuteDataTable(string SQLString);
        DataTable ExecuteDataTable(string SQLString, params MySqlParameter[] cmdParms);
        DataTable ExecuteDataTable(string cmdText, int startResord, int maxRecord);
        DataTable getPager(out int recordCount, string selectList, string tableName, string whereStr, string orderExpression, int pageIdex, int pageSize);


    }
}
