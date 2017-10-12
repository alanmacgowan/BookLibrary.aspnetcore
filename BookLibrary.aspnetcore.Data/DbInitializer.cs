using BookLibrary.aspnetcore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Data
{
    public class DbInitializer
    {
        public static void Initialize(BookLibraryContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            var authors = new Author[]
            {
            new Author{FirstName = "Juan", LastName = "Perez", About ="This is author 1",Country = "Argentina",Gender = Gender.Male, BirthDate = DateTime.Parse("1956-09-01")},
            new Author{FirstName = "John", LastName = "Doe", About ="This is author 2",Country = "USA",Gender = Gender.Male, BirthDate = DateTime.Parse("1976-09-01")},
            new Author{FirstName = "Alan", LastName = "Mac", About ="This is author 3",Country = "Argentina",Gender = Gender.Male, BirthDate = DateTime.Parse("1977-09-01")},
            new Author{FirstName = "Pedro", LastName = "Gonzalez", About ="This is author 4",Country = "Spain",Gender = Gender.Male, BirthDate = DateTime.Parse("1987-09-01")},
            };
            foreach (Author c in authors)
            {
                context.Authors.Add(c);
            }
            context.SaveChanges();

            var publishers = new Publisher[]
            {
            new Publisher{Name="Publisher House 1", Country = "Argentina"},
            new Publisher{Name="Publisher House 2", Country = "Argentina"},
            new Publisher{Name="Publisher House 3", Country = "Argentina"}
            };
            foreach (Publisher e in publishers)
            {
                context.Publishers.Add(e);
            }
            context.SaveChanges();

            var books = new Book[]
            {
            new Book{Title="Book 1",Description = "This is Book number 1",PublishDate=DateTime.Parse("2005-09-01"), ISBN = "1289189218291", Category = "Comedy", Price = 44, Pages = 111,Language="Spanish" , PublisherID = 1, AuthorID = 1 },
            new Book{Title="Book 2",Description = "This is Book number 2",PublishDate=DateTime.Parse("2017-05-04"), ISBN = "2222222222622", Category = "Drama", Price = 33, Pages = 222,Language="English" , PublisherID = 1, AuthorID = 1},
            new Book{Title="Book 3",Description = "This is Book number 3",PublishDate=DateTime.Parse("2017-04-03"), ISBN = "3232323222533", Category = "Travel", Price = 23, Pages = 223,Language="Spanish" , PublisherID = 2, AuthorID = 3},
            new Book{Title="Book 4",Description = "This is Book number 4",PublishDate=DateTime.Parse("2016-12-12"), ISBN = "7676676767676", Category = "History", Price = 233, Pages = 422,Language="Portuguese" , PublisherID = 2, AuthorID = 2},
            new Book{Title="Book 5",Description = "This is Book number 5",PublishDate=DateTime.Parse("2015-11-12"), ISBN = "4545454555555", Category = "Comedy", Price = 37, Pages = 123,Language="Spanish" , PublisherID = 3, AuthorID = 2},
            };
            foreach (Book s in books)
            {
                context.Books.Add(s);
            }
            context.SaveChanges();

        }
    }
}
