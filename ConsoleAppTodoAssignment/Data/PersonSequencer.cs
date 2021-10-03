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
        //public static int nextPersonId { get { return personId; } set { personId++; personId = value; } } //NO GOOD
        public static int reset() { return personId = 0; }
    }
}
