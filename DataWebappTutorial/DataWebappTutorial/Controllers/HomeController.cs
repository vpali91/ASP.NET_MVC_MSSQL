using DataWebappTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.EmployeeProcessor;

namespace DataWebappTutorial.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewEmployees()
        {
            ViewBag.Message = "Employees List";
            var data = LoadEmployees();
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress
                });
            }
            return View(employees);
        }


        public ActionResult SignUp()
        {
            ViewBag.Message = "Employee SignUp";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateEmployee(model.EmployeeId, model.FirstName, model.LastName, model.EmailAddress);
                return RedirectToAction("ViewEmployees");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            DeleteEmployee(id);
            return RedirectToAction("ViewEmployees");
        }

        public ActionResult Edit()
        {
            ViewBag.Message = "Employee SignUp";
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeModel model)
        {
            var fullUrl = Request.Url.ToString();
            string lastPart = fullUrl.Split('/').Last();
            int numUrl;
            bool isParsable = Int32.TryParse(lastPart, out numUrl);

            if (isParsable)
            {
                int recordsCreated = UpdateEmployee(numUrl, model.FirstName, model.LastName, model.EmailAddress);
                return RedirectToAction("ViewEmployees");
            }

            return View();
        }


    }
}