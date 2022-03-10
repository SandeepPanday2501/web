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
        public ActionResult Index()
        {
            List<employee> all_data = db.employees.ToList();
            return View(all_data);
        }
    }
}