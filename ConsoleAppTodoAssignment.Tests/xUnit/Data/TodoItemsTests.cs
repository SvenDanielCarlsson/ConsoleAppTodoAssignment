using System;
using Xunit;
using ConsoleAppTodoAssignment.Data;

namespace ConsoleAppTodoAssignment.Tests
{
    public class TodoItemsTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void TodoItems_FindByID_Succes(int index)
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.ClearTodo();
            TodoSequencer.resetTodoId();
            todoItems.TodoAdd("Keep away from bad habits");
            todoItems.TodoAdd("Do not do the bah");
            todoItems.TodoAdd("Avoid the bots");

            //Act
            todoItems.FindByIdTodo(index);
            //Assert
            Assert.NotNull(todoItems.FindByIdTodo(index));
        }



        [Fact]
        public void TodoItems_TodoAdd_Success()
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.ClearTodo();
            TodoSequencer.resetTodoId();
            //Act
            todoItems.TodoAdd("Maybe clear the path");
            //Assert
            Assert.Equal("Maybe clear the path", todoItems.FindByIdTodo(0).Description);
            Assert.Equal(0, todoItems.FindByIdTodo(0).TodoID);
        }
        /*
        [Fact]
        public void People_PersonAdd_Fail()
        {
            //Arrange
            //Models.Person person = new Models.Person();
            People people = new People();
            people.Clear();
            PersonSequencer.reset();
            //Act
            people.PersonAdd("", "");
            people.PersonAdd(" ", " ");
            //Assert
            Assert.NotEqual(2, people.Size());
        }*/

        [Fact]
        public void TodoItems_Size_Check()
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.ClearTodo();
            TodoSequencer.resetTodoId();
            //Act
            todoItems.TodoAdd("Fix guitars");
            todoItems.TodoAdd("Don't nuy more guitars");
            todoItems.TodoAdd("Save for triple screens");
            //Assert
            Assert.Equal(3, todoItems.SizeTodo());
        }
   
    }
}
