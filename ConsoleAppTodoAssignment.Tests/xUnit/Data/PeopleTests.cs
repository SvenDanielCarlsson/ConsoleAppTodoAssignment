using System;
using Xunit;
using ConsoleAppTodoAssignment.Data;

namespace ConsoleAppTodoAssignment.Tests
{
    public class PeopleTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void People_FindByID_Succes(int index)
        {
            //Arrange
            People people = new People();
            people.Clear();
            PersonSequencer.reset();
            people.PersonAdd("Hans", "Bevers");
            people.PersonAdd("Frasse", "Matsson");
            people.PersonAdd("Frida", "Klavert");
            //Act
            people.FindById(index);
            //Assert
            Assert.NotNull(people.FindById(index));
        }



        [Fact]
        public void People_PersonAdd_Success()
        {
            //Arrange
            People people = new People();
            people.Clear();
            PersonSequencer.reset();
            //Person[] thePerson = new Person[0];

            people.PersonAdd("Greta", "Haretka");

            //Assert.True(people.FindById(0).FirstName == "Greta");
            Assert.Equal("Greta", people.FindById(0).FirstName);
            Assert.Equal("Haretka", people.FindById(0).LastName);
            Assert.Equal(0, people.FindById(0).PersonID);
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
            people.PersonAdd("Mike", "Huntington");
            people.PersonAdd("", "");
            people.PersonAdd(" ", " ");
            //Assert
            Assert.Equal("Mike", people.FindById(0).FirstName);
            //Assert.Equal(1, people.Size());
        }*/

        [Fact]
        public void People_Size_Check()
        {
            //Arrange
            People people = new People();
            people.Clear();
            PersonSequencer.reset();
            //Act
            people.PersonAdd("Hans", "Hasse");
            people.PersonAdd("Hassan", "Hansen");
            //Assert
            Assert.Equal(2, people.Size());
        }
   
    }
}
