using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlFacturas.Model
{
    public class Member
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public string IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Company { get; set; }
    }
}