using System;
using Xunit;
using ConsoleAppTodoAssignment.Models;


namespace ConsoleAppTodoAssignment.Tests
{
    public class PersonTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Person_NotCreated_NullEmptySpace_ForFirstName(string firstName)
        {
            //Arrange
            int personId = 1;
            string lastName = "Hansson";
            //Act & Assert
            ArgumentException result_firstName = Assert.Throws<ArgumentException>(() => new Person(personId, firstName, lastName));
            Assert.Equal("First name cannot be null, empty or whitespace", result_firstName.Message);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Person_NotCreated_NullEmptySpace_ForLastName(string lastName)
        {
            //Arrange
            int personId = 1;
            string firstName = "Mats";
            //Act & Assert
            ArgumentException result_lastName = Assert.Throws<ArgumentException>(() => new Person(personId, firstName, lastName));
            Assert.Equal("Last name cannot be null, empty or whitespace", result_lastName.Message);
        }

        [Fact]
        public void Person_CreatedWith_GoodInput()
        {
            //Arrange
            int personId = 0;
            string firstName = "Hans";
            string lastName = "Öhman";
            //Act
            Person person = new Person(personId, firstName, lastName);
            //Assert
            Assert.Equal(0, person.PersonID);
            Assert.Equal("Hans", person.FirstName);
            Assert.Equal("Öhman", person.LastName);
        }


    }
}
