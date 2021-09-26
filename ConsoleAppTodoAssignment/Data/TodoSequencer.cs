using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTodoAssignment.Data
{
    public class TodoSequencer
    {
        private static int todoId;
        public int TodoID { get { return todoId; } }

        public static int nextTodoId() { return todoId++; }
        public static int resetTodoId() { return todoId = 0; }
    }
}
