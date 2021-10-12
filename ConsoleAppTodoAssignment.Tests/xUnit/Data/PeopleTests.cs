using System;
using Xunit;
using ConsoleAppTodoAssignment.Data;

namespace ConsoleAppTodoAssignment.Tests
{
    [Collection("My Collection 01")]
    public class PeopleTests
    {
        [Fact]
        public void People_FindAll()
        {
            //Arrange
            People people = new People();
            people.Clear();
            int amount = 7;
            //Act
            for(int i = 0; i < amount; i++) { people.PersonAdd("Test", "Man"); }
            //Assert
            Assert.Equal(amount, people.FindAll().Length);
        }
        [Fact]
        public void People_FindAll_NoPeople()
        {
            //Arrange
            People people = new People();
            people.Clear();
            //Act & Assert
            Assert.Empty(people.FindAll());
        }
        [Fact]
        public void People_FindByID_Succes()
        {
            //Arrange
            People people = new People();
            people.Clear();
            PersonSequencer.reset();
            //Act
            people.PersonAdd("Hans", "Bieber");
            people.PersonAdd("Frasse", "Matsson");
            people.PersonAdd("Frida", "Klavert");
            //Assert
            Assert.Equal("Hans", people.FindById(0).FirstName); Assert.Equal("Bieber", people.FindById(0).LastName);
            Assert.Equal("Frasse", people.FindById(1).FirstName); Assert.Equal("Matsson", people.FindById(1).LastName);
            Assert.Equal("Frida", people.FindById(2).FirstName); Assert.Equal("Klavert", people.FindById(2).LastName);
        }
        [Fact]
        public void People_FindById_Fail_IdDoesNotExist()
        {
            //Arrange
            People people = new People();
            people.Clear();
            people.PersonAdd("Hans", "Bieber");
            //Act
            ArgumentException resultFindById = Assert.Throws<ArgumentException>(() => people.FindById(int.MaxValue));
            //Assert
            Assert.Equal("Id does not exist", resultFindById.Message);
        }
        [Fact]
        public void People_FindById_Fail_EmptyArray()
        {
            //Arrange
            People people = new People();
            people.Clear();
            //Act
            ArgumentException resultEmptyArray = Assert.Throws<ArgumentException>(() => people.FindById(int.MaxValue));
            //Assert
            Assert.Equal("Sorry, the list is empty", resultEmptyArray.Message);
        }
        [Fact]
        public void People_PersonAdd_Success()
        {
            //Arrange
            People people = new People();
            people.Clear();
            PersonSequencer.reset();
            //Act
            people.PersonAdd("Greta", "Haretka");
            people.PersonAdd("Murkel", "Svamper");
            //Assert
            Assert.Equal("Greta", people.FindById(0).FirstName);
            Assert.Equal("Haretka", people.FindById(0).LastName);
            Assert.Equal(0, people.FindById(0).PersonID);
            Assert.Equal("Murkel", people.FindById(1).FirstName);
            Assert.Equal("Svamper", people.FindById(1).LastName);
            Assert.Equal(1, people.FindById(1).PersonID);
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void People_PersonAdd_FirstName_NullEmptyWhitespace_NotAdded_ToArray(string badInput)
        {
            //Arrange
            People people = new People();
            people.Clear();
            //Act
            people.PersonAdd("Gustav", "Ohlsson");
            people.PersonAdd("Gustaf", "Påhlsson");
            //Assert
            Assert.Throws<ArgumentException>(() => people.PersonAdd(badInput, "Clarkson"));
            Assert.Equal(2, people.Size());
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void People_PersonAdd_LastName_NullEmptyWhitespace_NotAdded_ToArray(string badInput)
        {
            //Arrange
            People people = new People();
            people.Clear();
            //Act
            people.PersonAdd("Gustav", "Ohlsson");
            people.PersonAdd("Gustaf", "Påhlsson");
            //Assert
            Assert.Throws<ArgumentException>(() => people.PersonAdd("Henry", badInput));
            Assert.Equal(2, people.Size());
        }
        [Fact]
        public void People_Size_Check()
        {
            //Arrange
            People people = new People();
            people.Clear();
            int sizeSet = 5;
            //Act
            for(int i = 0; i < sizeSet; i++)
            {
                people.PersonAdd($"firstName_{i}", $"lastName_{i}");
            }
            //Assert
            Assert.Equal(sizeSet, people.Size());
        }
        [Fact]
        public void People_RemovePerson()
        {
            //Arrange
            People people = new People();
            PersonSequencer.reset();
            people.Clear();
            //Act
            int startSize = 5;
            int remove = 2;
            for (int i = 0; i < startSize; i++) { people.PersonAdd($"Rakel_{i}", $"Spektakel_{i}"); }
            people.RemovePerson(remove);
            //Assert
            Assert.Equal(startSize - 1, people.Size());
        }
        [Fact]
        public void People_RemovePerson_IdDoesNotExist()
        {
            //Arrange
            People people = new People();
            //Act & Assert
            ArgumentException result = Assert.Throws<ArgumentException>(() => people.RemovePerson(int.MaxValue));
            Assert.Equal("Person ID does not exist and can't be deleted", result.Message);
        }
    }
}
