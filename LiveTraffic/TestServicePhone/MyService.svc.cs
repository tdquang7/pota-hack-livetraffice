using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace TestServicePhone
{
    [ServiceContract(Namespace = "")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MyService
    {
        [OperationContract]
        public int Sum(int a, int b)
        {
            // Add your operation implementation here
            return a + b;
        }


        // Add more operations here and mark them with [OperationContract]
    }
}
