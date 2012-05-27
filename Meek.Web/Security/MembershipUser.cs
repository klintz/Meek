using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meek.Security;

namespace Meek.Web.Security
{
    public class MembershipUser : System.Web.Security.MembershipUser
    {
        private IMembershipProvider MembershipProvider { get; set; }

        internal IMembershipUser User { get; set; }

        internal static MembershipUser NewMembershipUser(IMembershipUser membershipUser, IMembershipProvider provider)
        {
            return new MembershipUser() { MembershipProvider = provider, User = membershipUser };            
        }      

        public override string UserName
        {
            get
            {
                return User.Username;
            }
        }

        public override DateTime CreationDate
        {
            get
            {
                return User.CreationDate;
            }
        }

        public override bool IsOnline
        {
            get
            {
                return User.IsOnline;
            }
        }

        public override bool IsLockedOut
        {
            get
            {
                return User.IsLockedOut;
            }
        }

        public override DateTime LastLockoutDate
        {
            get
            {
                return User.LastLockoutDate;
            }
        }

        public override DateTime LastPasswordChangedDate
        {
            get
            {
                return User.LastPasswordChangedDate;
            }
        }

        public override string PasswordQuestion
        {
            get
            {
                return User.PasswordQuestion;
            }
        }

        public override string ProviderName
        {
            get
            {
                return User.ProviderName;
            }
        }

        public override object ProviderUserKey
        {
            get
            {
                return User.ProviderUserKey;
            }
        }

        public override string Email
        {
            get
            {
                return User.Email;
            }
            set
            {
                User.Email = value;
            }
        }

        public override string Comment
        {
            get
            {
                return User.Comment;
            }
            set
            {
                User.Comment = value;
            }
        }

        public override bool IsApproved
        {
            get
            {
                return User.IsApproved;
            }
            set
            {
                User.IsApproved = value;
            }
        }

        public override DateTime LastActivityDate
        {
            get
            {
                return User.LastActivityDate;
            }
            set
            {
                User.LastActivityDate = value;
            }
        }

        public override DateTime LastLoginDate
        {
            get
            {
                return User.LastLoginDate;
            }
            set
            {
                User.LastLoginDate = value;
            }
        }

        private MembershipUser()
        {        
        }

        
    }
}
