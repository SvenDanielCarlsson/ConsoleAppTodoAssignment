using ConsoleAppTodoAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTodoAssignment.Data
{
    public class TodoItems
    {
        private static Todo[] theTodos = new Todo[0];
        public int SizeTodo() { return theTodos.Length; }
        public Todo[] FindAllTodo() { return theTodos; }
        public Todo FindByIdTodo(int todoId)
        {
            bool foundTodo = false;

            if (theTodos.Length < 1) { throw new ArgumentException("Sorry, the list is empty"); }
            while (foundTodo == false)
            {
                for (int find = 0; find < theTodos.Length; find++)
                {
                    if (theTodos[find].TodoID == todoId)
                    {
                        foundTodo = true;
                        Console.WriteLine($"Todo ID: {theTodos[todoId].TodoID}\n" +         //DELETE THESE LATER?
                                            $"Todo description: {theTodos[todoId].Description}");
                    }
                }
                if (foundTodo == false)
                {
                    throw new ArgumentException("Id does not exist");
                }
            }
            return theTodos[todoId];
        }// END of FindByIdTodo
        public Todo TodoAdd(string description)
        {
            Todo todo = new Todo(TodoSequencer.nextTodoId(), description);

            Array.Resize(ref theTodos, theTodos.Length + 1);
            theTodos[theTodos.Length - 1] = todo;

            //Console.Clear();
            Console.WriteLine($"Added Todo\n\nID: {todo.TodoID}\nDescription: {todo.Description}");

            return theTodos[theTodos.Length - 1]; //OR return todo ?
        }
        public Todo TodoAdd(string description, Person person)
        {
            Todo todo = new Todo(TodoSequencer.nextTodoId(), description, person);

            Array.Resize(ref theTodos, theTodos.Length + 1);
            theTodos[theTodos.Length - 1] = todo;

            Console.WriteLine($"\nTodo ID: {todo.TodoID}\nTodo Description: {todo.Description}" +
                            $"\nAssignee first name: {todo.Assignee.FirstName}");
            
            return theTodos[theTodos.Length -1];
        }
        public void ClearTodo()
        {
            Array.Clear(theTodos, 0, theTodos.Length);
            Array.Resize(ref theTodos, 0);
            TodoSequencer.resetTodoId();
        }
        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] doneTodo = new Todo[0];
            for (int i = 0; i < theTodos.Length; i++)
            {
                if (theTodos[i].Done == doneStatus)
                {
                    Array.Resize(ref doneTodo, doneTodo.Length + 1);
                    doneTodo[doneTodo.Length - 1] = theTodos[i];
                }
            }
            return doneTodo;
        }
        public Todo[] FindByAssignee(int personId) //returns todos for person who is assigned?
        {
            bool exists = false;
            Todo[] todoForAssignee = new Todo[0];
            
            for (int i = 0; i < theTodos.Length; i++)
            {
                if (theTodos[i].Assignee.PersonID == personId)
                {
                    Array.Resize(ref todoForAssignee, todoForAssignee.Length + 1);
                    todoForAssignee[todoForAssignee.Length - 1] = theTodos[i];
                    exists = true;
                }
            }
            if(exists == false) { throw new ArgumentException($"Assignee with that ID does not exist"); }
            return todoForAssignee;
        }
        public Todo[] FindByAssignee(Person assignee) //Returns array with Todos that has any person assigned to it?
        {
            bool exists = false;
            Todo[] todoForAssignee = new Todo[0];
            for (int i = 0; i < theTodos.Length; i++)
            {
                if (theTodos[i].Assignee == assignee)
                {
                    Array.Resize(ref todoForAssignee, todoForAssignee.Length + 1);
                    todoForAssignee[todoForAssignee.Length - 1] = theTodos[i];
                    exists = true;
                }
            }
            if(exists == false) { throw new ArgumentException("Person does not exist"); } //Redundant?
            return todoForAssignee;
        }
        //public Todo[] FindUnassignedTodoItems()
        //{
        //    Todo[] unnassigned = new Todo[0];
        //    for (int i = 0; i < theTodos.Length; i++)
        //    {
        //        if (theTodos[i]) //if it does not contain, how?
        //        {
        //            Array.Resize(ref unnassigned, unnassigned.Length + 1);
        //            unnassigned[unnassigned.Length - 1] = theTodos[i];
        //        }
        //    }
        //    return unnassigned;
        //}

    }
}
