using System;
using Xunit;
using ConsoleAppTodoAssignment.Models;

namespace ConsoleAppTodoAssignment.Tests
{
    public class TodoTests
    {
        [Fact]
        public void Todo_Description_GoodInput()
        {   //Assemble
            //Act
            Todo todo = new Todo(01,"a description");
            //Assert
            Assert.Equal(01, todo.TodoID);
            Assert.Equal("a description", todo.Description);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Todo_Description_UnacceptableInput(string todoDescription)
        {   //Arrange
            //Data.TodoSequencer.resetTodoId();
            int id = 1;
            //Act
            ArgumentException resultDescription = Assert.Throws<ArgumentException>(() => new Todo(id, todoDescription));
            //Assert
            Assert.Equal("No description entered", resultDescription.Message);
        }
    }
}
