using AutoMapper;
using BookLibrary.aspnetcore.Controllers;
using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.Services;
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
    public class BooksControllerTests
    {
        IMapper mapper;

        public BooksControllerTests()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
             mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfBooks()
        {
            // Arrange
            var mockService = new Mock<IBookService>();
            mockService.Setup(srvc => srvc.GetAll()).Returns(Task.FromResult(TestHelper.GetTestBookList()));

            var controller = new BooksController(mapper, mockService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<BookViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(1, model.Count());
        }


    }
}
