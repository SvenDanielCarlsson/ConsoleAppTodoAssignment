using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTodoAssignment.Models
{
    public class Person
    {
        readonly int personId;
        string firstName;
        string lastName;

        public int PersonID { get { return personId; } }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                { throw new ArgumentException("First name cannot be null, empty or whitespace"); }
                else { firstName = value; }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                { throw new ArgumentException("Last name cannot be null, empty or whitespace"); }
                else { lastName = value; }
            }
        }
        public Person(int personID, string firstName, string lastName)
        {
            this.personId = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
        }



    }//END OF CLASS PERSON

}
