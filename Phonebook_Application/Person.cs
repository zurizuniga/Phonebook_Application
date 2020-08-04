using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook_Application
{
    class Person
    {
        // Person class will have a contact’s details e.g. First Name, Last name etc

        public string firstName; 
        public string lastName;
        public Address addresslisting = new Address();
        public double phoneNumber;
    }
}
