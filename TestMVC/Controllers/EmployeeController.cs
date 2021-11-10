using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    [RoutePrefix("Employee")]
    public class EmployeeController : Controller
    {
        OfficeManagmentContext context = new OfficeManagmentContext();
        // GET: Employee
        [Route("GetEmployees")]
        public ActionResult Index()
        {
            var lstEmployee = context.Employee_tb.ToList();
            return View(lstEmployee);
        }


        public ActionResult Create()
        {
            return View();

        }
    }
}