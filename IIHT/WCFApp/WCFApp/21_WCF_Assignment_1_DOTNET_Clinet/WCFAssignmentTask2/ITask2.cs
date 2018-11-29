using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAssignmentTask2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITask2" in both code and config file together.
    [ServiceContract]
    public interface ITask2
    {
        [OperationContract]
        List<string> OpeningJobs();
        [OperationContract]
        List<string> OpeningJobsByRole(string role);
    }
}
