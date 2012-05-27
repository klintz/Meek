using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meek.Security;

namespace Meek.Web.Security
{
    public class RoleProvider : System.Web.Security.RoleProvider
    {
        private IRoleProvider Provider { get; set; }

        public override string ApplicationName 
        {
            get { return Provider.ApplicationName; }
            set { Provider.ApplicationName = value; }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            Provider.AddUsersToRoles(usernames, roleNames);
        }

        public override void CreateRole(string roleName)
        {
            Provider.CreateRole(roleName);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            return Provider.DeleteRole(roleName, throwOnPopulatedRole);
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return Provider.FindUsersInRole(roleName, usernameToMatch);
        }

        public override string[] GetAllRoles()
        {
            return Provider.GetAllRoles();
        }

        public override string[] GetRolesForUser(string username)
        {
            return Provider.GetRolesForUser(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return Provider.GetUsersInRole(roleName);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return Provider.IsUserInRole(username, roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            Provider.RemoveUsersFromRoles(usernames, roleNames);
        }

        public override bool RoleExists(string roleName)
        {
            return Provider.RoleExists(roleName);
        }
    }
}
