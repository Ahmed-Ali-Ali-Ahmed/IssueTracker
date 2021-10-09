using IssueTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.ViewModels
{
    public class TicketCommentsViewModel
    {
        public string Id { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }


        public Comment comment { get; set; }
        public List<Comment> comments { get; set; }
    }
}