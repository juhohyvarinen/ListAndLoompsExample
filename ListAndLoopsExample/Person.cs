using System;
using System.Collections.Generic;
using System.Text;

namespace ListAndLoopsExample
{
    class Person
    {             

        public string firstName;
        public string lastName;
        public string phone;
        public string email;

        public static string tietoa = "Tässä on kaikille tietoa";
        public Person()
        {

        }



        public Person(string firstName, string lastName, string phone, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.email = email;
        }



    }
}
