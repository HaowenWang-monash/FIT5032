using _5032_Assignment.Models;
using _5032_Assignment.Utils;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5032_Assignment.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public UserManager<IdentityUser> UserManager { get; private set; }

        public HomeController()
        {
            
            UserManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new ApplicationDbContext()));
        }
        public ActionResult Index()
        {
            EmailSender es = new EmailSender();

            ViewBag.Title = "medibook Medical Appointment System";
            ViewBag.WelcomeMessage = "Welcome to the medibook medical appointment system. We offer a convenient doctor's appointment service for your health.";
            ViewBag.IsAdmin = false;
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                
                var userIsInRole = db.Users.Any(u => u.Id == userId && u.Roles.Any(r => r.RoleId == "1"));

                ViewBag.IsAdmin = userIsInRole;
            }
            else
            {
                ViewBag.IsAdmin = false;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About us.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us.";

            return View();
        }

        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

    }
}