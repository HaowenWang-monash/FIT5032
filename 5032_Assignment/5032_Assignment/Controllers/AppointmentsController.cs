using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _5032_Assignment.Models;
using Microsoft.AspNet.Identity;

namespace _5032_Assignment.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private Model3 db = new Model3();

        // GET: Appointments
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userAppointments = db.Appointment.Include(a => a.Doctors).Where(a => a.UserId == currentUserId).ToList();

            return View(userAppointments);
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Include(a => a.Doctors).SingleOrDefault(a => a.Id == id);

            if (appointment == null)
            {
                return HttpNotFound();
            }

            string currentUserId = User.Identity.GetUserId();
            if (appointment.UserId != currentUserId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "You are not authorized to view this appointment.");
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            var doctors = db.Doctors.ToList();

    ViewBag.DoctorList = new SelectList(doctors, "DoctorId", "FirstName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LocationId,DoctorId,AppointmentTime")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                appointment.UserId = userId;
                var doctors = db.Doctors.ToList();
                ViewBag.DoctorList = new SelectList(doctors, "DoctorId", "FirstName");

                bool exists = db.Appointment.Any(a => a.DoctorID == appointment.DoctorID && a.AppointmentTime == appointment.AppointmentTime);
                if (exists)
                {
                    ModelState.AddModelError("", "This doctor has an existing appointment at this time.");
                    return View(appointment);
                }




                db.Appointment.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(appointment);
        }


        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,AppointmentTime")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointment.Find(id);
            db.Appointment.Remove(appointment);
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
