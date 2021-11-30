using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entites;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand{
        public int GenreId;
        private readonly BookStoreDbContext _context;
        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
            var genre = _context.Genres.Find(GenreId);
            if(genre is null)
                throw new InvalidOperationException("böyle bir tür yok");
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}