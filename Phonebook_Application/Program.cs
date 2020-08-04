using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, Person> phoneBookDictionary = new Dictionary<double, Person>();

            // PRESET CONTACTS ---------------------------------------------
            Person Zuri = new Person();
            Zuri.phoneNumber = 6159178627;
            Zuri.firstName = "Zuri";
            Zuri.lastName = "Zuniga";
            Zuri.addresslisting.street = "1300 Fox Chase Dr.";
            Zuri.addresslisting.city = "Arnold";
            Zuri.addresslisting.zipCode = "63010";
            phoneBookDictionary.Add(6159178627, Zuri);

            Person Sam = new Person();
            Sam.phoneNumber = 6153456789;
            Sam.firstName = "Sam";
            Sam.lastName = "Gamgee";
            Sam.addresslisting.street = "123 Moria Dr.";
            Sam.addresslisting.city = "Arnold";
            Sam.addresslisting.zipCode = "63020";
            phoneBookDictionary.Add(6153456789, Sam);

            Person Frodo = new Person();
            Frodo.phoneNumber = 6159876543;
            Frodo.firstName = "Frodo";
            Frodo.lastName = "Baggins";
            Frodo.addresslisting.street = "312 Hills Dr.";
            Frodo.addresslisting.city = "Arnold";
            Frodo.addresslisting.zipCode = "63000";
            phoneBookDictionary.Add(6159876543, Frodo);
            // END OF PRESET CONTACTS ======================================
            do
            {
                printUserOptions();

                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            {
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("Follow the prompts and hit ENTER when finished.\n" +
                                                          "First please enter the new phone number.");
                                        double phoneNumber = Convert.ToDouble(Console.ReadLine());

                                        phoneBookDictionary.Add(phoneNumber, Contact(phoneNumber));
                                        Console.WriteLine("Thanks! Got it added." + Environment.NewLine + "*------------------------*" + Environment.NewLine);

                                    }
                                    catch
                                    {
                                        Console.WriteLine("Sorry an error occurred.");


                                    }
                                    Console.WriteLine("Hit 'ENTER' for another contact entry or type 'Main' to return to main menu.");
                                }

                                while (Console.ReadLine() != "Main");
                                Console.WriteLine();
                                break;

                            }
                        case 2:
                            {
                                Console.WriteLine("Enter first name to search:");
                                string findname = Console.ReadLine();
                                foreach (Person personAdd in phoneBookDictionary.Values)
                                {
                                    if (personAdd.firstName.Equals(findname))
                                    {
                                        Console.WriteLine("Results for " + findname);
                                        SearchResults(personAdd);
                                    }

                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Enter last name to search: ");
                                string findLastName = Console.ReadLine();
                                foreach (Person personAdd in phoneBookDictionary.Values)
                                {
                                    if (personAdd.lastName.Equals(findLastName))
                                    {
                                        SearchResults(personAdd);
                                    }
                                }

                                Console.WriteLine("Thanks for searching! Hit Enter to return to the main menu.");
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Enter a city to search: ");
                                string citySearch = Console.ReadLine();
                                foreach (Person personAdd in phoneBookDictionary.Values)
                                {
                                    if (personAdd.addresslisting.city.Equals(citySearch))
                                    {
                                        SearchResults(personAdd);
                                        Console.WriteLine(Environment.NewLine);
                                    }
                                }
                                break;
                            }

                        case 5:
                            {
                                Console.WriteLine("What contact do you want to delete? (Search by first name please!");
                                string findname = Console.ReadLine();
                                Dictionary<double, Person> tempHashtable = phoneBookDictionary;
                                foreach (Person personAdd in phoneBookDictionary.Values)
                                {
                                    if (personAdd.firstName.Equals(findname))
                                    {
                                        tempHashtable.Remove(personAdd.phoneNumber);
                                        Console.WriteLine(Environment.NewLine);
                                    }
                                }
                                phoneBookDictionary = tempHashtable;
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("Contacts Sorted By First Name: ");
                                var firstnamesort = phoneBookDictionary
                                                    .OrderBy(n => n.Value.firstName)
                                                    .Select(n => n.Value);
                                foreach (Person personAdd in firstnamesort)
                                {
                                    SearchResults(personAdd);
                                    Console.WriteLine(Environment.NewLine);
                                }
                                break;
                            }
                        case 7:

                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Not sure what you entered. Try again!");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Error, try again!");
                }
            } 
            
            while (true);

        }

        public static void printUserOptions()
        {
            Console.WriteLine("-------P h o n e b o o k  A p p l i c a t i o n-------" + Environment.NewLine
                + "TYPE A NUMBER AND PRESS ENTER FROM THE FOLLOWING OPTIONS:" + Environment.NewLine +
                "1. Add a new contact" + Environment.NewLine +
                "2. Search contact by first name" + Environment.NewLine +
                "3. Search contact by last name" + Environment.NewLine +
                "4. Search contact by city" + Environment.NewLine +
                "5. Delete a contact by first name" + Environment.NewLine +
                "6. Sort the list by contact’s first name " + Environment.NewLine +
                "7. Exit" + Environment.NewLine);
        }

        public static Person Contact(double phoneNumber)
        {
            Person personAdd = new Person();
            personAdd.phoneNumber = phoneNumber;
            Console.WriteLine("First Name:");
            personAdd.firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            personAdd.lastName = Console.ReadLine();
            Console.WriteLine("Address INFO-------------");
            Console.Write("Street Number: ");
            personAdd.addresslisting.street = Console.ReadLine();
            Console.Write("City: ");
            personAdd.addresslisting.city = Console.ReadLine();
            Console.Write("Zip Code: ");
            personAdd.addresslisting.zipCode = Console.ReadLine();

            return personAdd;
        }

        public static void SearchResults(Person personAdd)
        {
            Console.WriteLine("------------Search Results:------------");
            Console.WriteLine(personAdd.firstName + " " + personAdd.lastName);
            Console.WriteLine("Address: \n" +
                personAdd.addresslisting.street + "\n" +
                personAdd.addresslisting.city + "\n" +
                personAdd.addresslisting.zipCode);


        }

    }
}
