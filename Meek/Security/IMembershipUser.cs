using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meek.Security
{
    public interface IMembershipUser
    {
        string Username { get; }

        string Email { get; set; }

        DateTime CreationDate { get; }

        string Comment { get; set; }

        bool IsOnline { get; }

        bool IsLockedOut { get; }

        bool IsApproved { get; set; }

        DateTime LastActivityDate { get; set; }

        DateTime LastLockoutDate { get; }

        DateTime LastLoginDate { get; set; }

        DateTime LastPasswordChangedDate { get; }

        string PasswordQuestion { get; }

        string ProviderName { get; }

        object ProviderUserKey { get; }
    }
}
