using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entites;

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
                AuthorId = 1,
                PublishDate = new DateTime(2001,06,12)
            },
            new Book{
                Title = "Herland",
                GenreId = 3,
                PageCount = 300,
                AuthorId = 2,
                PublishDate = new DateTime(2002,10,30)
            },
            new Book{
                Title = "Dune",
                GenreId = 2,
                PageCount = 540,
                AuthorId = 3,
                PublishDate = new DateTime(2010,02,15)
            }
        );
        context.SaveChanges();
        if(context.Genres.Any()){
            return;
        }
        context.Genres.AddRange( 
            new Genre{
                Name = "Personal Growth",
            },
            new Genre{
                Name = "Science fiction",
            },
            new Genre{
                Name = "Romance",
            }
        );
        context.SaveChanges();
        if(context.Authors.Any()){
           return; 
        }
        context.Authors.AddRange(
            new Author{
                Name = "Enes",
                LastName = "Dere",
                DateOfBirth = new DateTime(1997,03,16)
            },
            new Author{
                Name = "Oguzhan",
                LastName = "Dere",
                DateOfBirth = new DateTime(1999,08,11)
            },
            new Author{
                Name = "Deneme",
                LastName = "Deneme",
                DateOfBirth = new DateTime(1940,05,10)
            }
        );
        context.SaveChanges();
            }
        }
    }
}