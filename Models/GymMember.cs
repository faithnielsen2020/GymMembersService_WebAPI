using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMembersService.Models
{
    public class GymMember
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public string CenterID { get; set; }



    }
}