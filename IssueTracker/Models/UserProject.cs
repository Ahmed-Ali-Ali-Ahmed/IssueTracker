using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class UserProject
    {

        public int Id { get; set; }

        public int UserID { get; set; }

        public ApplicationUser User { get; set; }


        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}