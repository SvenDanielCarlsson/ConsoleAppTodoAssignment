using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppTodoAssignment.Models;

namespace ConsoleAppTodoAssignment.Data
{
    public class People
    {
        private static Person[] thePerson = new Person[0];
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
                        break;
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

            Array.Resize(ref thePerson, thePerson.Length + 1);  //Increase array, next row sets new person last at array 
            thePerson[thePerson.Length - 1] = person;           //length counts 1-forward, array index counts 0-forward, thus minus 1

            return thePerson[thePerson.Length -1];
        }//End of PersonAdd
        public void Clear()
        {
            Array.Clear(thePerson, 0, thePerson.Length);
            Array.Resize(ref thePerson, 0);
        }
        public bool RemovePerson(int personId)  //If removed object has overload, will it stay if repacing index object has no overload?
        {
            bool foundPerson = false;
            for (int i = 0; i < thePerson.Length; i++)
            {
                if (thePerson[i].PersonID == personId)
                {
                    foundPerson = true;
                    for (int offset = i + 1; offset < thePerson.Length; offset++, i++)
                    {
                        thePerson[i] = thePerson[offset];   //moves array elements one step back, starting from thePerson[i]
                    }                                       //until offset reaches thePerson.length
                    Array.Resize(ref thePerson, thePerson.Length - 1);
                }
            }
            if (foundPerson == false) { throw new ArgumentException("Person ID does not exist and can't be deleted"); }
            return foundPerson;   //Can be used to let user know Removal went well, otherwise replace bool with void
        }//End of RemovePerson
    }
}
