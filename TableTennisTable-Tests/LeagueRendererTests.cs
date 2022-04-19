using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableTennisTable_CSharp;
using System;

namespace TableTennisTable_Tests
{
    [TestClass]
    public class LeagueRendererTests
    {
        [TestMethod]    
        public void RenderHasNoPlayers()
        {
            // Arrange
            League league = new League();
            LeagueRenderer leagueRenderer = new LeagueRenderer();

            // Act
            var result = leagueRenderer.Render(league);

            // Assert
            Assert.AreEqual(result, "No players yet");
        }

        [TestMethod]
        public void RenderHasPlayers()
        {
            // Arrange
            League league = new League();
            LeagueRenderer leagueRenderer = new LeagueRenderer();
            league.AddPlayer("Bob");
            league.AddPlayer("Mama");

            // Act
            var result = leagueRenderer.Render(league);

            // Assert
            Assert.AreNotEqual(result, "No players yet");

            Assert.AreEqual(result.ToString(), "Bob");
        }
    }
}
