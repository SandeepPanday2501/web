using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmpController : Controller
    {

        webEntities1 db;

        public EmpController()
        {
            db = new webEntities1();
        }


        // GET: hello
        public ActionResult sal()
        {
            var employee_salary_date = db.employee_salary_date.ToList();
            return View(employee_salary_date);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(employee_salary_date employee_salary_date)
        {
            db.employee_salary_date.Add(employee_salary_date);
            db.SaveChanges();
            return RedirectToAction("sal");
        }


    }
}