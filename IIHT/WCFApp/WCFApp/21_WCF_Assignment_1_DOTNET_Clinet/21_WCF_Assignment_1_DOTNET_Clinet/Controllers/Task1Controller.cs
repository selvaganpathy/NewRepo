using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _21_WCF_Assignment_1_DOTNET_Clinet
{
    public class Task1Controller : Controller
    {
        // GET: Task1
        public ActionResult Index(string id)
        {
            
            Task1 task = new Task1();
            if (id == "1")
            {
                ServiceReference1.Task1Client task1Client = new ServiceReference1.Task1Client("BasicHttpBinding_ITask1");
                task.SayHello = task1Client.SayHello("Gokulakrishnan - Http Request");
                task.TodayProgram = task1Client.TodayProgram("Gokulakrishnan - Http Request");
                ViewBag.Type1 = "Http Request - Say Hello :";
                ViewBag.Type2 = "Http Request - TodayProgram :";
            }
            else if (id == "2")
            {
                ServiceReference1.Task1Client task1Client1 = new ServiceReference1.Task1Client("NetTcpBinding_ITask1");
                task.SayHello = task1Client1.SayHello("Gokulakrishnan - Net TCP Request");
                task.TodayProgram = task1Client1.TodayProgram("Gokulakrishnan - Net TCP Request");
                ViewBag.Type1 = "Net TCP Request  - Say Hello :";
                ViewBag.Type2 = "Net TCP Request - TodayProgram :";
            }
            return View(task);
        }

    }

    public class Task1
    {
        public string TodayProgram { get; set; }
        public string SayHello { get; set; }
    }
}