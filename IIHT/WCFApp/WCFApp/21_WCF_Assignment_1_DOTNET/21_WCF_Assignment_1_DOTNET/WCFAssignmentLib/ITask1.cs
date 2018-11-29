using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFAssignmentLib
{
    [ServiceContract]
    public interface ITask1
    {
        [OperationContract]
        string SayHello(string name);

        [OperationContract]
        string TodayProgram(string name);
    }
}
