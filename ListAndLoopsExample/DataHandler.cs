using System;
using System.Collections.Generic;
using System.Text;

namespace ListAndLoopsExample
{
    class DataHandler
    {
        public List<Coffee> coffees = new List<Coffee>();
        public List<Person> persons = new List<Person>();
        
        public Coffee CreateCoffee()
        {
            Console.WriteLine("Anna kahvin merkki.");
            var merkki = Console.ReadLine();
            //syötetään hinta, paahto 1-5
            //ei companyä
            Coffee toReturn = new Coffee(merkki);
            toReturn.roast = (Coffee.Roast)2;
            return toReturn;

           
        }
        public Person CreatePerson()
        {
            var marker = Console.ReadLine();
            Person toReturn = new Person(marker);
            toReturn.Person = (Person.)
            Console.WriteLine("Anna henkilö");

            return toReturn;


        }



    }
}
