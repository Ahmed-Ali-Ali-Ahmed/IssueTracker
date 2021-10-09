using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string  Title { get; set; }

        public List<Ticket> Tickets  { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}