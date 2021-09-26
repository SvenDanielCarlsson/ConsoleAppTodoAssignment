using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTodoAssignment.Models
{
    public class Todo
    {
        readonly int todoId;
        string description;
        bool done;
        Person assignee; // = new Person(); ??

        public int TodoID { get { return todoId; } }
        public string Description
        {
            get { return description; }
            set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                { Console.WriteLine("No description entered"); }
                description = value;
            }
        }

        public Todo(int todoId, string description)
        {
            this.todoId = todoId;
            this.Description = description;
        }
    }
}
