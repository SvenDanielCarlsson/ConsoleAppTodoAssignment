using System;
using Xunit;
using ConsoleAppTodoAssignment.Data;

namespace ConsoleAppTodoAssignment.Tests
{
    public class TodoSequencerTests
    {
        [Fact]
        public void TodoSequencer_IncreaseTodoId()
        {
            //Arrange
            //TodoSequencer.resetTodoId();
            TodoSequencer todoSQ = new TodoSequencer();
            int forCount = 8;
            //Act and Assert
            for (int i = 0; i < forCount; i++)
            {
                TodoSequencer.nextTodoId();
                Assert.Equal(i + 1, todoSQ.TodoID);
            }
            Assert.Equal(forCount, todoSQ.TodoID);
        }
        [Fact]
        public void TodoSequenser_ResetTodoId()
        {
            //Arrange
            TodoSequencer todoSQ = new TodoSequencer();
            for (int i = 0; i < 5; i++) { TodoSequencer.nextTodoId(); }
            //Act
            TodoSequencer.resetTodoId();
            //Assert
            Assert.Equal(0, todoSQ.TodoID);
        }
    }
}
