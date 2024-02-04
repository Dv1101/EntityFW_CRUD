using EntityFW_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFW_CRUD.Controllers
{
    public class StudentsController : Controller
    {
        StudentContext db = new StudentContext();
        // GET: Students
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if(ModelState.IsValid)
            { 
                db.Students.Add(s);
                int status = db.SaveChanges();
                if (status > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Data Insert Success !!')</script";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data Insert Failed !!')</script";
                }
            }
            return View();

        }
    }
}