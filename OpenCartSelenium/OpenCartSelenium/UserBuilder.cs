using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCartSelenium
{
    class UserBuilder
    {
        private User _user;
        public UserBuilder()
        {
            _user = new User();
        }
        public UserBuilder SetFirstName(string firstName)
        {
            _user.FirstName = firstName;
            return this;
        }
        public UserBuilder SetLastName(string lastName)
        {
            _user.LastName = lastName;
            return this;
        }
        public UserBuilder SetEMail(string email)
        {
            _user.eMail = email;
            return this;
        }
        public UserBuilder SetTelephone(string telephone)
        {
            _user.Telephone = telephone;
            return this;
        }
        public UserBuilder SetMainAdress(string adress)
        {
            _user.MainAdress = adress;
            return this;
        }
        public UserBuilder SetCity(string city)
        {
            _user.City = city;
            return this;
        }
        public UserBuilder SetPostCode(string code)
        {
            _user.PostCode = code;
            return this;
        }
        public UserBuilder SetCountry(string country)
        {
            _user.Country = country;
            return this;
        }
        public UserBuilder SetRegionState(string regionState)
        {
            _user.RegionState = regionState;
            return this;
        }
        public UserBuilder SetPassword(string password)
        {
            _user.Password = password;
            return this;
        }
        public UserBuilder SetFax(string fax)
        {
            _user.Fax = fax;
            return this;
        }
        public UserBuilder SetCompany(string company)
        {
            _user.Company = company;
            return this;
        }
        public UserBuilder SetAdress(string adress)
        {
            _user.Address = adress;
            return this;
        }
        public UserBuilder SetSubscribe(bool subscribe)
        {
            _user.Subscribe = subscribe;
            return this;
        }
        public User Build()
        {
            return _user;
        }
    }
}
