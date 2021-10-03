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

            if(theTodos.Length < 1) { foundTodo = true; todoId = 0; }
            while(foundTodo == false)
            {
                for(int find = 0; find < theTodos.Length; find++)
                {
                    if (theTodos[find].TodoID == todoId)
                    {
                        foundTodo = true;
                        Console.WriteLine($"Todo ID: {theTodos[todoId].TodoID}\n" +         //DELETE THESE LATER?
                                            $"Todo description: {theTodos[todoId].Description}");
                    }
                }
                if(foundTodo == false)
                {
                    Console.WriteLine("Try another Todo-ID: ");
                    todoId = Convert.ToInt32(Console.ReadLine());
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
        public void ClearTodo()
        {
            Array.Clear(theTodos, 0, theTodos.Length);
            Array.Resize(ref theTodos, 0);
            TodoSequencer.resetTodoId();
        }


    }
}
