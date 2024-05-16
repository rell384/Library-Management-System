using Xunit;
using Moq;
using Library_Management_System.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Library_Management_System.Repository;
using Library_Management_System.Controllers;
namespace Library_Management_System.Tests.Controllers
{
    public class BorrowBookControllerTests
    {
        [Fact]
        public async Task BorrowBook_Returns_OkResult_When_BorrowingIsSuccessful()
        {
            // Arrange
            var mockRepository = new Mock<IBorrow>();
            mockRepository.Setup(repo => repo.BorrowBook(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.CompletedTask);

            var controller = new BorrowingBookController(mockRepository.Object);

            // Act
            var result = await controller.BorrowBook(1, 1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Book successfully borrowed", result.Value);
        }

        [Fact]
        public async Task BorrowBook_Returns_InternalServerError_When_ExceptionOccurs()
        {
            // Arrange
            var mockRepository = new Mock<IBorrow>();
            mockRepository.Setup(repo => repo.BorrowBook(It.IsAny<int>(), It.IsAny<int>())).ThrowsAsync(new Exception("Test Exception"));

            var controller = new BorrowingBookController(mockRepository.Object);

            // Act
            var result = await controller.BorrowBook(1, 1) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
            Assert.Equal("Internal server error: Test Exception", result.Value);
        }
    }
}

