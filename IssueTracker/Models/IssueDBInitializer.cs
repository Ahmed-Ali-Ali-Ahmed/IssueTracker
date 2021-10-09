using IssueTracker.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{

    public class IssueDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {


        protected override void Seed(ApplicationDbContext context)
        {
            IdentityHelper.SeedIdentites(context);

            var Projects = new List<Project>();

            Projects.Add(new Project() { Title = "Isssue Tracker" });
            Projects.Add(new Project() { Title = "University Review" });


            var Tickets = new List<Ticket>();
            var userManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            Tickets.Add(new Ticket()
            {
                Title = "create seeder",
                Assigner = userManger.FindByName(UserNames.User3),
                Description = "Please create Seeder to seed sample data int the database",
                Created = DateTime.Today.AddMonths(-3),
                Project = Projects.First(pro => pro.Title == "University Review"),
                Submitter = userManger.FindByName(UserNames.User4),
                state = "close",
                Priority = "Medium",
            }); ;

            Tickets.Add(new Ticket()
            {
                Title = "Update The FrontEned",
                Assigner = userManger.FindByName(UserNames.User3),
                Description = "Please update our font-end to the new one ",
                Created = DateTime.Today.AddMonths(-2),
                Project = Projects.First(pro => pro.Title == "University Review"),
                Submitter = userManger.FindByName(UserNames.User2),
                state = "underReview",
                Priority = "Low",
            });


            Tickets.Add(new Ticket()
            {
                Title = "Authonitcation bug",
                Assigner = userManger.FindByName(UserNames.User3),
                Description = "Please Investigate the issue with our authintication system",
                Created = DateTime.Today.AddMonths(-1),
                Project = Projects.First(pro => pro.Title == "University Review"),
                Submitter = userManger.FindByName(UserNames.User1),
                state = "Open",
                Priority = "High",
            }); ;


            Tickets.Add(new Ticket()
            {
                Title = "Code Complexity ",
                Assigner = userManger.FindByName(UserNames.User3),
                Description = "Please try to update the code in Account controllr to impove readability ",
                Created = DateTime.Today.AddDays(-5),
                Project = Projects.First(pro => pro.Title == "Isssue Tracker"),
                Submitter = userManger.FindByName(UserNames.User4),
                state = "close",
                Priority = "Low",
            });

            Tickets.Add(new Ticket()
            {
                Title = "Update Users Role",
                Assigner = userManger.FindByName(UserNames.User1),
                Description = "Please add me as Project manger ",
                Created = DateTime.Today.AddDays(-3),
                Project = Projects.First(pro => pro.Title == "Isssue Tracker"),
                Submitter = userManger.FindByName(UserNames.User3),
                state = "Open",
                Priority = "Medium",
            });

            Tickets.Add(new Ticket()
            {
                Title = "the System is Down",
                Assigner = userManger.FindByName(UserNames.User2),
                Description = "I can not acces the database",
                Created = DateTime.Today.AddMonths(-1),
                Project = Projects.First(pro => pro.Title == "Isssue Tracker"),
                Submitter = userManger.FindByName(UserNames.User3),
                state = "underReview",
                Priority = "High",
            });

            foreach (var P in Projects)
            {
                context.Projects.Add(P);
            }
            foreach (var T in Tickets)
            {
                context.Tickets.Add(T);
            }

            base.Seed(context);

        }
       
    }
}   