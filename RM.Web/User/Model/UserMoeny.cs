using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM.Web.User.Model
{
    public class UserMoeny : result
    {
        private decimal _userMoney;
        private string _account;
        public string Account
        {
            set { _account = value; }
            get { return _account; }
        }
        public decimal UserMoney
        {
            get
            {
                return _userMoney;
            }

            set
            {
                _userMoney = value;
            }
        }
    }
}