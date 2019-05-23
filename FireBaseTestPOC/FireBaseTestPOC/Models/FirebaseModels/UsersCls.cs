using System;
using System.Collections.Generic;

namespace FireBaseTestPOC.Models.FirebaseModels
{
    public class UsersCls
    {

    }

    public class UsersRequestObject
    {
        public long aadhar_card_no { get; set; }
        public string city_current { get; set; }
        public string country_current { get; set; }
        public string email_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        //public List<object> mobile_no_alternative { get; set; }
        public List<long> mobile_no_alternative { get; set; }
        public long mobile_no_primary { get; set; }
        public int pincode_current { get; set; }
        public int pincode_permanent { get; set; }
        public string state_current { get; set; }
        public string street_address { get; set; }
    }

    //public class UsersRequestObject
    //{
    //    public AAdharCardID aadharCardID { get; set; }
    //}
}
