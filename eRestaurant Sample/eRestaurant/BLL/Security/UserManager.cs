using eRestaurant.DAL;
using eRestaurant.DAL.Security;
using eRestaurant.Entities.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.BLL.Security
{
    public class UserManager : UserManager<ApplicationUser>
    {
        #region Constants
        private const string STR_DEFAULT_PASSWORD = "Pa$$word1";
        /// <summary>Requires FirstName and LastName</summary>
        private const string STR_USERNAME_FORMAT = "{0}.{0}";
        /// <summary>Requires UserName</summary>
        private const string STR_EMAIL_FORMAT = "{0}@eRestaurant.tba";
        private const string STR_WEBMASTER_USERNAME = "Webmaster";
        #endregion

        #region Constructor
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }
        #endregion

        #region Methods
        public void AddDefaultUsers()
        {
            using (var context = new RestaurantContext())
            {
                var employees = from data in context.Waiters
                                where !data.ReleaseDate.HasValue
                                select data;
                foreach (var person in employees)
                {
                    // Check if they exist
                    if (!Users.Any(u => u.WaiterID.HasValue && u.WaiterID.Value == person.WaiterID))
                    {
                        string userName = string.Format(STR_USERNAME_FORMAT, person.FirstName, person.LastName);
                        var appUser = new ApplicationUser()
                        {
                            UserName = userName,
                            Email = string.Format(STR_EMAIL_FORMAT, userName),
                            WaiterID = person.WaiterID
                        };
                        // NOTE: The following needs to use the this keyword in order to have access to the extension method
                        //       Create(ApplicationUser user, string password)
                        this.Create(appUser, STR_DEFAULT_PASSWORD);
                    }
                }
                // Add a web  master user
                if (!Users.Any(u => u.UserName.Equals(STR_WEBMASTER_USERNAME)))
                {
                    var webMasterAccount = new ApplicationUser()
                    {
                        UserName = STR_WEBMASTER_USERNAME,
                        Email = string.Format(STR_EMAIL_FORMAT, STR_WEBMASTER_USERNAME)
                    };
                    this.Create(webMasterAccount, STR_DEFAULT_PASSWORD);
                }
            }
        }
        #endregion
    }
}
