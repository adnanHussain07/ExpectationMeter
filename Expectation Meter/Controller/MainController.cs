using ExpectationMeter.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpectationMeter.DataServices;

namespace ExpectationMeter.Controllers
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
        public ActionResult Registration()
        {

            return View();
        }
        public ActionResult AddUser(User model)
        {

            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            string message = string.Empty;
            try
            {
                if (model != null)
                {
                    DMLOperations.Instance.AddUser(model);
                    message = "Successfully Saved";
                }
                else
                {

                    message = "Model is Null";
                }
            }


            catch (Exception ex)
            {
                message = ex.Message;
            }
            result.Data = message;
            return result;

        }
        public ActionResult Users()
        {
            var users = DMLOperations.Instance.GetUsers();
            return View(users);


        }
        public ActionResult UpdateUser(int userID) {

            var user = DMLOperations.Instance.GetUser(userID);
            return View(user);
        }
        public JsonResult UpdateUserData(User user)
        {

            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            string message = string.Empty;
            try
            {
                if (user != null)
                {
                    DMLOperations.Instance.UpdateUser(user);
                    message = "Successfully Updated";
                }
                else
                {

                    message = "Model is Null";
                }
            }


            catch (Exception ex)
            {
                message = ex.Message;
            }
            result.Data = message;
            return result;



        }
        public JsonResult DeleteUser(int userID)
        {

            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            string message = string.Empty;
            try
            {
                DMLOperations.Instance.DeleteUser(userID);
                    message = "Successfully Deleted";
               
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            result.Data = message;
            return result;
        }
    }
}
