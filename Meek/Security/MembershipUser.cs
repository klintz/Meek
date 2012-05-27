using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meek.Security
{
    public class MembershipUser : IMembershipUser
    {
        public string Username { get; protected set; }

        public string Email { get; set; }

        public DateTime CreationDate { get; protected set; }

        public string Comment { get; set; }

        public bool IsOnline { get; protected set; }

        public bool IsLockedOut { get; protected set; }

        public bool IsApproved { get; set; }

        public DateTime LastActivityDate { get; set; }

        public DateTime LastLockoutDate { get; protected set; }

        public DateTime LastLoginDate { get; set; }

        public DateTime LastPasswordChangedDate { get; protected set; }

        public string PasswordQuestion { get; protected set; }

        public string ProviderName { get; protected set; }

        public object ProviderUserKey { get; protected set; }
    }
}
