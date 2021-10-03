using System;
using Xunit;
using ConsoleAppTodoAssignment.Models;


namespace ConsoleAppTodoAssignment.Tests
{
    public class PersonTests
    {
        /*
        [Fact]
        public void Person_Check_BadNames()
        {
            //Arrange, Act
            //Data.People people = new Data.People();
            people.Clear();
            Person person = new Person(0, "klas", "Klasson");
            person = new Person(0, "", "");
            //Assert
            Assert.NotEqual("", person.FirstName);
            //Assert.Empty(person.LastName);
            //Assert.NotSame(firstName, person.FirstName);
            //Assert.Equal(string.Empty , person.FirstName);
            //Assert.True(string.IsNullOrEmpty(person.FirstName) || string.IsNullOrWhiteSpace(person.FirstName));
            //Assert.True(string.IsNullOrEmpty(person.LastName) || string.IsNullOrWhiteSpace(person.LastName));

            //Assert.Throws<ArgumentNullException>(() => person.LastName);    //Not working
        }*/
        [Theory]
        [InlineData(0, "Hans", "Öhman")] //reduntant
        public void Person_CreateWith_GoodInput01(int ID, string firstName, string lastName)
        {
            //Arrange
            //Act
            Person person = new Person(ID, firstName, lastName);

            //Assert
            Assert.Equal(person.PersonID, ID);
            Assert.Equal(person.FirstName, firstName);
            Assert.Equal(person.LastName, lastName);
            Assert.False(string.IsNullOrEmpty(person.FirstName) || string.IsNullOrWhiteSpace(person.FirstName));
            Assert.False(string.IsNullOrEmpty(person.LastName) || string.IsNullOrWhiteSpace(person.LastName));

        }
        [Fact]
        public void Person_CreatedWith_GoodInput02()
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
