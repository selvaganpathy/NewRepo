using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCFAssignmentTask2_Web
{
    public class SimpleCalculatorController : Controller
    {
        // GET: SimpleCalculator
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(int num1, int num2)
        {
            Task task = new Task();
            ServiceReference2.SimpleCalculatorClient task2Client1 = new ServiceReference2.SimpleCalculatorClient("BasicHttpBinding_ISimpleCalculator");
            ViewBag.strResult = task2Client1.Add(num1, num2);
            return View("Index");
        }
        public ActionResult Subtract(int num1, int num2)
        {
            Task task = new Task();
            ServiceReference2.SimpleCalculatorClient task2Client1 = new ServiceReference2.SimpleCalculatorClient("BasicHttpBinding_ISimpleCalculator");
            ViewBag.strResult = task2Client1.Subtract(num1, num2);
            return View("Index");
        }
        public ActionResult Multiply(int num1, int num2)
        {
            Task task = new Task();
            ServiceReference2.SimpleCalculatorClient task2Client1 = new ServiceReference2.SimpleCalculatorClient("BasicHttpBinding_ISimpleCalculator");
            ViewBag.strResult = task2Client1.Multiply(num1, num2);
            return View("Index");
        }
        public ActionResult Divide(int num1, int num2)
        {
            Task task = new Task();
            ServiceReference2.SimpleCalculatorClient task2Client1 = new ServiceReference2.SimpleCalculatorClient("BasicHttpBinding_ISimpleCalculator");
            ViewBag.strResult = task2Client1.Divide(num1, num2);
            return View("Index");
        }
    }
}