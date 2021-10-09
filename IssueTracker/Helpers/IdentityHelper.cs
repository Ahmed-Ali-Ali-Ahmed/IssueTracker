using IssueTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IssueTracker.Helpers
{
    public class IdentityHelper
    {
        internal static void SeedIdentites(DbContext context)
        {
           

            var userManger = new UserManager<ApplicationUser>(new
                UserStore<ApplicationUser>(context));
            var roleManger = new RoleManager<IdentityRole>(new
                RoleStore<IdentityRole>(context));
             
            if(! roleManger.RoleExists(RoleNames.ROLE_ADMIN))
            {
                var roleresult = roleManger.Create(new
                    IdentityRole(RoleNames.ROLE_ADMIN));
            }

            if (! roleManger.RoleExists(RoleNames.ROLE_MANAGER))
            {
                var roleresult = roleManger.Create(new
                    IdentityRole(RoleNames.ROLE_MANAGER));
            }

            if (!roleManger.RoleExists(RoleNames.ROLE_DEVELOPER))
            {
                var roleresult = roleManger.Create(new
                    IdentityRole(RoleNames.ROLE_DEVELOPER));
            }

            if (!roleManger.RoleExists(RoleNames.ROLE_USER))
            {
                var roleresult = roleManger.Create(new
                    IdentityRole(RoleNames.ROLE_USER));
            }

            

            ApplicationUser user1 = userManger.FindByName(UserNames.User1);
            if(user1 == null)
            {

                user1 = new ApplicationUser()
                {
                    UserName = UserNames.User1,
                    Email = UserNames.User1,
                    EmailConfirmed = true
                };

                IdentityResult userResult = userManger.Create(user1, UserNames.User1Password);
                if(userResult.Succeeded)
                {
                    var result = userManger.AddToRole(user1.Id,
                        RoleNames.ROLE_ADMIN);
                }    
            }


            ApplicationUser user2 = userManger.FindByName(UserNames.User2);
            if (user2 == null)
            {

                user2 = new ApplicationUser()
                {
                    UserName = UserNames.User2,
                    Email = UserNames.User2,
                    EmailConfirmed = true
                };

                IdentityResult userResult = userManger.Create(user2, UserNames.User2Password);
                if (userResult.Succeeded)
                {
                    var result = userManger.AddToRole(user2.Id,
                        RoleNames.ROLE_ADMIN);
                }
            }


            ApplicationUser user3 = userManger.FindByName(UserNames.User3);
            if (user3 == null)
            {

                user3 = new ApplicationUser()
                {
                    UserName = UserNames.User3,
                    Email = UserNames.User3,
                    EmailConfirmed = true
                };

                IdentityResult userResult = userManger.Create(user3, UserNames.User3Passowrd);
                if (userResult.Succeeded)
                {
                    var result = userManger.AddToRole(user3.Id,
                        RoleNames.ROLE_ADMIN);
                }
            }


            ApplicationUser user4 = userManger.FindByName(UserNames.User4);
            if (user4 == null)
            {

                user4 = new ApplicationUser()
                {
                    UserName = UserNames.User4,
                    Email = UserNames.User4,
                    EmailConfirmed = true
                };

                IdentityResult userResult = userManger.Create(user4, UserNames.User4Password);
                if (userResult.Succeeded)
                {
                    var result = userManger.AddToRole(user4.Id,
                        RoleNames.ROLE_ADMIN);
                }
            }

        }
    }
}