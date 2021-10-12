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
                        break;          //Unnecessary to continue for-loop when only looking for one object
                    }
                }
                if (foundTodo == false)
                {
                    throw new ArgumentException("Id does not exist");
                }
            }
            return theTodos[todoId];
        }//End of FindByIdTodo

        public Todo TodoAdd(string description)
        {
            Todo todo = new Todo(TodoSequencer.nextTodoId(), description);

            Array.Resize(ref theTodos, theTodos.Length + 1);
            theTodos[theTodos.Length - 1] = todo;

            return theTodos[theTodos.Length - 1];
        }//End of TodoAdd
        public Todo TodoAdd(string description, Person person)
        {
            Todo todo = new Todo(TodoSequencer.nextTodoId(), description, person);

            Array.Resize(ref theTodos, theTodos.Length + 1);
            theTodos[theTodos.Length - 1] = todo;

            return theTodos[theTodos.Length - 1];
        }//End of TodoAdd-Overload

        public void ClearTodo()
        {
            Array.Clear(theTodos, 0, theTodos.Length);
            Array.Resize(ref theTodos, 0);
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
        }//End of FindByDoneStatus bool

        public Todo[] FindByAssignee(int personId) //return array of Todos tied to assigned personId
        {
            bool exists = false;
            Todo[] todoForAssignee = new Todo[0];

            for (int i = 0; i < theTodos.Length; i++)   //No break; when found, since Assignee can have several Todos
            {
                if (theTodos[i].Assignee.PersonID == personId)
                {
                    Array.Resize(ref todoForAssignee, todoForAssignee.Length + 1);
                    todoForAssignee[todoForAssignee.Length - 1] = theTodos[i];
                    exists = true;
                }
            }
            if (exists == false) { throw new ArgumentException($"Assignee with that ID does not exist"); }
            return todoForAssignee;
        }//End of FindByAssignee personId
        public Todo[] FindByAssignee(Person assignee) //Returns array with Todos that has a person assigned to it
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
            if (exists == false) { throw new ArgumentException("Person does not exist"); } //Redundant?
            return todoForAssignee;
        }//End of FindByAssignee Person assignee

        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] unnassigned = new Todo[0];

            for (int i = 0; i < theTodos.Length; i++)
            {
                if (theTodos[i].Assignee == null)
                {
                    Array.Resize(ref unnassigned, unnassigned.Length + 1);
                    unnassigned[unnassigned.Length - 1] = theTodos[i];
                }
            }
            return unnassigned;
        }//End of FindUnassignedTodoItems

        public bool RemoveTodo(int todoID)
        {
            bool foundTodo = false;
            for (int i = 0; i < theTodos.Length; i++)
            {
                if (theTodos[i].TodoID == todoID)
                {
                    foundTodo = true;
                    for (int offset = i + 1; offset < theTodos.Length; offset++, i++)
                    {
                        theTodos[i] = theTodos[offset];
                    }
                    Array.Resize(ref theTodos, theTodos.Length - 1);
                    break;
                }
            }
            if (foundTodo == false) { throw new ArgumentException("Todo ID does not exist and can't be deleted"); }
            return foundTodo;
        }//End of RemoveTodo

    }
}
