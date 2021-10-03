using System;
using ConsoleAppTodoAssignment.Models;
using ConsoleAppTodoAssignment.Data;

namespace ConsoleAppTodoAssignment
{
    class Program
    {
        static void Main(string[] args)
        {/*
            Console.Write("Enter description: ");
            string todoTestDesc = Console.ReadLine();
            Todo todo = new Todo(0, todoTestDesc);
            Console.WriteLine("TODO: " + todo.Description);

            string inputOne = Console.ReadLine();
            string inputTwo = Console.ReadLine();
            Person person = new Person(0, inputOne, inputTwo);
            Console.WriteLine($"The Id: {person.PersonID}\n" +
                                $"First Name: {person.FirstName}\n" +
                                $"Last Name: {person.LastName}");
            */
            
            Console.WriteLine("TESTPART");
            //people.PersonAdd(person);

            People people = new People();
            Person person = new Person();
            //people.FindById(0);

            Console.Write("\nPlease enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Please enter last name: ");
            string lastName = Console.ReadLine();
            people.PersonAdd(firstName, lastName);

            Console.Write("\nPlease enter first name: ");
            firstName = Console.ReadLine();
            Console.Write("Please enter last name: ");
            lastName = Console.ReadLine();
            people.PersonAdd(firstName, lastName);


            people.Clear();

            Console.WriteLine("\nAfter the Clear\n");
            Console.Write("\nPlease enter first name: ");
            firstName = Console.ReadLine();
            Console.Write("Please enter last name: ");
            lastName = Console.ReadLine();
            people.PersonAdd(firstName, lastName);

            Console.Write("\nPlease enter first name: ");
            firstName = Console.ReadLine();
            Console.Write("Please enter last name: ");
            lastName = Console.ReadLine();
            people.PersonAdd(firstName, lastName);

            Console.Write("\nFIND BY ID\nPlease enter an ID: ");
            int findPerson = Convert.ToInt32(Console.ReadLine());
            people.FindById(findPerson);
            /*
            Console.WriteLine($"Person ID: {people.FindById(findPerson).PersonID}" +
                    $"\nPerson First Name: {people.FindById(findPerson).FirstName}" +
                    $"\nPerson Last Name: {people.FindById(findPerson).LastName}");
            */
           //Console.WriteLine(people.FindAll());
           
        }
    }
}
