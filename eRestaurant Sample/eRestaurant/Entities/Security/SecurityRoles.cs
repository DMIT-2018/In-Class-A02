using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.Entities.Security
{
    internal static class SecurityRoles
    {
        public const string WebsiteAdmins = "WebsiteAdmins";
        public const string RegisteredUsers = "RegisteredUsers";
        public const string Staff = "Staff";
        public static List<string> DefaultSecurityRoles
        {
            get
            {
                List<string> value = new List<string>();
                value.Add(WebsiteAdmins);
                value.Add(RegisteredUsers);
                value.Add(Staff);
                return value;
            }
        }
    }
}
