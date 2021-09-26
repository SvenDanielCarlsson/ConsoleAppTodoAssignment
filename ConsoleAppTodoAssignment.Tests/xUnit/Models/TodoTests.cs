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
        /*
        [Theory]
        [InlineData(01, "")]
        [InlineData(01, null)]
        [InlineData(01, " ")]
        public void Todo_BadInput02(int iD, string todoDescription)
        {   //Arrange
            Todo todo = new Todo(iD, todoDescription);
            //Act
            Action action = () => todoDescription;
            //Assert
            Assert.Throws<NotImplementedException>(action);
        }*/
    }
}
