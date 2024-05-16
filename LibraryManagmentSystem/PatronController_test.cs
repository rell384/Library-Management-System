using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Library_Management_System.Controllers;
using Library_Management_System.Models;
using Library_Management_System.Repository;
using System.Collections.Generic;
using Library_Management_System.Repository;

namespace Library_Management_System.Tests.Controllers
{
    public class PatronControllerTests
    {
        [Fact]
        public void GetAllPatrons_Returns_OkResult_With_PatronList()
        {
            // Arrange
            var mockPatronRepository = new Mock<IPatron>();
            mockPatronRepository.Setup(repo => repo.GetAllPatrons()).Returns(new List<Patron>());

            var controller = new PatronController(mockPatronRepository.Object);

            // Act
            var result = controller.GetAllPatrons();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var patronList = Assert.IsType<List<Patron>>(okResult.Value);
            Assert.Empty(patronList);
        }

        [Fact]
        public void GetPatronById_Returns_OkResult_With_Patron()
        {
            // Arrange
            var mockPatronRepository = new Mock<IPatron>();
            mockPatronRepository.Setup(repo => repo.GetPatronById(It.IsAny<int>())).Returns(new Patron { ID = 1, Name = "John" });

            var controller = new PatronController(mockPatronRepository.Object);

            // Act
            var result = controller.GetPatronById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var patron = Assert.IsType<Patron>(okResult.Value);
            Assert.Equal(1, patron.ID);
            Assert.Equal("John", patron.Name);
        }

        [Fact]
        public void AddPatron_Returns_CreatedAtActionResult_When_ModelStateIsValid()
        {
            // Arrange
            var mockPatronRepository = new Mock<IPatron>();
            var controller = new PatronController(mockPatronRepository.Object);
            controller.ModelState.AddModelError("TestError", "Test Error Message");
            var patron = new Patron { ID = 1, Name = "John" };

            // Act
            var result = controller.AddPatron(patron);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public void UpdatePatron_Returns_OkResult_When_ValidIdIsProvided()
        {
            // Arrange
            var mockPatronRepository = new Mock<IPatron>();
            mockPatronRepository.Setup(repo => repo.GetPatronById(It.IsAny<int>())).Returns(new Patron { ID = 1, Name = "John" });
            var controller = new PatronController(mockPatronRepository.Object);

            // Act
            var result = controller.UpdatePatron(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var patron = Assert.IsType<Patron>(okResult.Value);
            Assert.Equal(1, patron.ID);
            Assert.Equal("John", patron.Name);
        }

        [Fact]
        public void DeletePatron_Returns_OkResult_When_ValidIdIsProvided()
        {
            // Arrange
            var mockPatronRepository = new Mock<IPatron>();
            mockPatronRepository.Setup(repo => repo.GetPatronById(It.IsAny<int>())).Returns(new Patron { ID = 1, Name = "John" });
            var controller = new PatronController(mockPatronRepository.Object);

            // Act
            var result = controller.DeletePatron(1);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
        }

    }
}
