using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    
    
    public class Ticket
    {
        public int Id { get; set; }

        public string  Title { get; set; }

        public string Description { get; set; }

       
        public string state { get; set; }

        [UIHint("YesNoDropDown")]
        public string Priority { get; set; }

        public DateTime Created { get; set; }

        public byte[] Attachment { get; set; }

        [ForeignKey("Project")]
        public int ProjectId  { get; set; }
        public Project Project{ get; set; }

       
        public string SubmitterId { get; set; }
     
        public ApplicationUser Submitter { get; set; }

        
        public string AssignerId { get; set; }
        
        public ApplicationUser Assigner { get; set; }

        public List<Comment> comments { get; set; }

        
    }
}