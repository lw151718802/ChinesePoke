using RM.Busines.IDAO;
using RM.Common.DotNetBean;
using RM.Common.DotNetCode;
using RM.Common.DotNetData;
using RM.Common.DotNetEncrypt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RM.Busines.DAL
{
    public   class ZS_User_Dal:ZS_User_IDAO
    {

        public DataTable UserLogin(string name, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from ZS_User where ");
            strSql.Append("Account=@User_Account ");
            strSql.Append("and PWDA=@User_Pwd ");
            strSql.Append("and ISUsed = 1 ");
            SqlParam[] para = new SqlParam[]
            {
                new SqlParam("@User_Account", name),
                new SqlParam("@User_Pwd", Md5Helper.MD5(pwd, 32))
            };
            return DataFactory.SqlDataBase().GetDataTableBySQL(strSql, para);
        }


        public DataTable CheckRePWD(string name, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Select * from ZS_User where ");
            strSql.Append("Account=@User_Account ");
            strSql.Append("and PWDB=@User_Pwd ");
            strSql.Append("and ISUsed = 1 ");
            SqlParam[] para = new SqlParam[]
            {
                new SqlParam("@User_Account", name),
                new SqlParam("@User_Pwd", Md5Helper.MD5(pwd, 32))
            };
            return DataFactory.SqlDataBase().GetDataTableBySQL(strSql, para);
        }



        public void SysLoginLog(string SYS_USER_ACCOUNT, string SYS_LOGINLOG_STATUS, string OWNER_address)
        {
            Hashtable ht = new Hashtable();
            ht["SYS_LOGINLOG_ID"] = CommonHelper.GetGuid;
            ht["User_Account"] = SYS_USER_ACCOUNT;
            ht["SYS_LOGINLOG_IP"] = RequestHelper.GetIP();
            ht["OWNER_address"] = OWNER_address;
            ht["SYS_LOGINLOG_STATUS"] = SYS_LOGINLOG_STATUS;
            DataFactory.SqlDataBase().InsertByHashtable("ZS_UserLoginLog", ht);
        }


        public void AddUserByProc(Hashtable ht, ref Hashtable rs)
        {
            DataFactory.SqlDataBase().ExecuteByProcReturn("Add_User", ht, ref rs);
        }


        //获取用户可用金额
        public decimal GetUserMoeny(StringBuilder sql)
        {
            return  decimal.Parse( DataFactory.SqlDataBase().GetObjectValue(sql).ToString());
        }

        //获取会员
        public DataTable GetZS_UserPage(StringBuilder SqlWhere, IList<SqlParam> IList_param, int pageIndex, int pageSize, ref int count)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select A.*,ISNULL(B.ZXYJ, 0) AS ZXYJ  , ISNULL(B.PXYJ, 0) AS PXYJ, ISNULL(B.CurYJ, 0) AS CurYJ, ISNULL(B.PerYJ, 0) AS PerYJ, B.UpdateTime from ZS_User A left join ZS_UserTrackStat B ON A.Account = b.Account where 1=1");
            strSql.Append(SqlWhere);
           
            return DataFactory.SqlDataBase().GetPageList(strSql.ToString(), IList_param.ToArray<SqlParam>(), "RegDate", "Desc", pageIndex, pageSize, ref count);
        }
        //电子币账目
        public DataTable GetUserMoneyFlowPage(StringBuilder SqlWhere, IList<SqlParam> IList_param, int pageIndex, int pageSize, ref int count)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from ZS_UserMoneyFlow where 1=1");
            strSql.Append(SqlWhere);

            return DataFactory.SqlDataBase().GetPageList(strSql.ToString(), IList_param.ToArray<SqlParam>(), "CreateTime", "Desc", pageIndex, pageSize, ref count);
        }


        //用户提现列表
        public DataTable GetZS_UserDrawPage(StringBuilder SqlWhere, IList<SqlParam> IList_param, int pageIndex, int pageSize, ref int count)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from ZS_UserDraw where 1=1");
            strSql.Append(SqlWhere);

            return DataFactory.SqlDataBase().GetPageList(strSql.ToString(), IList_param.ToArray<SqlParam>(), "DrawTime", "Desc", pageIndex, pageSize, ref count);
        }


        //用户冻结资金
        public DataTable GetZ_UserMoenyForzePage(StringBuilder SqlWhere, IList<SqlParam> IList_param, int pageIndex, int pageSize, ref int count)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select *,dateadd(day,7,CreateTime) as YuJi from Z_UserMoenyForze where 1=1");
            strSql.Append(SqlWhere);

            return DataFactory.SqlDataBase().GetPageList(strSql.ToString(), IList_param.ToArray<SqlParam>(), "CreateTime", "Desc", pageIndex, pageSize, ref count);
        }

        public Hashtable GetZS_UserBankInfo(string account)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from ZS_UserAuth where Account='"+ account + "' and IsDefault = 1");

            DataTable dt = DataFactory.SqlDataBase().GetDataTableBySQL(strSql);
            return DataTableHelper.DataTableToHashtable(dt);
        }
        //添加提现信息
        public void AddUserDrawByProc(Hashtable ht, ref Hashtable rs)
        {
            DataFactory.SqlDataBase().ExecuteByProcReturn("PR_WithDraw", ht, ref rs);
        }
        //添加转账信息
        public void AddPR_TransfByProc(Hashtable ht, ref Hashtable rs)
        {
            DataFactory.SqlDataBase().ExecuteByProcReturn("PR_Transf", ht, ref rs);
        }



        public DataSet GetDataSetPR_UserBaseStat(string useraccount)
        {
            SqlParam[] parmAdd = new SqlParam[]
                                {
                                    new SqlParam("@account",useraccount)
                                };
            return DataFactory.SqlDataBase().ExecuteByProcReturnDataSet("PR_UserBaseStat", parmAdd);
        }







    }
}
