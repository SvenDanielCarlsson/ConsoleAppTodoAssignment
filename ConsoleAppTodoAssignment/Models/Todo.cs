using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTodoAssignment.Models
{
    public class Todo
    {
        readonly int todoId;
        bool done;
        string description;
        Person assignee;

        public Person Assignee { get { return assignee; } set { assignee = value; } }
        
        public int TodoID { get { return todoId; } }
        public bool Done { get { return done; } set { done = value; } }
        public string Description
        {
            get { return description; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                { throw new ArgumentException("No description entered"); }
                else { description = value; }
            }
        }
        public Todo(int todoId, string description)
        {
            this.Done = false;
            this.todoId = todoId;
            this.Description = description;
        }
        public Todo(int todoId, string description, Person assignee)    //Made an overload to be able to assign a Person
        {
            this.Done = false;
            this.todoId = todoId;
            this.Description = description;
            this.Assignee = assignee;
        }
    }
}
