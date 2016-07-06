using RM.Common.DotNetCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RM.Busines.IDAO
{
    public interface ZS_User_IDAO
    {

        DataTable UserLogin(string name, string pwd);
        DataTable CheckRePWD(string name, string pwd);
        void SysLoginLog(string SYS_USER_ACCOUNT, string SYS_LOGINLOG_STATUS, string OWNER_address);

        void AddUserByProc(Hashtable ht, ref Hashtable rs);

        decimal GetUserMoeny(StringBuilder sql);


        DataTable GetZS_UserPage(StringBuilder SqlWhere, IList<SqlParam> IList_param, int pageIndex, int pageSize, ref int count);

        DataTable GetUserMoneyFlowPage(StringBuilder SqlWhere, IList<SqlParam> IList_param, int pageIndex, int pageSize, ref int count);

        DataTable GetZS_UserDrawPage(StringBuilder SqlWhere, IList<SqlParam> IList_param, int pageIndex, int pageSize, ref int count);

        Hashtable GetZS_UserBankInfo(string account);

        void AddUserDrawByProc(Hashtable ht, ref Hashtable rs);

        //添加转账信息
        void AddPR_TransfByProc(Hashtable ht, ref Hashtable rs);

        DataTable GetZ_UserMoenyForzePage(StringBuilder SqlWhere, IList<SqlParam> IList_param, int pageIndex, int pageSize, ref int count);


        DataSet GetDataSetPR_UserBaseStat(string useraccount);
    }
}
