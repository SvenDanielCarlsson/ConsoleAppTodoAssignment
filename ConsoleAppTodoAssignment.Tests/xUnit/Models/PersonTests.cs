using System;
using Xunit;
using ConsoleAppTodoAssignment.Models;


namespace ConsoleAppTodoAssignment.Tests
{
    public class PersonTests
    {
        [Theory]
        [InlineData(0, "Hans", "Öhman")] //reduntant
        public void Person_Createwith_GoodInput(int ID, string firstName, string lastName)
        {
            //Arrange
            //Act
            Person person = new Person(ID, firstName, lastName);

            //Assert
            Assert.Equal(person.PersonID, ID);
            Assert.Equal(person.FirstName, firstName);
            Assert.Equal(person.LastName, lastName);
            
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
