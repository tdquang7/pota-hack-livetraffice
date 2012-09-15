using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Entity;

namespace LiveTrafficServices
{
    [ServiceContract(Namespace = "")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MobileService
    {
        [OperationContract]
        public bool Login(string username, string password)
        {
            User u = new User();
            return u.Login(username, password);
        }

        [OperationContract]
        public bool UpdateStreetStatus(string username, string country, string city,string district, string street, double latitude, double longitude, string status)
        {
            return true;
        }

        [OperationContract]
        public string GetStreetStatus(string country, string city,string district, string street, double latitude, double longitude)
        {
            return "busy";
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
