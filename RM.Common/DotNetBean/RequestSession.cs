using System.Web;

namespace RM.Common.DotNetBean
{
    public class RequestSession
    {
        private static string SESSION_USER = "SESSION_USER";
        private static string SESSION_ZSUSER = "SessionZSUser";
        public static void AddSessionUser(SessionUser user)
        {
            HttpContext rq = HttpContext.Current;
            rq.Session[RequestSession.SESSION_USER] = user;
        }

        public static SessionUser GetSessionUser()
        {
            HttpContext rq = HttpContext.Current;
            return (SessionUser)rq.Session[RequestSession.SESSION_USER];
        }

        public static void AddSessionZSUser(SessionZSUser user)
        {
            HttpContext rq = HttpContext.Current;
            rq.Session[RequestSession.SESSION_ZSUSER] = user;
        }

        public static SessionZSUser GetSessionZSUser()
        {
            HttpContext rq = HttpContext.Current;
            return (SessionZSUser)rq.Session[RequestSession.SESSION_ZSUSER];
        }
    }
}