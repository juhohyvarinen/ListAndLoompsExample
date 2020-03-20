using System;
using System.Collections.Generic;
using System.Text;

namespace ListAndLoopsExample
{
    class Company
        

    {
        public string name;
        public Person contactPerson;
        public string country;
        


    public Company()
        {

        }

        public Company(string name, Person contactPerson, string country)
        {
            this.name = name;
            this.contactPerson = contactPerson;
            this.country = country;
            
        }

    }
}
