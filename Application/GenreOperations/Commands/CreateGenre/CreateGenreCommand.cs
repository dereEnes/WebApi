using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entites;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand{
        private readonly BookStoreDbContext _context;
        public CreateGenreModel Model {get; set;}
        public CreateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
            var genre = _context.Genres.SingleOrDefault( x => x.Name == Model.Name);
            if(genre is not null)
                throw new InvalidOperationException("zaten var");
            genre = new Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
            
            
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}