//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymMembersDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Member
    {
        public int MEMBER_ID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public string CITY { get; set; }
        public Nullable<int> CENTER_ID { get; set; }
    
        public virtual Center Center { get; set; }
    }
}