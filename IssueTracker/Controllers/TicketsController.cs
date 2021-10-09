using IssueTracker.Models;
using IssueTracker.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Tickets
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            // var tickets = db.Tickets.Include(t => t.Project).ToList();
            var tickets = db.Tickets.Where(t => t.Assigner.Id == userID).Include(t => t.Project).ToList();
            return View(tickets);
        }

        public ActionResult Pool()
        {
            var tickets = db.Tickets.Include(t => t.Project);
            return View(tickets.ToList());

        }


        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ticket ticket = db.Tickets.Find(id);

            ticket.Assigner = db.Users.Find(ticket.AssignerId);
            ticket.Submitter = db.Users.Find(ticket.SubmitterId);

            ViewBag.comments = db.Comments.Where(c => c.TicketId == ticket.Id).ToList();
            if (ticket == null)
            {
                return HttpNotFound();
            }
            if (ViewBag.Comments == null)
            {
                ViewBag.Comments = "";
            }
            return View(ticket);
        }



        // GET: Tickets/Create
        public ActionResult Create()
        {
            TicketViewModel ticketView = new TicketViewModel();


            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title");
            ViewBag.Users = new SelectList(db.Users, "Id", "UserName");
            return View(ticketView);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TicketViewModel ticketView)
        {

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", ticketView.ProjectId);

            if (ModelState.IsValid)
            {


                Ticket ticket = new Ticket();
                var submitter = db.Users.Find(User.Identity.GetUserId());
                ticket.Id = ticketView.Id;
                ticket.Title = ticketView.Title;
                ticket.Description = ticketView.Description;
                ticket.AssignerId = ticketView.AssignerId;
                ticket.Assigner = db.Users.Find(ticketView.AssignerId);
                ticket.SubmitterId = submitter.Id;
                ticket.Submitter = submitter;
                ticket.comments = ticketView.comments;
                ticket.state = ticketView.state;
                ticket.Priority = ticketView.Priority;
                ticket.Created = DateTime.Now;
                ticket.ProjectId = ticketView.ProjectId;
                ticket.Project = ticketView.Project;
                ticket.Attachment = ticketView.Attachment;
                
                try
                {

                    db.Tickets.Add(ticket);
                    db.SaveChanges();
                    

                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            
                            System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw e; 
                }

                return RedirectToAction("Index");

            }


            return View(ticketView);
        }

        // GET: Tickets/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            TicketViewModel ticketView = new TicketViewModel();

            ticketView.Id = ticket.Id;
            ticketView.Title = ticket.Title;
            ticketView.Description = ticket.Description;
            ticketView.AssignerId = ticket.AssignerId;
            ticketView.Assigner = ticket.Assigner;
            ticketView.SubmitterId = ticket.SubmitterId;
            ticketView.Submitter = db.Users.Find(ticket.SubmitterId);
            ticketView.comments = ticket.comments;
            ticketView.state = ticket.state;
            ticketView.Priority = ticket.Priority;
            ticketView.Created = ticket.Created;
            ticketView.ProjectId = ticket.ProjectId;
            ticketView.Project = ticket.Project;
            ticketView.Attachment = ticket.Attachment;

            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Value", "Title", ticket.ProjectId);
            ViewBag.Users = new SelectList(db.Users, "Id", "UserName");
            return View(ticketView);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TicketViewModel ticketView)
        {
            if (ModelState.IsValid)
            {


                Ticket ticket = new Ticket();
                ticket.Id = ticketView.Id;
                ticket.Title = ticketView.Title;
                ticket.Description = ticketView.Description;
                ticket.AssignerId = ticketView.Assigner.Id;
                ticket.Assigner = db.Users.Find(ticketView.Assigner.Id);
                ticket.SubmitterId = ticketView.SubmitterId;
                ticket.Submitter = db.Users.Find(ticketView.SubmitterId);
                ticket.comments = ticketView.comments;
                ticket.state = ticketView.state;
                ticket.Priority = ticketView.Priority;
                ticket.Created = DateTime.Now;
                ticket.ProjectId = ticketView.ProjectId;
                ticket.Project = ticketView.Project;
                ticket.Attachment = ticketView.Attachment;

                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("/Details/" + ticket.Id);
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", ticketView.ProjectId);
            return View(ticketView);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
