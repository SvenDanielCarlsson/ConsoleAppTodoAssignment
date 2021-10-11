using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppTodoAssignment.Models;

namespace ConsoleAppTodoAssignment.Data
{
    public class People
    {
        private static Person[] thePerson = new Person[0]; //check how to declare as not EMPTY or NULL
        public int Size() { return thePerson.Length; }
        public Person[] FindAll() { return thePerson; }
        public Person FindById(int personId)
        {
            bool foundPerson = false;

            if (thePerson.Length < 1) { throw new ArgumentException("Sorry, the list is empty"); } // Thought this through?
            while(foundPerson == false)
            {
                for(int find = 0;  find < thePerson.Length; find++ )
                {
                    if (thePerson[find].PersonID == personId)
                    {
                        foundPerson = true;
                        Console.WriteLine($"ID: {thePerson[personId].PersonID}\n" +         //DELETE THESE LATER
                                            $"First Name: {thePerson[personId].FirstName}\n" +
                                            $"Last Name: {thePerson[personId].LastName}");
                    } 
                }
                if (foundPerson == false)
                {
                    throw new ArgumentException("Id does not exist");
                }
            }
            return thePerson[personId];
        }//End of FindById
        public Person PersonAdd(string firstName, string lastName)
        {
            Person person = new Person(PersonSequencer.nextPersonId(), firstName, lastName);

            Array.Resize(ref thePerson, thePerson.Length + 1);
            thePerson[thePerson.Length - 1] = person;

            return thePerson[thePerson.Length -1];
        }
        public void Clear()
        {
            Array.Clear(thePerson, 0, thePerson.Length);
            Array.Resize(ref thePerson, 0);
            PersonSequencer.reset();
            //thePerson = new Person[0];    //probably bad idea?
        }
    }
}
