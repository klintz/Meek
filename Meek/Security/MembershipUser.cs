using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meek.Security
{
    public class MembershipUser : IMembershipUser
    {
        public virtual string Username { get; protected set; }

        public virtual string Email { get; set; }

        public virtual DateTime CreationDate { get; protected set; }

        public virtual string Comment { get; set; }

        public virtual bool IsOnline { get; protected set; }

        public virtual bool IsLockedOut { get; protected set; }

        public virtual bool IsApproved { get; set; }

        public virtual DateTime LastActivityDate { get; set; }

        public virtual DateTime LastLockoutDate { get; protected set; }

        public virtual DateTime LastLoginDate { get; set; }

        public virtual DateTime LastPasswordChangedDate { get; protected set; }

        public virtual string PasswordQuestion { get; protected set; }

        public virtual string ProviderName { get; protected set; }

        public object ProviderUserKey { get; protected set; }
    }
}
