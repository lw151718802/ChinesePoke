


namespace RM.Common.DotNetBean
{
    public class SessionZSUser
    {
        public object UserId
        {
            get;
            set;
        }

        public object UserAccount
        {
            get;
            set;
        }

        public object UserPwd
        {
            get;
            set;
        }

        public object UserName
        {
            get;
            set;
        }

        public SessionZSUser(object userId, object userAccount, object userPwd, object userName)
        {
            this.UserId = userId;
            this.UserAccount = userAccount;
            this.UserName = userName;
            this.UserPwd = userPwd;
        }

        public SessionZSUser()
        {
        }
    }
}