using BookLibrary.aspnetcore.Domain;
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

    }
}
