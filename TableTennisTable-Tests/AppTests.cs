using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using TableTennisTable_CSharp;

namespace TableTennisTable_Tests
{
    [TestClass]
    public class AppTests
    {
        [TestMethod]
        public void TestPrintsCurrentState()
        {
            // Arrange
            var league = new League();
            var renderer = new Mock<ILeagueRenderer>();
            renderer.Setup(r => r.Render(league)).Returns("Rendered League");
            // Act
            var app = new App(league, renderer.Object, null);
            // Assert
            Assert.AreEqual("Rendered League", app.SendCommand("print"));
        }

        [TestMethod]
        public void AddPlayerTest()
        {
            // Arrange
            var league = new League();
            var renderer = new Mock<ILeagueRenderer>();

            // Act 
            var app = new App(league, renderer.Object, null);

            // Assert
            Assert.AreEqual("Rendered League", app.SendCommand("add player Alice"));
            Assert.AreEqual("Rendered League", app.SendCommand("add player Bob"));
        }

        [TestMethod]
        public void WinnerTest()
        {
            // Arrange
            var league = new League();
            var renderer = new Mock<ILeagueRenderer>();

            // Act 
            var app = new App(league, renderer.Object, null);

            // Assert
            Assert.AreEqual("Rendered League", app.SendCommand("winner"));
        }
        [TestMethod]
        public void RecordAliceWinnerTest()
        {
            // Arrange
            var league = new League();
            var renderer = new Mock<ILeagueRenderer>();

            // Act 
            var app = new App(league, renderer.Object, null);

            // Assert
            Assert.AreEqual("Rendered League", app.SendCommand("record win Alice Bob"));
        }
    }
}
