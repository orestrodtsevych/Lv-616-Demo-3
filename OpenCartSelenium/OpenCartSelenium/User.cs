using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCartSelenium
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Telephone { get; set; }
        public string MainAdress { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string RegionState { get; set; }
        public string Password { get; set; }

        public string Fax { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public bool Subscribe { get; set; }

        public User() { }
        public static UserBuilder CreateBuilder()
        {
            return new UserBuilder();
        }
    }
}
