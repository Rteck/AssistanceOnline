using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssistanceOnlineDAL;
using AssistanceOnlineBLL;

namespace AssistanceOnline.Controllers
{
    public class CoursesController : Controller
    {
        private AssistanceOnlineContext db = new AssistanceOnlineContext();

        // GET: Courses
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var user = Session["user"] as User;
                return View(CoursesBLL.findCoursesbyUser(user.idUser));
            }

        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.idUser = new SelectList(db.User, "idUser", "name");
                return View();
            }
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCourse,name,description,tokenKey")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                var idUser = (Session["user"] as User).idUser;
                courses.idUser = idUser;
                CoursesBLL.createCourse(courses);
                return RedirectToAction("Index");
            }

            ViewBag.idUser = new SelectList(db.User, "idUser", "name", courses.idUser);
            return View(courses);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUser = new SelectList(db.User, "idUser", "name", courses.idUser);
            return View(courses);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCourse,name,description,tokenKey,creationDate,modificationDate,idUser,active")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUser = new SelectList(db.User, "idUser", "name", courses.idUser);
            return View(courses);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Courses courses = db.Courses.Find(id);
            db.Courses.Remove(courses);
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
        [HttpGet]
        public ActionResult TableCourses()
        {
            var user = Session["user"] as User;
            return PartialView(CoursesBLL.findCoursesbyUser(user.idUser));
        }

        [HttpGet]
        public ActionResult modalCreate()
        {
            Courses course = new Courses();
            return PartialView(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult  CreateForm([Bind(Include = "idCourse,name,description,tokenKey")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                var idUser = (Session["user"] as User).idUser;
                courses.idUser = idUser;
                CoursesBLL.createCourse(courses);
                
            }

            return Json(true);
        }
    }
}
