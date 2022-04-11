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
        public ActionResult Index(string option, string search)
        {
            if (option == "name")
            {
                return View(db.employees.Where(x => x.EmployeeName.StartsWith(search) || search == null).ToList());
            }
            else if (option == "id")
            {
                return View(db.employees.Where(x => x.EmployeeID.ToString().Equals(search) || search == null).ToList());
            }
            else
            {
                List<employee> alldata = db.employees.ToList();
                return View(alldata);
            }
        
        }
        public ActionResult Emplo()
        {

          var employee_salary_date = db.employee_salary_date.ToList();
          return View(employee_salary_date);
        }
        public ActionResult create3()
        {
            var employeelist=db.employees.ToList();
            ViewBag.employeelist = new SelectList(employeelist,"EmployeeID","EmployeeName");
            return View();
        }
        [HttpPost]
        public ActionResult SaveData(employee_salary_date employee_salary_date)
        {
            db.employee_salary_date.Add(employee_salary_date);
            db.SaveChanges();
            return RedirectToAction("Emplo");
        }
         public ActionResult EditSal(int ID)
        {
            var employeelist = db.employees.ToList();
            ViewBag.employeelist = new SelectList(employeelist, "EmployeeID", "EmployeeName");
            employee_salary_date data = db.employee_salary_date.Find(ID);
            return View(data);

        }
        public ActionResult UpdateData1(employee_salary_date employee_salary_date)
        {
            db.Entry(employee_salary_date).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Emplo");
        }
        public ActionResult delete2(int ID)
        {
            employee_salary_date data = db.employee_salary_date.Find(ID);
            db.employee_salary_date.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Emplo");
        }



    }
}