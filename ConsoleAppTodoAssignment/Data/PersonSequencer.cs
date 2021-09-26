using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTodoAssignment.Data
{
    public class PersonSequencer
    {
        private static int personId;
        public int PersonID { get { return personId; } }

        public static int nextPersonId() { return personId++; }
        public static int reset() { return personId = 0; }
    }
}
