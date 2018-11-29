using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAssignmentTask2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISimpleCalculator" in both code and config file together.
    [ServiceContract]
    public interface ISimpleCalculator
    {
        [OperationContract]
        double Add(double dblNum1, double dblNum2);
        [OperationContract]
        double Subtract(double dblNum1, double dblNum2);
        [OperationContract]
        double Multiply(double dblNum1, double dblNum2);
        [OperationContract]
        double Divide(double dblNum1, double dblNum2);
    }
}
