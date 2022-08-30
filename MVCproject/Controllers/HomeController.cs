using MVCproject.Models.DBModel;
using MVCproject.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MVCproject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
           
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Register(CustomerInfo customerInfo)
        {

            try
            {
                //Instantiate Db Context
                var db = new CustomerModel();

                //Create an instance of the customers class
                Customer nCustomer = new Customer();

                //Add values from the view model
                nCustomer.FirstName = customerInfo.firstName;
                nCustomer.MiddleName = customerInfo.middleName;
                nCustomer.LastName = customerInfo.lastName;
                nCustomer.PhoneNumber = customerInfo.phoneNumber;
                nCustomer.DOB = customerInfo.DOB;
                nCustomer.Email = customerInfo.email;


                //Add Customers info to database
                db.Customers.Add(nCustomer);

                //Save customers info to database
                db.SaveChanges();
                return RedirectToAction("SuccessfullReg");
            }
            catch (Exception )
            {
                ViewBag.ErrorMessage = "Try back later";
                return View();
            }

        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Message = "Your registraton page";

            return View();
        }

        public ActionResult SuccessfullReg()
        {
            return View();
        }
    }
}