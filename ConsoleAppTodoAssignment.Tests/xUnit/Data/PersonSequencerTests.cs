using System;
using Xunit;
using ConsoleAppTodoAssignment.Data;

namespace ConsoleAppTodoAssignment.Tests
{
    public class PersonSequencerTests
    {
        [Fact]
        public void PersonSequencer_IncreasePersonId()
        {
            //Arrange
            PersonSequencer personSQ = new PersonSequencer();
            PersonSequencer.reset();
            //Act and Assert
            int forCount = 8;
            for (int i = 0; i < forCount; i++)
            {
                PersonSequencer.nextPersonId();
                Assert.Equal(i + 1, personSQ.PersonID);
            }
            Assert.Equal(forCount, personSQ.PersonID);
        }
        [Fact]
        public void PersonSequenser_ResetPersonId()
        {
            //Arrange
            PersonSequencer personSQ = new PersonSequencer();
            for (int i = 0; i < 5; i++) { PersonSequencer.nextPersonId(); }
            //Act
            PersonSequencer.reset();
            //Assert
            Assert.Equal(0, personSQ.PersonID);
        }
    }
}
