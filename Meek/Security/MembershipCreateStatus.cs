namespace Meek.Security
{
    public enum MembershipCreateStatus
    {
        DuplicateEmail,
        DuplicateProviderUserKey,
        DuplicateUserName,
        InvalidAnswer,
        InvalidEmail,
        InvalidPassword,
        InvalidProviderUserKey,
        InvalidQuestion,
        InvalidUserName,
        ProviderError,
        Success,
        UserRejected
    }
}