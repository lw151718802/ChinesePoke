﻿

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using RM.MySQL;
using System.Text;
using RM.Common.DotNetData;

namespace RM.MySQL
{
    public class MySqlHelper: IDMySqlHelper
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库. 
        // public  string connectionString = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString; 
        public  string connectionString="";
        //public string m = ConfigurationManager.AppSettings["MySQL"]; 
        public MySqlHelper(string connString) {
            this.connectionString = connString;
        }

        public Hashtable GetHashtableById(string tableName, string pkName, string pkVal)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * From ").Append(tableName).Append(" Where ").Append(pkName).Append("=?ID");
            DataTable dt = this.ExecuteDataTable(sb.ToString(), new MySqlParameter[]
            {
                new MySqlParameter("?ID", pkVal)
            });
            return DataTableHelper.DataTableToHashtable(dt);
        }
        #region ExecuteNonQuery 
        //执行SQL语句，返回影响的记录数 
        /// <summary> 
        /// 执行SQL语句，返回影响的记录数 
        /// </summary> 
        /// <param name="SQLString">SQL语句</param> 
        /// <returns>影响的记录数</returns> 
        public  int ExecuteNonQuery(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        /// <summary> 
        /// 执行SQL语句，返回影响的记录数 
        /// </summary> 
        /// <param name="SQLString">SQL语句</param> 
        /// <returns>影响的记录数</returns> 
        public  int ExecuteNonQuery(string SQLString, params MySqlParameter[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        //执行多条SQL语句，实现数据库事务。 
        /// <summary> 
        /// 执行多条SQL语句，实现数据库事务。 
        /// </summary> 
        /// <param name="SQLStringList">多条SQL语句</param> 
        public  bool ExecuteNoQueryTran(List<String> SQLStringList)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            PrepareCommand(cmd, conn, tx, strsql, null);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    return true;
                }
                catch
                {
                    tx.Rollback();
                    return false;
                }
            }
        }
        #endregion
        #region ExecuteScalar 
        /// <summary> 
        /// 执行一条计算查询结果语句，返回查询结果（object）。 
        /// </summary> 
        /// <param name="SQLString">计算查询结果语句</param> 
        /// <returns>查询结果（object）</returns> 
        public  object ExecuteScalar(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }


        /// <summary> 
        /// 执行一条计算查询结果语句，返回查询结果（object）。 
        /// </summary> 
        /// <param name="SQLString">计算查询结果语句</param> 
        /// <returns>查询结果（object）</returns> 
        public  object ExecuteScalar(string SQLString, params MySqlParameter[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        throw e;
                    }
                }
            }
        }


        /// <summary> 
        /// 执行一条计算查询结果语句，返回查询结果（object）。 
        /// </summary> 
        /// <param name="SQLString">计算查询结果语句</param> 
        /// <returns>查询结果（object）</returns> 
        public object ExecuteScalar(StringBuilder SQLString, params MySqlParameter[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString.ToString(), cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        #endregion
        #region ExecuteReader 
        /// <summary> 
        /// 执行查询语句，返回MySqlDataReader ( 注意：调用该方法后，一定要对MySqlDataReader进行Close ) 
        /// </summary> 
        /// <param name="strSQL">查询语句</param> 
        /// <returns>MySqlDataReader</returns> 
        public  MySqlDataReader ExecuteReader(string strSQL)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                MySqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                throw e;
            }
        }
        /// <summary> 
        /// 执行查询语句，返回MySqlDataReader ( 注意：调用该方法后，一定要对MySqlDataReader进行Close ) 
        /// </summary> 
        /// <param name="strSQL">查询语句</param> 
        /// <returns>MySqlDataReader</returns> 
        public  MySqlDataReader ExecuteReader(string SQLString, params MySqlParameter[] cmdParms)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                MySqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                throw e;
            }
            // finally 
            // { 
            // cmd.Dispose(); 
            // connection.Close(); 
            // } 
        }
        #endregion
        #region ExecuteDataTable 
        /// <summary> 
        /// 执行查询语句，返回DataTable 
        /// </summary> 
        /// <param name="SQLString">查询语句</param> 
        /// <returns>DataTable</returns> 
        public  DataTable ExecuteDataTable(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }
        /// <summary> 
        /// 执行查询语句，返回DataSet 
        /// </summary> 
        /// <param name="SQLString">查询语句</param> 
        /// <returns>DataTable</returns> 
        public  DataTable ExecuteDataTable(string SQLString, params MySqlParameter[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds.Tables[0];
                }
            }
        }
        //获取起始页码和结束页码 
        public  DataTable ExecuteDataTable(string cmdText, int startResord, int maxRecord)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(cmdText, connection);
                    command.Fill(ds, startResord, maxRecord, "ds");
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds.Tables[0];
            }
        }
        #endregion
        /// <summary> 
        /// 获取分页数据 在不用存储过程情况下 
        /// </summary> 
        /// <param name="recordCount">总记录条数</param> 
        /// <param name="selectList">选择的列逗号隔开,支持top num</param> 
        /// <param name="tableName">表名字</param> 
        /// <param name="whereStr">条件字符 必须前加 and</param> 
        /// <param name="orderExpression">排序 例如 ID</param> 
        /// <param name="pageIdex">当前索引页</param> 
        /// <param name="pageSize">每页记录数</param> 
        /// <returns></returns> 
        public  DataTable getPager(out int recordCount, string selectList, string tableName, string whereStr, string orderExpression, int pageIdex, int pageSize)
        {
            int rows = 0;
            DataTable dt = new DataTable();
            MatchCollection matchs = Regex.Matches(selectList, @"top\s+\d{1,}", RegexOptions.IgnoreCase);//含有top 
            string sqlStr = sqlStr = string.Format("select {0} from {1} where 1=1 {2}", selectList, tableName, whereStr);
            if (!string.IsNullOrEmpty(orderExpression)) { sqlStr += string.Format(" Order by {0}", orderExpression); }
            if (matchs.Count > 0) //含有top的时候 
            {
                DataTable dtTemp = ExecuteDataTable(sqlStr);
                rows = dtTemp.Rows.Count;
            }
            else //不含有top的时候 
            {
                string sqlCount = string.Format("select count(*) from {0} where 1=1 {1} ", tableName, whereStr);
                //获取行数 
                object obj = ExecuteScalar(sqlCount);
                if (obj != null)
                {
                    rows = Convert.ToInt32(obj);
                }
            }
            dt = ExecuteDataTable(sqlStr, (pageIdex - 1) * pageSize, pageSize);
            recordCount = rows;
            return dt;
        }


        public DataTable GetPageList(string sql, MySqlParameter[] param, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            StringBuilder sb = new StringBuilder();
            DataTable result;
            try
            {
                int num = (pageIndex - 1) * pageSize;
                int num2 =  pageSize;
                sb.Append(string.Concat(new object[]
                {
                   
                    sql,
                   " Order By " + orderField + " " + orderType,
                    " LIMIT ",
                    num +" ,",
                    num2
                }));

                count = Convert.ToInt32(this.ExecuteScalar(new StringBuilder("Select Count(1) From (" + sql + ") As t"), param));
                result = this.ExecuteDataTable(sb.ToString(), param);
            }
            catch (Exception e)
            {
                //this.Logger.WriteLog(string.Concat(new string[]
                //{
                //    "-----------数据分页（Oracle）-----------\r\n",
                //    sb.ToString(),
                //    "\r\n",
                //    e.Message,
                //    "\r\n"
                //}));
                result = null;
            }
            return result;
        }

        //public MySqlTransaction GetDatabase()
        //{
        //    SqlDatabase result;
        //    if (this.db == null)
        //    {
        //        if (ConfigHelper.GetAppSettings("ConStringEncrypt") == "true")
        //        {
        //            this.db = new SqlDatabase(DESEncrypt.Decrypt(this.connectionString));
        //        }
        //        else
        //        {
        //            this.db = new SqlDatabase(this.connectionString);
        //        }
        //        result = this.db;
        //    }
        //    else
        //    {
        //        lock (SqlServerHelper.locker)
        //        {
        //            result = this.db;
        //        }
        //    }
        //    return result;
        //}


        #region 创建command 
        private  void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType; 
            if (cmdParms != null)
            {
                foreach (MySqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
        #endregion
    }
}