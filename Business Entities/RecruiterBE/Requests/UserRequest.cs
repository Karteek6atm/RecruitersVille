using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruiterBE.Requests
{
    public class UserRequest
    {
        public int UserLoginId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string ContactNumber { get; set; }
        public string AboutMe { get; set; }
        public string ProfilePicPath { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string Street { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
    }    
}