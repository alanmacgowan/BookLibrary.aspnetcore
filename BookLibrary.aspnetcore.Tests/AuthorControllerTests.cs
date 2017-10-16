using AutoMapper;
using BookLibrary.aspnetcore.Services.Interfaces;
using BookLibrary.aspnetcore.UI.Features.Author;
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

    public class AuthorControllerFixture : IDisposable
    {
        public AuthorController controller;
        public Mock<IBookService> mockBookService;
        public Mock<IAuthorService> mockAuthorService;

        public AuthorControllerFixture()
        {
            UI.Infrastructure.MapperConfiguration.Configure();

            mockBookService = new Mock<IBookService>() { CallBase = true, };
            mockAuthorService = new Mock<IAuthorService>();

            mockBookService.Setup(srvc => srvc.GetAll()).Returns(Task.FromResult(TestHelper.GetTestBookList()));
            mockAuthorService.Setup(srvc => srvc.GetAll()).Returns(Task.FromResult(TestHelper.GetTestAuthorList()));
        }

        public void Dispose()
        {

        }

    }

    public class AuthorControllerTests : IClassFixture<AuthorControllerFixture>
    {
        AuthorControllerFixture _fixture;

        public AuthorControllerTests(AuthorControllerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetAuthors_ReturnsAViewResult_WithAListOfBooks()
        {
            // Arrange
            _fixture.controller = new AuthorController(_fixture.mockBookService.Object, _fixture.mockAuthorService.Object);

            // Act
            var result = await _fixture.controller.GetAuthors();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<AuthorViewModel>>(result);
            Assert.Equal(1, model.Count());
        }


    }
}
