using BookLibrary.aspnetcore.Models;
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

            var books = new Book[]
            {
            new Book{Title="Book 1",Description="This is Book number 1",PublishDate=DateTime.Parse("2005-09-01"), ISBN= "1289189218291", Category= "Comedy", Pages= 111,Language="Spanish" , PublisherID = 1 },
            new Book{Title="Book 2",Description="This is Book number 2",PublishDate=DateTime.Parse("2012-05-04"), ISBN= "2222222222622", Category= "Drama", Pages= 222,Language="English" , PublisherID = 1},
            new Book{Title="Book 3",Description="This is Book number 3",PublishDate=DateTime.Parse("2011-04-03"), ISBN= "3232323222533", Category= "Travel", Pages= 223,Language="Spanish" , PublisherID = 1},
            new Book{Title="Book 4",Description="This is Book number 4",PublishDate=DateTime.Parse("2015-12-12"), ISBN= "7676676767676", Category= "History", Pages= 422,Language="Portuguese" , PublisherID = 1},
            new Book{Title="Book 5",Description="This is Book number 5",PublishDate=DateTime.Parse("2015-11-12"), ISBN= "4545454555555", Category= "Comedy", Pages= 123,Language="Spanish" , PublisherID = 1},
            };
            foreach (Book s in books)
            {
                context.Books.Add(s);
            }
            context.SaveChanges();

            var authors = new Author[]
            {
            new Author{Books=[],Title="Chemistry",Credits=3},

            };
            foreach (Author c in authors)
            {
                context.Authors.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},

            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
