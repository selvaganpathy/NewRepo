using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCFAssignmentTask2_Web
{
    public class Task2Controller : Controller
    {
        // GET: Task2
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetRole(string role)
        {
            Task task = new Task();
            ServiceReference1.Task2Client task2Client1 = new ServiceReference1.Task2Client("BasicHttpBinding_ITask2");
            task.lstJobOpening = task2Client1.OpeningJobs();
            task.lstJobOpeningByRole = task2Client1.OpeningJobsByRole(role);
            task.strRoleName = role;
            return View("Index",task);
        }
    }

    public class Task
    {
        public string[] lstJobOpening { get; set; }
        public string[] lstJobOpeningByRole { get; set; }

        public string strRoleName { get; set; }

    }
}