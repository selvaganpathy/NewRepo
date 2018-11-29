using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHostClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1Client task1Client = new Task1Client("NetTcpBinding_ITask1");
            Console.WriteLine("Net TCP Binding Example!");
            Console.WriteLine("********************************");
            Console.WriteLine(task1Client.SayHello("Gokulakrishnan") + "\n");
            Console.WriteLine(task1Client.TodayProgram("Gokulakrishnan") + "\n");


            Task1Client Task1Client2 = new Task1Client("BasicHttpBinding_ITask1");
            Console.WriteLine("HTTP Binding Example!");
            Console.WriteLine("********************************");
            Console.WriteLine(task1Client.SayHello("Krishnan") + "\n");
            Console.WriteLine(task1Client.TodayProgram("Krishnan") + "\n");
            Console.ReadLine();
        }
    }
}
