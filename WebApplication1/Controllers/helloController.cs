using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class helloController : Controller
    {

        webEntities1 db;

        public helloController()
        {
            db = new webEntities1();
        }


        // GET: hello
        public ActionResult Index(string option, string search)
        {
            if (option == "Name")
            {
                return View(db.employees.Where(x => x.EmployeeName.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.employees.Where(x => x.EmployeeName == search || search == null).ToList());
            }
           // List<employee> all_data = db.employees.ToList();
            //return View(all_data);
        }

        public ActionResult Create2()
        {
            return View();
        }
        public ActionResult Edit(int ID)
        {
            employee old_data = db.employees.Find(ID);
            return View(old_data);
        }

        public ActionResult SaveData(employee employee)
        {
            db.employees.Add(employee);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult UpdateData(employee employee)
        {
           db.Entry(employee).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult delete(int ID)
        {
            employee data = db.employees.Find(ID);
            db.employees.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}