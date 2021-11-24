using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations
{
    public class DataGenerator{
        public static void Initialize(IServiceProvider serviceProvider){
            using(var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>())){
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book{
                Title = "Lean Startup",
                GenreId = 1,
                PageCount = 200,
                PublishDate = new DateTime(2001,06,12)
            },
            new Book{
                Title = "Herland",
                GenreId = 3,
                PageCount = 300,
                PublishDate = new DateTime(2002,10,30)
            },
            new Book{
                Title = "Dune",
                GenreId = 2,
                PageCount = 540,
                PublishDate = new DateTime(2010,02,15)
            }
        );
        context.SaveChanges();
            }
        }
    }
}