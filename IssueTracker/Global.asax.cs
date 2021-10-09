using IssueTracker.Helpers;
using IssueTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IssueTracker
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

           //  Database.SetInitializer<IssueTrackerContext> (new DropCreateDatabaseAlways<IssueTrackerContext>());
             // Database.SetInitializer<IssueTrackerContext>(new IssueDBInitializer());
           //  Database.SetInitializer(new IssueDBInitializer());


            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseAlways<ApplicationDbContext>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            
         
        }
    }
}
