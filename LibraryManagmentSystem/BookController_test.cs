using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Library_Management_System.Controllers;
using Library_Management_System.Models;
using Library_Management_System.Repository;
using Library_Management_System.Repository;

namespace Library_Management_System.Tests.Controllers
{
    public class BookControllerTests
    {
        [Fact]
        public void GetAllBooks_Returns_OkResult_With_BookList()
        {
            // Arrange
            var mockBookRepository = new Mock<IBook>();
            mockBookRepository.Setup(repo => repo.GetAllBooks()).Returns(new List<Book>());

            var controller = new BookController(mockBookRepository.Object);

            // Act
            var result = controller.GetAllBooks();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var bookList = Assert.IsType<List<Book>>(okResult.Value);
            Assert.Empty(bookList);
        }

        [Fact]
        public void GetBookById_Returns_OkResult_With_Book()
        {
            // Arrange
            var mockBookRepository = new Mock<IBook>();
            mockBookRepository.Setup(repo => repo.GetBookById(It.IsAny<int>())).Returns(new Book { ID = 1, Title = "Sample Book" });

            var controller = new BookController(mockBookRepository.Object);

            // Act
            var result = controller.GetBookById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var book = Assert.IsType<Book>(okResult.Value);
            Assert.Equal(1, book.ID);
            Assert.Equal("Sample Book", book.Title);
        }

        // Similar tests for AddBook, UpdateBook, and DeleteBook methods...[Fact]
        public void AddBook_Returns_CreatedAtActionResult_When_ModelStateIsValid()
        {
            // Arrange
            var mockBookRepository = new Mock<IBook>();
            var controller = new BookController(mockBookRepository.Object);
            controller.ModelState.AddModelError("TestError", "Test Error Message");
            var book = new Book { ID = 1, Title = "Sample Book" };

            // Act
            var result = controller.AddBook(book);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public void UpdateBook_Returns_OkResult_When_ValidIdIsProvided()
        {
            // Arrange
            var mockBookRepository = new Mock<IBook>();
            mockBookRepository.Setup(repo => repo.GetBookById(It.IsAny<int>())).Returns(new Book { ID = 1, Title = "Sample Book" });
            var controller = new BookController(mockBookRepository.Object);

            // Act
            var result = controller.UpdateBook(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var book = Assert.IsType<Book>(okResult.Value);
            Assert.Equal(1, book.ID);
            Assert.Equal("Sample Book", book.Title);
        }

        [Fact]
        public void DeleteBook_Returns_OkResult_When_ValidIdIsProvided()
        {
            // Arrange
            var mockBookRepository = new Mock<IBook>();
            mockBookRepository.Setup(repo => repo.GetBookById(It.IsAny<int>())).Returns(new Book { ID = 1, Title = "Sample Book" });
            var controller = new BookController(mockBookRepository.Object);

            // Act
            var result = controller.DeleteBook(1);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
        }

    }
}

