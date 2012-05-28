namespace Meek.Security
{
    public interface IMembershipProvider 
    {
        string ApplicationName { get; set; }

        bool EnablePasswordReset { get; }

        bool EnablePasswordRetrieval { get; }

        bool ChangePassword(string username, string oldPassword, string newPassword);

        string GetPassword(string username, string answer);

        string ResetPassword(string username, string answer);

        bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer);

        int MaxInvalidPasswordAttempts { get; }

        int MinRequiredPasswordLength { get; }

        int PasswordAttemptWindow { get; }

        PasswordFormat PasswordFormat { get; }

        string PasswordStrengthRegularExpression { get; }

        int MinRequiredNonAlphanumericCharacters { get; }

        byte[] EncryptPassword(byte[] password);

        byte[] EncryptPassword(byte[] password, MembershipPasswordCompatibilityMode legacyPasswordCompatibilityMode);

        byte[] DecryptPassword(byte[] encodedPassword);

        //User
        IMembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status);

        bool DeleteUser(string username, bool deleteAllRelatedData);

        MembershipUserList FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords);

        MembershipUserList FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords);

        MembershipUserList GetAllUsers(int pageIndex, int pageSize, out int totalRecords);

        int GetNumberOfUsersOnline();

        IMembershipUser GetUser(object providerUserKey, bool userIsOnline);

        IMembershipUser GetUser(string username, bool userIsOnline);

        string GetUserNameByEmail(string email);

        bool RequiresQuestionAndAnswer { get; }

        bool RequiresUniqueEmail { get; }

        bool UnlockUser(string userName);

        void UpdateUser(IMembershipUser user);

        bool ValidateUser(string username, string password);
    }
}
