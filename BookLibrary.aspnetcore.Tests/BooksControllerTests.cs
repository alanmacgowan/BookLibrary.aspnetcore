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
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfBooks()
        {
            // Arrange
            var mockService = new Mock<IBookService>();
            mockService.Setup(srvc => srvc.GetAll()).Returns(Task.FromResult(GetTestBookList()));

            //move to other method
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
            var mapper = config.CreateMapper();

            var controller = new BooksController(mapper, mockService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<BookViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(1, model.Count());
        }

        private IEnumerable<Book> GetTestBookList()
        {
            var books = new List<Book>();

            books.Add(new Book {
                Title = "Book 1",
                Description = "This is Book number 1",
                PublishDate = DateTime.Parse("2005-09-01"),
                ISBN = "1289189218291",
                Category = "Comedy",
                Pages = 111,
                Language = "Spanish",
                PublisherID = 1,
                AuthorID = 1 });

            return  books;
        }





    }
}
