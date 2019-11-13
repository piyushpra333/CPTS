using CompetencyTrainingProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompetencyTrainingProgram.Controllers
{
    public class HomeController : Controller
    {

        CompetencyContext _db = new CompetencyContext();

        // GET: Home
        public ActionResult Index()
        {
           
            List<Employee> emps = _db.Employees.ToList();
            return View(emps);
        }
    }
}