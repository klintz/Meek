using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Meek.Security
{
    public abstract class MembershipProvider //: IMembershipProvider
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
    }
}
