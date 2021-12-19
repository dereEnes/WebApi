using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entites;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand{
        public UpdateGenreModel Model;
        public int GenreId;
        private readonly IBookStoreDbContext _context;
        public UpdateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(x =>x.Id == GenreId);
            if(genre is null)
                throw new InvalidOperationException("böyle bir tür yok");
            if(_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException("Aynı isimli kitap türü zaten var");
            genre.Name = Model.Name.Trim() != default ? Model.Name : genre.Name;
            genre.IsActive = Model.IsActive ;
            _context.SaveChanges();
        }
    }
    public class UpdateGenreModel{
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}