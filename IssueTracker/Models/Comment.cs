using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Comment
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }


        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public string CommenterId { get; set; }
        public ApplicationUser Commenter { get; set; }
    }
}