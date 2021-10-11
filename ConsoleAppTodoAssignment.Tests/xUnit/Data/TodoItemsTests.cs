using System;
using Xunit;
using ConsoleAppTodoAssignment.Data;

namespace ConsoleAppTodoAssignment.Tests
{
    public class TodoItemsTests
    {
        [Fact]
        public void TodoItems_FindAll()
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.ClearTodo();
            int amount = 5;
            //Act
            for (int i = 0; i < amount; i++) { todoItems.TodoAdd("Mathparty"); }
            //Assert
            Assert.Equal(amount, todoItems.FindAllTodo().Length);
        }
        [Fact]
        public void TodoItems_FindByID_Succes()
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.ClearTodo();
            //Act
            todoItems.TodoAdd("Keep away from bad habits");
            todoItems.TodoAdd("Do not do the bah");
            todoItems.TodoAdd("Avoid the bots");
            //Assert
            Assert.Equal("Keep away from bad habits", todoItems.FindByIdTodo(0).Description);
            Assert.Equal("Do not do the bah", todoItems.FindByIdTodo(1).Description);
            Assert.Equal("Avoid the bots", todoItems.FindByIdTodo(2).Description);
        }
        [Fact]
        public void TodoItems_FindByID_Fail_IdDoesNotExist()
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.ClearTodo();
            todoItems.TodoAdd("something todo");
            //Act
            ArgumentException resultFail = Assert.Throws<ArgumentException>(() => todoItems.FindByIdTodo(3));
            //Assert
            Assert.Equal("Id does not exist", resultFail.Message);
        }
        [Fact]
        public void TodoItems_FindById_Fail_EmptyArray()
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.ClearTodo();
            //Act
            ArgumentException resultEmpty = Assert.Throws<ArgumentException>(() => todoItems.FindByIdTodo(1));
            //Assert
            Assert.Equal("Sorry, the list is empty", resultEmpty.Message);
        }


        [Fact]
        public void TodoItems_TodoAdd_Success()
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.ClearTodo();
            //Act
            todoItems.TodoAdd("Maybe clear the path");
            todoItems.TodoAdd("Do more tests");
            //Assert
            Assert.Equal("Maybe clear the path", todoItems.FindByIdTodo(0).Description);
            Assert.Equal(0, todoItems.FindByIdTodo(0).TodoID);
            Assert.Equal("Do more tests", todoItems.FindByIdTodo(1).Description);
            Assert.Equal(1, todoItems.FindByIdTodo(1).TodoID);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void TodoItems_TodoAdd_NullEmptyWhitespace_NotAdded(string badInput)
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.ClearTodo();
            //Act
            todoItems.TodoAdd("Move to a new area");
            todoItems.TodoAdd("Move to the woods");

            ArgumentException resultTodoAdd = Assert.Throws<ArgumentException>(() => todoItems.TodoAdd(badInput));
            //Assert
            Assert.Equal("No description entered", resultTodoAdd.Message);
            Assert.Equal(2, todoItems.SizeTodo());
        }

        [Fact]
        public void TodoItems_Size_Check()
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.ClearTodo();
            //Act
            todoItems.TodoAdd("Fix guitars");
            todoItems.TodoAdd("Don't nuy more guitars");
            todoItems.TodoAdd("Save for triple screens");
            //Assert
            Assert.Equal(3, todoItems.SizeTodo());
        }
        [Fact]
        public void TodoItems_FindByDoneStatus_Done()
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.ClearTodo();
            int done = 3;
            int undDone = 5;
            //Act
            for (int i = 0; i < done; i++) { todoItems.TodoAdd("Truth").Done = true; }
            for (int i = 0; i < undDone; i++) { todoItems.TodoAdd("False").Done = false; }
            //Assert
            Assert.Equal(done, todoItems.FindByDoneStatus(true).Length);
        }
        [Fact]
        public void TodoItems_FindByDoneStatus_Undone()
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.ClearTodo();
            int done = 3;
            int undone = 5;
            //Act
            for (int i = 0; i < done; i++) { todoItems.TodoAdd("Truth").Done = true; }
            for (int i = 0; i < undone; i++) { todoItems.TodoAdd("False").Done = false; }
            //Assert
            Assert.Equal(undone, todoItems.FindByDoneStatus(false).Length);
        }

        [Fact]
        public void TodoItems_FindByAssigne_PersonID()  //Sometimes affected by peopletests
        {
            //Arrange
            //PersonSequencer.reset();
            TodoItems todoItems = new TodoItems();
            People people = new People();
            todoItems.ClearTodo();
            people.Clear();
            int amount = 5;
            people.PersonAdd("Mats", "Ulfsson");
            //Act & Assert
            for(int i = 0; i < amount; i++)
            {
                todoItems.TodoAdd($"Test amount of todos", people.FindById(0));
                Assert.Equal(0, todoItems.FindByIdTodo(i).Assignee.PersonID);
                Assert.Equal("Mats", todoItems.FindByIdTodo(i).Assignee.FirstName);
                Assert.Equal("Ulfsson", todoItems.FindByIdTodo(i).Assignee.LastName);
            }
                Assert.Equal(amount, todoItems.FindByAssignee(0).Length);
            
            //for (int i = 0; i < 5; i++)
            //{
            //    todoItems.TodoAdd($"Todo: {i}").Assignee = people.PersonAdd($"Rickard{i}", $"Nyhlen{i}");
            //    Assert.Equal($"Todo: {i}", todoItems.FindByIdTodo(i).Description);
            //    Assert.Equal($"Rickard{i}", todoItems.FindByIdTodo(i).Assignee.FirstName);
            //    Assert.Equal($"Nyhlen{i}", todoItems.FindByIdTodo(i).Assignee.LastName);
            //    Assert.Equal(i, todoItems.FindByIdTodo(i).Assignee.PersonID);
            //    todoItems.FindByAssignee(i).
            //    //Assert.Equal(todoItems.FindByIdTodo(i).Assignee.PersonID, todoItems.FindByAssignee());
            //}
        }
        [Fact]
        public void TodoItems_FindByAssignee_PersonID_ThrowArgumentException()
        {
            TodoItems todoItems = new TodoItems();
            People people = new People();
            todoItems.ClearTodo();
            people.Clear();
            ArgumentException result = Assert.Throws<ArgumentException>(() => todoItems.FindByAssignee(5));
            Assert.Equal("Assignee with that ID does not exist", result.Message);
        }

        [Fact]
        public void TodoItems_FindByAssignee_Personperson()
        {
            //Arrange
            PersonSequencer.reset();
            TodoItems todoItems = new TodoItems();
            People people = new People();
            todoItems.ClearTodo();
            people.Clear();
            int amount = 10;
            people.PersonAdd("Mats", "Ulfsson");
            //Act & Assert
            for (int i = 0; i < amount; i++)
            {
                todoItems.TodoAdd($"Test amount of todos", people.FindById(0));
                Assert.Equal(0, todoItems.FindByIdTodo(i).Assignee.PersonID);
                Assert.Equal("Mats", todoItems.FindByIdTodo(i).Assignee.FirstName);
                Assert.Equal("Ulfsson", todoItems.FindByIdTodo(i).Assignee.LastName);
            }
            Assert.Equal(amount, todoItems.FindByAssignee(people.FindById(0)).Length);
        }
        [Fact]
        public void TodoItems_FindUnnassignedTodoItems()
        {
            //Arrange
            TodoItems todoItems = new TodoItems();
            People people = new People();
            todoItems.ClearTodo();
            people.Clear();
            todoItems.TodoAdd("Peel oranges", people.PersonAdd("Olle", "Inklimator"));
            todoItems.TodoAdd("Peel apples", people.PersonAdd("Polle", "Klimator"));
            int emptyTodos = 5;
            //Act
            for (int i = 0; i < emptyTodos; i++) { todoItems.TodoAdd($"Count to {i}"); }
            //Assert
            //Assert.Equal(emptyTodos, todoItems.FindUnassignedTodoItems().Length);
        }
    }
}
