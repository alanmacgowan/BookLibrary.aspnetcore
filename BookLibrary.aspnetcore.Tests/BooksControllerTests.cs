using AutoMapper;
using BookLibrary.aspnetcore.Controllers;
using BookLibrary.aspnetcore.Services.Interfaces;
using BookLibrary.aspnetcore.UI;
using BookLibrary.aspnetcore.UI.Models;
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
        private IMapper mapper;
        public BooksController controller;

        public BookControllerFixture()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
            mapper = config.CreateMapper();

            var mockBookService = new Mock<IBookService>();
            mockBookService.Setup(srvc => srvc.GetAll()).Returns(Task.FromResult(TestHelper.GetTestBookList()));

            var mockAuthorService = new Mock<IAuthorService>();
            mockAuthorService.Setup(srvc => srvc.GetAll()).Returns(Task.FromResult(TestHelper.GetTestAuthorList()));

            var mockPublisherService = new Mock<IPublisherService>();
            mockPublisherService.Setup(srvc => srvc.GetAll()).Returns(Task.FromResult(TestHelper.GetTestPublisherList()));

            controller = new BooksController(mapper, mockBookService.Object, mockAuthorService.Object, mockPublisherService.Object);
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
        public async Task Index_ReturnsAViewResult_WithAListOfBooks()
        {
            // Arrange

            // Act
            var result = await _fixture.controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<BookViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(1, model.Count());
        }

        [Fact]
        public async Task Create_ReturnsAViewResult_WithAListOfAuthors()
        {
            // Arrange

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

            // Act
            var result = await _fixture.controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<BookEditViewModel>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Publishers.Count);
        }


    }
}
