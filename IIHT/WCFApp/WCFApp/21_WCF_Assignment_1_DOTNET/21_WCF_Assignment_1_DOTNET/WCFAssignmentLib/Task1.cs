using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFAssignmentLib
{
    public class Task1 : ITask1
    {
        public string SayHello(string name)
        {
            if (DateTime.Now.Hour < 12)
            {
                return "Good Morning " + name + "!";
            }
            else if (DateTime.Now.Hour < 17)
            {
                return "Good Afternoon " + name + "!";
            }
            else
            {
                return "Good Evening " + name + "!";
            }
        }

        public string TodayProgram(string name)
        {
            DayOfWeek day = DateTime.Now.DayOfWeek;
            if ((day == DayOfWeek.Saturday) || (day == DayOfWeek.Sunday))
            {
                return "Happy weekend " + name + "!";
            }
            else
            {
                return "Enjoy Working day " + name + "!";
            }
        }
    }
}
