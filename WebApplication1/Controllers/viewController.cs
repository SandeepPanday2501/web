using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class viewController : Controller
    {

        webEntities1 db;

        public viewController()
        {
            db = new webEntities1();
        }


        // GET: hello
        public ActionResult list()
        {
            List<student> all_data = db.students.ToList();
            return View(all_data);
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult SaveData(student student)
        {
            db.students.Add(student);
            db.SaveChanges();

            return RedirectToAction("list");
        }

    }
}