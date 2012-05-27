using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meek.Security;
using System.Web.Configuration;

namespace Meek.Web.Security
{
    public class MembershipProvider : System.Web.Security.MembershipProvider
    {
        #region Variables        
        private IMembershipProvider Provider { get; set; }
        #endregion
        
        #region ApplicationName
        public override string ApplicationName 
        {
            get { return Provider.ApplicationName; }
            set { Provider.ApplicationName = value; }
        }
        #endregion

        #region Password
        public override bool EnablePasswordReset { get { return Provider.EnablePasswordReset; } }

        public override bool EnablePasswordRetrieval { get { return Provider.EnablePasswordRetrieval; } }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return Provider.ChangePassword(username, oldPassword, newPassword);            
        }
              
        public override string GetPassword(string username, string answer)
        {
            return Provider.GetPassword(username, answer);
        }

        public override string ResetPassword(string username, string answer)
        {
            return Provider.ResetPassword(username, answer);
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            return Provider.ChangePasswordQuestionAndAnswer(username, password, newPasswordQuestion, newPasswordAnswer);
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return Provider.MaxInvalidPasswordAttempts;  }
        }

        public override int MinRequiredPasswordLength
        {
            get { return Provider.MinRequiredPasswordLength; }
        }

        public override int PasswordAttemptWindow
        {
            get { return Provider.PasswordAttemptWindow; }
        }

        public override System.Web.Security.MembershipPasswordFormat PasswordFormat
        {
            get 
            {
                switch (Provider.PasswordFormat)
                { 
                    case Meek.Security.PasswordFormat.Clear:
                        return System.Web.Security.MembershipPasswordFormat.Clear;
                    case Meek.Security.PasswordFormat.Encrypted:
                        return System.Web.Security.MembershipPasswordFormat.Encrypted;
                    case Meek.Security.PasswordFormat.Hashed:
                        return System.Web.Security.MembershipPasswordFormat.Hashed;
                }
                return System.Web.Security.MembershipPasswordFormat.Clear;
            }
        }

        
        public override string PasswordStrengthRegularExpression
        {
            get
            {
                return Provider.PasswordStrengthRegularExpression;
                //8 to 16 characters, upper case letter, lower case letter, a symbol, a number
                //return @"(?=^[^\s]{8,16}$)((?=.*?\d)(?=.*?[A-Z])(?=.*?[a-z])|(?=.*?\d)(?=.*?[^\w\d\s])(?=.*?[a-z])|(?=.*?[^\w\d\s])(?=.*?[A-Z])(?=.*?[a-z])|(?=.*?\d)(?=.*?[A-Z])(?=.*?[^\w\d\s]))^.*";
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return Provider.MinRequiredNonAlphanumericCharacters; }
        }

        protected override byte[] EncryptPassword(byte[] password)
        {
            return Provider.EncryptPassword(password);
        }

        protected override byte[] EncryptPassword(byte[] password, System.Web.Configuration.MembershipPasswordCompatibilityMode legacyPasswordCompatibilityMode)
        {              
            if(legacyPasswordCompatibilityMode == System.Web.Configuration.MembershipPasswordCompatibilityMode.Framework20)
                return Provider.EncryptPassword(password, Meek.Security.MembershipPasswordCompatibilityMode.Framework20);
            return Provider.EncryptPassword(password, Meek.Security.MembershipPasswordCompatibilityMode.Framework40);            
        }

        protected override byte[] DecryptPassword(byte[] encodedPassword)
        {
            return Provider.DecryptPassword(encodedPassword);
        }
        #endregion

        #region User
        public override System.Web.Security.MembershipUser CreateUser(
            string username, 
            string password, 
            string email, 
            string passwordQuestion, 
            string passwordAnswer, 
            bool isApproved, 
            object providerUserKey, 
            out System.Web.Security.MembershipCreateStatus status)
        {
            Meek.Security.MembershipCreateStatus createStatus;
            var user = Provider.CreateUser(
                username, password, email, passwordQuestion,
                passwordAnswer, isApproved, providerUserKey, out createStatus);

            #region Wrap createStatus
            switch (createStatus)
            { 
                case MembershipCreateStatus.DuplicateEmail:
                    status = System.Web.Security.MembershipCreateStatus.DuplicateEmail;
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    status = System.Web.Security.MembershipCreateStatus.DuplicateProviderUserKey;
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    status = System.Web.Security.MembershipCreateStatus.DuplicateUserName;
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    status = System.Web.Security.MembershipCreateStatus.InvalidAnswer;
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    status = System.Web.Security.MembershipCreateStatus.InvalidEmail;
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    status = System.Web.Security.MembershipCreateStatus.InvalidPassword;
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    status = System.Web.Security.MembershipCreateStatus.InvalidProviderUserKey;
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    status = System.Web.Security.MembershipCreateStatus.InvalidQuestion;
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    status = System.Web.Security.MembershipCreateStatus.InvalidUserName;
                    break;
                case MembershipCreateStatus.ProviderError:
                    status = System.Web.Security.MembershipCreateStatus.ProviderError;
                    break;
                case MembershipCreateStatus.Success:
                    status = System.Web.Security.MembershipCreateStatus.Success;
                    break;
                default:
                case MembershipCreateStatus.UserRejected:
                    status = System.Web.Security.MembershipCreateStatus.UserRejected;
                    break;
            }
            #endregion

            return MembershipUser.NewMembershipUser(user, Provider);
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            return Provider.DeleteUser(username, deleteAllRelatedData);
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            var users = Provider.FindUsersByEmail(emailToMatch, pageIndex, pageSize, out totalRecords);
            System.Web.Security.MembershipUserCollection collection = new System.Web.Security.MembershipUserCollection();
            users.ForEach(u => collection.Add(MembershipUser.NewMembershipUser(u, Provider)));
            return collection;
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            var users = Provider.FindUsersByName(usernameToMatch, pageIndex, pageSize, out totalRecords);
            System.Web.Security.MembershipUserCollection collection = new System.Web.Security.MembershipUserCollection();
            users.ForEach(u => collection.Add(MembershipUser.NewMembershipUser(u, Provider)));
            return collection;
        }

        public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            var users = Provider.GetAllUsers(pageIndex, pageSize, out totalRecords);
            System.Web.Security.MembershipUserCollection collection = new System.Web.Security.MembershipUserCollection();
            users.ForEach(u => collection.Add(MembershipUser.NewMembershipUser(u, Provider)));
            return collection;
        }

        public override int GetNumberOfUsersOnline()
        {
            return Provider.GetNumberOfUsersOnline();
        }

        public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            var user = Provider.GetUser(providerUserKey, userIsOnline);
            return MembershipUser.NewMembershipUser(user, Provider);
        }

        public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline)
        {
            var user = Provider.GetUser(username, userIsOnline);
            return MembershipUser.NewMembershipUser(user, Provider);
        }

        public override string GetUserNameByEmail(string email)
        {
            return Provider.GetUserNameByEmail(email);
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return Provider.RequiresQuestionAndAnswer; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return Provider.RequiresUniqueEmail; }
        }

        public override bool UnlockUser(string userName)
        {
            return Provider.UnlockUser(userName);
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user)
        {
            if (user is MembershipUser)
            { 
                var member = user as MembershipUser;
                Provider.UpdateUser(member.User);
            }            
        }

        public override bool ValidateUser(string username, string password)
        {
            return Provider.ValidateUser(username, password);
        }
        #endregion

    }
}
