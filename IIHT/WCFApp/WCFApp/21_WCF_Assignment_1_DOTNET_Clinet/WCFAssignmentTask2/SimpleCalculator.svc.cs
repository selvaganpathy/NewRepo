using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAssignmentTask2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SimpleCalculator" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SimpleCalculator.svc or SimpleCalculator.svc.cs at the Solution Explorer and start debugging.
    public class SimpleCalculator : ISimpleCalculator
    {
        public double Add(double dblNum1, double dblNum2)
        {
            return (dblNum1 + dblNum2);
        }

        public double Subtract(double dblNum1, double dblNum2)
        {
            return dblNum1 - dblNum2;
        }

        public double Multiply(double dblNum1, double dblNum2)
        {
            return (dblNum1 * dblNum2);
        }

        public double Divide(double dblNum1, double dblNum2)
        {
            return ((dblNum2 == 0) ? 0 : (dblNum1 / dblNum2));
        }
    }
}
