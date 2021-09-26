using System;
using ConsoleAppTodoAssignment.Models;

namespace ConsoleAppTodoAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Person person = new Person(0, "Daniel", "Matsson");
            Person person = new Person();
            Console.Write("Enter first name: ");
            person.FirstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            person.LastName = Console.ReadLine();

            //person.FirstName = "Daniel";
            //person.LastName = "Mattan";
            Console.WriteLine("Id: " + person.PersonID);
            Console.WriteLine("Firstname: " + person.FirstName);
            Console.WriteLine("Lastname: " + person.LastName);

            Console.Write("Enter description: ");
            string todoTestDesc = Console.ReadLine();
            Todo todo = new Todo(0, todoTestDesc);
            Console.WriteLine("TODO: " + todo.Description);


        }
    }
}
