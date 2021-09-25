using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTodoAssignment.Models
{
    public class Person
    {
        //Person person = new Person();
        readonly int personID;
        string firstName;
        string lastName;

        public int PersonID { get { return personID; } }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                { throw new Exception("Bad input for FIRST NAME"); }
                firstName = value;
            }
        }
        public string LastName 
        {
            get { return lastName; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                { throw new Exception("Bad input for LAST NAME"); }
                lastName = value;
            }
        }

        public Person()
        {

        }
        public Person(int personID, string firstName, string lastName)
        {
            this.personID = personID;
            this.firstName = firstName;
            this.lastName = lastName;
        }





    }//END OF CLASS PERSON

}
