using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiqueRico.Web
{
    public class Person
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}