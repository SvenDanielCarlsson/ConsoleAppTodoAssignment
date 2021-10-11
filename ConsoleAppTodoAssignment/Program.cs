using System;
using ConsoleAppTodoAssignment.Models;
using ConsoleAppTodoAssignment.Data;

namespace ConsoleAppTodoAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People();

            TodoItems todoItems = new TodoItems();
            todoItems.TodoAdd("kratta mera", people.PersonAdd("mats", "karlsson"));
        }
    }
}
