using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IssueTracker.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public List<Project> Projects { get; set; }

        public List<Ticket> Tickets { get; set; }

        public List<Comment> Comments { get; set; }
    }

    
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole():base() { } 
        public ApplicationRole(string roleName) : base() { }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("IssueTrackerContext", throwIfV1Schema: false)
        {
              Database.SetInitializer(new IssueDBInitializer());
          //  Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        public System.Data.Entity.DbSet<Ticket> Tickets { get; set; }

        public System.Data.Entity.DbSet<Project> Projects { get; set; }

        public System.Data.Entity.DbSet<Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<UserProject> UserProjects { get; set; }
        public System.Data.Entity.DbSet<IssueTracker.Models.RoleViewModel> RoleViewModels { get; set; }


    }
}