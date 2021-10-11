using System;
using Xunit;
using ConsoleAppTodoAssignment.Data;

namespace ConsoleAppTodoAssignment.Tests
{
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
            //people.Clear();
        }
        [Fact]
        public void People_FindByID_Succes()
        {
            //Arrange
            People people = new People();
            people.Clear();            
            //Act
            people.PersonAdd("Hans", "Bieber");
            people.PersonAdd("Frasse", "Matsson");
            people.PersonAdd("Frida", "Klavert");
            //Assert
            Assert.Equal("Hans", people.FindById(0).FirstName); Assert.Equal("Bieber", people.FindById(0).LastName);
            Assert.Equal("Frasse", people.FindById(1).FirstName); Assert.Equal("Matsson", people.FindById(1).LastName);
            Assert.Equal("Frida", people.FindById(2).FirstName); Assert.Equal("Klavert", people.FindById(2).LastName);
            //people.Clear();
        }
        [Fact]
        public void People_FindById_Fail_IdDoesNotExist()
        {
            //Arrange
            People people = new People();
            people.Clear();
            people.PersonAdd("Hans", "Bieber");
            //Act
            ArgumentException resultFindById = Assert.Throws<ArgumentException>(() => people.FindById(3));
            //Assert
            Assert.Equal("Id does not exist", resultFindById.Message);
            //people.Clear();
        }
        [Fact]
        public void People_FindById_Fail_EmptyArray()
        {
            //Arrange
            People people = new People();
            people.Clear();
            //Act
            ArgumentException resultEmptyArray = Assert.Throws<ArgumentException>(() => people.FindById(1));
            //Assert
            Assert.Equal("Sorry, the list is empty", resultEmptyArray.Message);
            //people.Clear();
        }

        [Fact]
        public void People_PersonAdd_Success()
        {
            //Arrange
            People people = new People();
            people.Clear();
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
            people.Clear();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void People_PersonAdd_Fail_badFirstName(string firstName)
        {
            //Arrange
            People people = new People();
            //Act
            ArgumentException resultFirstName = Assert.Throws<ArgumentException>(() => people.PersonAdd(firstName, "Matsson"));
            //Assert
            Assert.Equal("First name cannot be null, empty or whitespace", resultFirstName.Message);
            people.Clear();
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void People_PersonAdd_Fail_badLastName(string lastName)
        {
            //Arrange
            People people = new People();
            //Act
            ArgumentException resultLastName = Assert.Throws<ArgumentException>(() => people.PersonAdd("Mats", lastName));
            //Assert
            Assert.Equal("Last name cannot be null, empty or whitespace", resultLastName.Message);
            people.Clear();
        }

        [Fact]
        public void People_Size_Check()
        {
            //Arrange
            People people = new People();
            people.Clear();
            int sizeSet = 120;  //Why does this affect FindByAssigneId test???
            //Act
            for(int i = 0; i < sizeSet; i++)
            {
                people.PersonAdd($"firstName_{i}", $"lastName_{i}");
            }
            //Assert
            Assert.Equal(sizeSet, people.Size());
            people.Clear();
        }


    }
}
