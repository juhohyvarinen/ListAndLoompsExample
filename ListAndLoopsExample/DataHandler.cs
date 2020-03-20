using System;
using System.Collections.Generic;
using System.Text;

namespace ListAndLoopsExample
{
    class DataHandler
    {
        public List<Coffee> coffees = new List<Coffee>();
        public List<Person> persons = new List<Person>();
        public List<Company> companies = new List<Company>();

        public void FillPersonsWithTestData()
        {
            this.persons.Add(new Person("Teppo", "Testipersoona", "050-888 4444", "teppo@testaus.fi"));
            this.persons.Add(new Person("Tapio", "Tapaustesti", "030-448 2244", "tapsa@testaus.fi"));
        }


        public void FillCompaniesWithTestData()
        {
            Person contactPerson1 = new Person("Teppo", "Testipersoona", "050-888 4444", "teppo@testaus.fi");
            Company testCompany = new Company("testiyritys-1", contactPerson1, "Finland");
            this.companies.Add(testCompany);
        }

        public void FillCoffeesWithTestData()
        {
            Person contactPerson1 = new Person("Teppo", "Testipersoona", "050-888 4444", "teppo@testaus.fi");
            Company testCompany = new Company("testiyritys-1", contactPerson1, "Finland");
            Coffee coffee = new Coffee("Presidentti", 3.20, Coffee.Roast.medium, testCompany);
            this.coffees.Add(coffee);
            coffee = new Coffee("Brazil", 4.80, Coffee.Roast.darkmedium, testCompany);
            this.coffees.Add(coffee);
        }
        public Person CreatePerson()
        {
            Console.WriteLine("Anna nimi: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Anna sukunimi: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Anna puhelinnumero: ");
            string phone = Console.ReadLine();

            Console.WriteLine("Anna sähköposti: ");
            string email = Console.ReadLine();

            Person toReturn = new Person(firstName, lastName, phone, email);

            return toReturn;
        }

        #region Person stuff
        public Person AddNewPersonToList()
        {
            Person person = CreatePerson();
            this.persons.Add(person);
            Console.WriteLine("Henkilö Lisätty listaan");
            return person;
        }

        public void PrintPersonList()
        {
            if(this.persons.Count == 0)
            {
                Console.WriteLine("Henkilölista on tyhjä.");
                return;
            }
            for (int i = 0; i < this.persons.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {this.persons[i].firstName} {this.persons[i].lastName}");
            }

        }

         public Person SelectPersonFromList()
        {
            PrintPersonList();
            Console.WriteLine("Syötä valittavan henkilön numero:");
            var selected = int.Parse(Console.ReadLine());

            return this.persons[selected - 1];
        }


        #endregion

        #region Company stuff

        public Company CreateCompany()
        {
            Console.WriteLine("Anna yrityksen nimi:");
            string name = Console.ReadLine();
            Console.WriteLine("Anna yrityksen maa:");
            string country = Console.ReadLine();

            //later we add possibility to choose from list or add a new person.
            bool personIsSelected = false;

            Person contactPerson = null;

            while (!personIsSelected)
            {
                Console.Clear();

                Console.WriteLine("1. Valiste yhteyshenkilö listasta.");
                Console.WriteLine("2. Lisää uusi yhteyshenkilö.");
                Console.WriteLine("3. Ei yhteyshenkilöä.");
                var selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        contactPerson = SelectPersonFromList();
                        personIsSelected = true;
                        break;
                    case 2:
                        //Note. At this point AddNewPersonToList is edited 
                        //so, that it also returns the Person added to the list.
                        contactPerson = AddNewPersonToList();
                        personIsSelected = true;
                        break;
                    case 3:
                        //contactPerson is already null, so just end this while loop.
                        personIsSelected = true;
                        break;
                    default:
                        personIsSelected = false;
                        break;
                }
            }

            Company company = new Company(name, contactPerson, country);

            return company;
        }

        public Company AddNewCompanyToList()
        {
            Company company = CreateCompany();
            this.companies.Add(company);
            Console.WriteLine("Yritys lisättiin listaan.");
            return company;
        }

        public void PrintCompanyList()
        {
            //if the list is empty -> return
            if (this.companies.Count == 0)
            {
                Console.WriteLine("Yrityslista on tyhjä.");
                return;
            }

            int i = 1;
            foreach (Company company in this.companies)
            {

                Console.WriteLine($"{i}.\tNimi:{company.name}");
                Console.WriteLine($"\tYhteyshenkilö:{company.contactPerson.firstName} {company.contactPerson.lastName}");
                i++;
            }
        }

        public Company SelectCompanyFromList()
        {
            PrintCompanyList();
            Console.WriteLine("Syötä valittavan yrityksen numero:");
            //parse to int
            int selected = int.Parse(Console.ReadLine());
            return this.companies[selected - 1];
        }

        #endregion

        public Coffee CreateCoffee()
        {
            Console.WriteLine("Anna kahvin merkki.");
            string brand = Console.ReadLine();

            Console.WriteLine("Anna kahvin hinta.");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Anna paahteisuus aste (1-5): ");
            int number = int.Parse(Console.ReadLine());
            Coffee.Roast roast = (Coffee.Roast)number;
            //syötetään hinta, paahto 1-5
            //ei companyä

            Company importer = null;
            bool importerSelected = false;
            while (!importerSelected) ;
            {
                Console.Clear();

                Console.WriteLine("Mikä on maahantuova yritys?");
                Console.WriteLine("1. Valitse yritys listasta.");
                Console.WriteLine("2. Uusi yritys.");
                int selected = int.Parse(Console.ReadLine());
                switch (selected)
                {
                    case 1:
                        Console.Clear();
                        importer = SelectCompanyFromList();
                        importerSelected = true;
                        break;
                    case 2:
                        Console.Clear();
                        importer = AddNewCompanyToList();
                        importerSelected = true;
                        break;
                    case 3:
                        importer = null;
                        importerSelected = true;
                        break;
                    default:
                        break;
                }
            }
            Coffee newCoffeeObject = new Coffee(brand, price, roast, importer);
            return newCoffeeObject;
        }

        public void AddNewCoffeeToList()
        {
            Coffee toAdd = CreateCoffee();
            this.coffees.Add(toAdd);
            Console.WriteLine("Kahvi lisättiin listaan.");
        }

        public void PrintCoffeeList()
        {
            //if the list is empty -> return
            if (this.coffees.Count == 0)
            {
                Console.WriteLine("Kahvi on tyhjä.");
                return;
            }

            int i = 1;
            foreach (Coffee coffee in this.coffees)
            {

                Console.WriteLine($"{i}.\tMerkki:{coffee.brand}");
                Console.WriteLine($"\tPaahteisuus:{coffee.roast}");
                Console.WriteLine($"\tMaahantuoja:{coffee.importer.name}");
                i++;
            }
        }

        public Coffee SelectCoffeeFromList()
        {
            PrintCoffeeList();
            Console.WriteLine("Syötä valittavan yrityksen numero:");
            //parse to int
            var selected = int.Parse(Console.ReadLine());
            return this.coffees[selected - 1];
        }

        

    }
}
       


        



    

