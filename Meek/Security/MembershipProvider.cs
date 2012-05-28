using System.IO;

namespace Meek.Security
{
    public abstract class MembershipProvider : IMembershipProvider
    {
        private string _applicationName = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

        public virtual string ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set
            {
                _applicationName = value;
            }
        }

        public virtual bool EnablePasswordReset { get { return true; } }

        public virtual bool EnablePasswordRetrieval { get { return true; } }

        public abstract bool ChangePassword(string username, string oldPassword, string newPassword);

        public abstract string GetPassword(string username, string answer);

        public abstract string ResetPassword(string username, string answer);

        public abstract bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer);

        public virtual int MaxInvalidPasswordAttempts { get { return 0; } }

        public virtual int MinRequiredPasswordLength { get { return 0; } }

        public virtual int PasswordAttemptWindow { get { return 0; } }

        public virtual PasswordFormat PasswordFormat { get { return PasswordFormat.Encrypted; } }

        public virtual string PasswordStrengthRegularExpression { get { return @"(?=^[^\s]{8,16}$)((?=.*?\d)(?=.*?[A-Z])(?=.*?[a-z])|(?=.*?\d)(?=.*?[^\w\d\s])(?=.*?[a-z])|(?=.*?[^\w\d\s])(?=.*?[A-Z])(?=.*?[a-z])|(?=.*?\d)(?=.*?[A-Z])(?=.*?[^\w\d\s]))^.*"; } }

        public virtual int MinRequiredNonAlphanumericCharacters { get { return 1; } }

        public virtual byte[] EncryptPassword(byte[] password)
        {
            return default(byte[]);
        }

        public virtual byte[] EncryptPassword(byte[] password, MembershipPasswordCompatibilityMode legacyPasswordCompatibilityMode)
        {
            return null;
        }

        public virtual byte[] DecryptPassword(byte[] encodedPassword)
        {
            return null;
        }

        public abstract IMembershipUser CreateUser(string username, string password, string email,
                                                   string passwordQuestion, string passwordAnswer, bool isApproved,
                                                   object providerUserKey, out MembershipCreateStatus status);

        public abstract bool DeleteUser(string username, bool deleteAllRelatedData);

        public abstract MembershipUserList FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize,
                                                            out int totalRecords);

        public abstract MembershipUserList FindUsersByName(string usernameToMatch, int pageIndex, int pageSize,
                                                           out int totalRecords);

        public abstract MembershipUserList GetAllUsers(int pageIndex, int pageSize, out int totalRecords);

        public abstract int GetNumberOfUsersOnline();

        public abstract IMembershipUser GetUser(object providerUserKey, bool userIsOnline);

        public abstract IMembershipUser GetUser(string username, bool userIsOnline);

        public abstract string GetUserNameByEmail(string email);

        public virtual bool RequiresQuestionAndAnswer { get { return true; } }

        public virtual bool RequiresUniqueEmail { get { return true; } }

        public abstract bool UnlockUser(string userName);

        public abstract void UpdateUser(IMembershipUser user);

        public abstract bool ValidateUser(string username, string password);
    }
}
