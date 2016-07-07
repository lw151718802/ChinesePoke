using RM.Common.DotNetBean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Poke.ProxyWeb.Ajax
{
    public class HandleBase : IHttpHandler, IRequiresSessionState
    {
        #region 属性定义
        public int res_code = 1;
        public string res_msg = "";

        private bool _PageRead = true;
        private bool _PageAdd = true;
        private bool _PageUpdate = true;
        private bool _PageDel = true;
        private string _UserID = "";
        private string _UserName = "";
        private string _UserAccount = "";
        private string _virDir = ""; //网站虚拟目录
        private HttpContext _PageContext;

        /// <summary>
        /// 当前登录的用户ID
        /// </summary>
        public string UserID
        {
            get { return _UserID; }
        }

        /// <summary>
        /// 当前登录的用户账户
        /// </summary>
        public string UserAccount
        {
            get { return _UserAccount; }
        }

        /// <summary>
        /// 当前登录的用户姓名
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
        }
        /// <summary>
        /// 是否具有读取权限
        /// </summary>
        public bool PageRead
        {
            get { return _PageRead; }
            set { _PageRead = value; }
        }
        /// <summary>
        /// 是否具有新增权限
        /// </summary>
        public bool PageAdd
        {
            get { return _PageAdd; }
            set { _PageAdd = value; }
        }
        /// <summary>
        /// 是否具有修改权限
        /// </summary>
        public bool PageUpdate
        {
            get { return _PageUpdate; }
            set { _PageUpdate = value; }
        }

        /// <summary>
        /// 是否具有删除权限
        /// </summary>
        public bool PageDel
        {
            get { return _PageDel; }
            set { _PageDel = value; }
        }

        public string VirtualDirectory
        {
            get { return _virDir; }
            set { _virDir = value; }
        }

        public HttpContext PageContext
        {
            get { return _PageContext; }
            set { _PageContext = value; }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #endregion

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";

            _PageContext = context;


            //if (RequestSession.GetSessionUser() == null)
            //{

            //    context.Session.Abandon();
            //    context.Session.Clear();
            //    context.Response.Write("<script>parent.document.location.href='/login.html';</script>");
            //    context.Response.End();
            //}
            //_UserID = RequestSession.GetSessionUser().UserId.ToString();
            //_UserName = RequestSession.GetSessionUser().UserName.ToString();
            //_UserAccount = RequestSession.GetSessionUser().UserAccount.ToString();

            _UserID = "100000";
            UpdateValid();
            AddValid();
            DeleteValid();
            AjaxProcess(context);
        }

        //虚方法，替代ProcessRequest，在ashx中重写
        public virtual void AjaxProcess(HttpContext context) { }

        /// <summary>
        /// 验证是否有修改权限
        /// </summary>
        public virtual void UpdateValid() { }

        /// <summary>
        /// 验证是否有添加权限
        /// </summary>
        public virtual void AddValid() { }

        /// <summary>
        /// 验证是否有删除权限
        /// </summary>
        public virtual void DeleteValid() { }

        //输出文本
        public static void outText(string txt)
        {
            HttpContext.Current.Response.ContentType = "text/plain";
            HttpContext.Current.Response.StatusCode = 200;
            HttpContext.Current.Response.Write(txt);
        }

        //获取用户对当前页面的权限


        //获取提交页面文件路径（不包含http://地址/虚拟目录）
        private string GetFilePath()
        {
            string f = _PageContext.Request.UrlReferrer.AbsolutePath.ToLower();

            if (!string.IsNullOrWhiteSpace(_virDir))
                f = f.Substring(_virDir.Length);
            return f;
        }
    }
}