using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTodoAssignment.Models
{
    public class Person
    {
        readonly int personID;
        string firstName;
        string lastName;

        public int PersonID { get { return personID; } }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                //{ Console.Write("Please enter a valid first name: "); firstName = Console.ReadLine(); }
                { FirstName = NewInput("a valid first name: "); }
                //{ throw new ArgumentException("Bad input for FIRST NAME"); }
                else { firstName = value; }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                //{ Console.Write("Please enter a valid last name: "); lastName = Console.ReadLine(); }
                { LastName = NewInput("a valid last name: "); }
                //{ throw new ArgumentException("Bad input for LAST NAME"); }
                else { lastName = value; }
            }
        }

        public Person()
        {

        }
        public Person(int personID, string firstName, string lastName)
        {
            this.personID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string NewInput(string what) //TEST
        { Console.WriteLine("Please enter " + what); string input = Console.ReadLine(); return input; }





    }//END OF CLASS PERSON

}
