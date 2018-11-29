using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAssignmentTask2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Task2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Task2.svc or Task2.svc.cs at the Solution Explorer and start debugging.
    public class Task2 : ITask2
    {
        public List<string> OpeningJobs()
        {
            List<string> lstJobOpening = new List<string>
           {
               "Software engineer",
               "Civil engineer",
               "HR",
               "Adminstration"
           };

            return lstJobOpening;
        }

        public List<string> OpeningJobsByRole(string role)
        {
            List<string> lstJobOpening = new List<string>();
            switch (role)
            {
                case "Software engineer":
                    lstJobOpening = new List<string>
                                                               {
                                                                   "Developer",
                                                                   "Senior Developer"
                                                               };
                    break;
                case "Civil engineer":
                    lstJobOpening = new List<string>
                                                               {
                                                                   "Assistent",
                                                                   "Field Worker"
                                                               };
                    break;
                case "HR":
                    lstJobOpening = new List<string>
                                                               {
                                                                   "Recuriter",
                                                                   "Management"
                                                               };
                    break;
                default:
                    lstJobOpening = new List<string>
                                                               {
                                                                   "Software engineer",
                                                                   "Civil engineer",
                                                                   "HR",
                                                                   "Adminstration"
                                                               };
                    break;
            }

            return lstJobOpening;
        }
    }
}
