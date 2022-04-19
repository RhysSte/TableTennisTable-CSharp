using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableTennisTable_CSharp;
using System;


namespace TableTennisTable_Tests
{
    [TestClass]
    public class LeagueTests
    {
        [TestMethod]
        public void TestAddPlayer()
        {
            // Given
            League league = new League();

            // When
            league.AddPlayer("Bob");

            // Then
            var rows = league.GetRows();
            Assert.AreEqual(1, rows.Count);
            var firstRowPlayers = rows.First().GetPlayers();
            Assert.AreEqual(1, firstRowPlayers.Count);
            CollectionAssert.Contains(firstRowPlayers, "Bob");
        }

        [TestMethod]
        public void ShouldGetWinner()
        {
            // Arrange 
            League league = new League();
            league.AddPlayer("Joe");

            // Act
            var winner = league.GetWinner();

            // Assert
            Assert.AreEqual(winner, "Joe");
        }

        [TestMethod]
        public void GetWinnerShouldReturnNullWhenNoPlayersInGame()
        {
            // Arrange 
            League league = new League();

            // Act
            var winner = league.GetWinner();

            // Assert
            Assert.AreEqual(winner, null);

        }

        

        [TestMethod]
        public void TestRecordWin ()
        {
            // Arrange 
            League league = new League();
            league.AddPlayer("Joe");
            league.AddPlayer("Mama");
            league.AddPlayer("Steve");
            // Assert ACT

            Assert.ThrowsException<ArgumentException>(() => league.RecordWin("Mama", "Steve"));
        }

    }
}
