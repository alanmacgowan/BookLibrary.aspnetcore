using AutoMapper;
using BookLibrary.aspnetcore.Services.Interfaces;
using BookLibrary.aspnetcore.UI.Features.Book;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookLibrary.aspnetcore.Tests
{

    public class BookControllerFixture : IDisposable
    {
        public IMapper mapper;
        public BookController controller;
        public Mock<IBookService> mockBookService;
        public Mock<IAuthorService> mockAuthorService;
        public Mock<IPublisherService> mockPublisherService;

        public BookControllerFixture()
        {
            UI.Infrastructure.MapperConfiguration.Configure();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();

            mockBookService = new Mock<IBookService>() { CallBase = true, };
            mockAuthorService = new Mock<IAuthorService>();
            mockPublisherService = new Mock<IPublisherService>();

            mockBookService.Setup(srvc => srvc.GetAll()).Returns(Task.FromResult(TestHelper.GetTestBookList()));
            mockAuthorService.Setup(srvc => srvc.GetAll()).Returns(Task.FromResult(TestHelper.GetTestAuthorList()));
            mockPublisherService.Setup(srvc => srvc.GetAll()).Returns(Task.FromResult(TestHelper.GetTestPublisherList()));

        }

        public void Dispose()
        {
     
        }

    }

    public class BooksControllerTests : IClassFixture<BookControllerFixture>
    {
        BookControllerFixture _fixture;

        public BooksControllerTests(BookControllerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetBooks_ReturnsAViewResult_WithAListOfBooks()
        {
            // Arrange
            _fixture.controller = new BookController(_fixture.mockBookService.Object, _fixture.mockAuthorService.Object, _fixture.mockPublisherService.Object);

            // Act
            var result = await _fixture.controller.GetBooks();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<BookViewModel>>(result);
            Assert.Equal(1, model.Count());
        }

        [Fact]
        public async Task Create_ReturnsAViewResult_WithAListOfAuthors()
        {
            // Arrange
            _fixture.controller = new BookController( _fixture.mockBookService.Object, _fixture.mockAuthorService.Object, _fixture.mockPublisherService.Object);

            // Act
            var result = await _fixture.controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<BookEditViewModel>(viewResult.ViewData.Model);
            Assert.Equal(1, model.Authors.Count);
        }

        [Fact]
        public async Task Create_ReturnsAViewResult_WithAListOfPublishers()
        {
            // Arrange
            _fixture.controller = new BookController(_fixture.mockBookService.Object, _fixture.mockAuthorService.Object, _fixture.mockPublisherService.Object);

            // Act
            var result = await _fixture.controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<BookEditViewModel>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Publishers.Count);
        }

        [Fact]
        public async Task DetailsPartial_ReturnsAViewResult_WhithCorrectBook()
        {
            // Arrange
            var book = TestHelper.GetTestBook();
            _fixture.mockBookService.Setup(srvc => srvc.Get(book.ID)).Returns(Task.FromResult(TestHelper.GetTestBook()));
            _fixture.controller = new BookController(_fixture.mockBookService.Object, _fixture.mockAuthorService.Object, _fixture.mockPublisherService.Object);

            // Act
            var result = await _fixture.controller.DetailsPartial(book);

            // Assert
            var viewResult = Assert.IsType<PartialViewResult>(result);
            var model = Assert.IsAssignableFrom<BookViewModel>(viewResult.ViewData.Model);
            Assert.Equal(book.Title, model.Title);
        }

        [Fact]
        public async Task DetailsPartial_ReturnsNotFoundResult_WhenNoIdPassed()
        {
            //// Arrange
            _fixture.controller = new BookController(_fixture.mockBookService.Object, _fixture.mockAuthorService.Object, _fixture.mockPublisherService.Object);

            //// Act
            var result = await _fixture.controller.DetailsPartial(null);

            //// Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenModelInvalid()
        {
            // Arrange
            var bookVM = TestHelper.GetTestBookViewModel();
            _fixture.controller = new BookController(_fixture.mockBookService.Object, _fixture.mockAuthorService.Object, _fixture.mockPublisherService.Object);
            _fixture.controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await _fixture.controller.Create(bookVM);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

    }
}
