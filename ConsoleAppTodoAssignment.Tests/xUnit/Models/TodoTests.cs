using System;
using Xunit;
using ConsoleAppTodoAssignment.Models;

namespace ConsoleAppTodoAssignment.Tests
{
    public class TodoTests
    {
        [Fact]
        public void Todo_GoodInput01()
        {   //Assemble
            //Act
            Todo todo = new Todo(01,"a description");
            //Assert
            Assert.Equal(01, todo.TodoID);
            Assert.Equal("a description", todo.Description);
        }
        [Theory]
        [InlineData(01, "")]
        [InlineData(01, null)]
        [InlineData(01, " ")]
        public void Todo_GoodInput02(int iD, string todoDescription)
        {   //Arrange
            //Act
            Todo todo = new Todo(iD, todoDescription);
            //Assert
            Assert.Equal(iD, todo.TodoID);
            Assert.Equal(todoDescription, todo.Description);
        }
    }
}
