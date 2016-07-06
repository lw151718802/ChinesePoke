using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM.Web.User.Model
{
    public class ZS_User:result
    {
      

        public ZS_User()
        { }
       
        private int _id;
        private string _account;
        private string _realname;
        private string _phone;
        private string _pwda;
        private string _pwdb;
        private string _recman;
        private string _placeman;
        private string _studioman;
        private DateTime _regdate;
        private DateTime _activedate;
        private int _usertype;
        private int _isactive;
        private int _isused;
        private int _regmoney;
        private string _usercode;
        private int _userlevel;
        private decimal _syrate;
        private int _parentuserid;
        private string _email;
        private string _idno;


        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Account
        {
            set { _account = value; }
            get { return _account; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PWDA
        {
            set { _pwda = value; }
            get { return _pwda; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PWDB
        {
            set { _pwdb = value; }
            get { return _pwdb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecMan
        {
            set { _recman = value; }
            get { return _recman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PlaceMan
        {
            set { _placeman = value; }
            get { return _placeman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StudioMan
        {
            set { _studioman = value; }
            get { return _studioman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RegDate
        {
            set { _regdate = value; }
            get { return _regdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ActiveDate
        {
            set { _activedate = value; }
            get { return _activedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ISActive
        {
            set { _isactive = value; }
            get { return _isactive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ISUsed
        {
            set { _isused = value; }
            get { return _isused; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RegMoney
        {
            set { _regmoney = value; }
            get { return _regmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserCode
        {
            set { _usercode = value; }
            get { return _usercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserLevel
        {
            set { _userlevel = value; }
            get { return _userlevel; }
        }
        /// <summary>
        /// 每月收益参数
        /// </summary>
        public decimal SYRate
        {
            set { _syrate = value; }
            get { return _syrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ParentUserID
        {
            set { _parentuserid = value; }
            get { return _parentuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDNO
        {
            set { _idno = value; }
            get { return _idno; }
        }

    }
}