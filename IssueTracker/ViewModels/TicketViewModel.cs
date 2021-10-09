using IssueTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.ViewModels
{

    public class CustomeSelecteList
    {
        public string title { get; set; }

        public string value { get; set; }
    }

  
    public class TicketViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

  


        public string state { get; set; }

        public IEnumerable<SelectListItem> states = new List<SelectListItem>()
        {
           
                new SelectListItem() { Text = "Open", Value = "Open"},
                new SelectListItem() { Text = "UnderReview", Value = "UnderReview"},
                new SelectListItem() { Text = "Close", Value = "Close"}

        };

        public IEnumerable<SelectListItem> prorities = new List<SelectListItem>()
        {
                new SelectListItem() {Text ="High", Value="High"},
                new SelectListItem() { Text = "medium", Value = "medium"},
                new SelectListItem() { Text = "low", Value = "low"}

        };
 
        public string Priority { get; set; }

        public DateTime Created { get; set; }

        

        public byte[] Attachment { get; set; }

        
        public int ProjectId { get; set; }



        public Project Project { get; set; }

        public string SubmitterId { get; set; }
        public ApplicationUser Submitter { get; set; }


        public string AssignerId { get; set; }
        public ApplicationUser Assigner { get; set; }

        public List<Comment> comments { get; set; }


    }
}
