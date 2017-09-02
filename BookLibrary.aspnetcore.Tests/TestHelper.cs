using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.UI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.aspnetcore.Tests
{
    public static class TestHelper
    {
        public static IEnumerable<Book> GetTestBookList()
        {
            var books = new List<Book>();

            books.Add(new Book
            {
                Title = "Book 1",
                Description = "This is Book number 1",
                PublishDate = DateTime.Parse("2005-09-01"),
                ISBN = "1289189218291",
                Category = "Comedy",
                Pages = 111,
                Language = "Spanish",
                PublisherID = 1,
                AuthorID = 1
            });

            return books;
        }
        public static IEnumerable<Author> GetTestAuthorList()
        {
            var authors = new List<Author>();

            authors.Add(new Author
            {
                FirstName = "Juan",
                LastName = "Perez",
                About = "This is author 1",
                Country = "Argentina",
                Gender = Gender.Male,
                BirthDate = DateTime.Parse("1956-09-01")
            });

            return authors;
        }
        public static IEnumerable<Publisher> GetTestPublisherList()
        {
            var publishers = new List<Publisher>();

            publishers.Add(new Publisher
            {
                Name="Publisher House 1",
                Country = "Argentina"
            });

            publishers.Add(new Publisher
            {
                Name = "Publisher House 2",
                Country = "Argentina"
            });

            return publishers;
        }

        public static BookViewModel GetTestBookViewModel()
        {
            var book = new BookViewModel
            {
                Title = "Book 1",
                Description = "This is Book number 1",
                PublishDate = DateTime.Parse("2005-09-01"),
                ISBN = "1289189218291",
                Category = "Comedy",
                Pages = 111,
                Language = "Spanish",
                PublisherID = 1,
                AuthorID = 1
            };

            return book;
        }

        public static Book GetTestBook()
        {
            var book = new Book
            {
                Title = "Book 1",
                Description = "This is Book number 1",
                PublishDate = DateTime.Parse("2005-09-01"),
                ISBN = "1289189218291",
                Category = "Comedy",
                Pages = 111,
                Language = "Spanish",
                PublisherID = 1,
                AuthorID = 1
            };

            return book;
        }

    }
}
