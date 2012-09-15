using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Entity;
using System.Collections.Generic;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <param name="district"></param>
        /// <param name="street"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="mode">same: tren cung duong, near: cac diem xung quanh</param>
        /// <returns>List of {latitude,longtitude}</returns>
        [OperationContract]
        public List<string> GetStreetStatus(string country, string city,string district, string street, double latitude, double longitude)
        {
            //return "busy";

            return null;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
