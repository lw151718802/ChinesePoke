using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RM.MySQLBusines.IDAO
{
    public interface  I_Notice_DAO
    {
        Hashtable GetNotice(int NoticeType);
    }
}
