using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenresDetail
{
    public class GetGenreDetailQuery{
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int genreId;
        public GetGenreDetailQuery(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public GenreDetailViewModel Handle(){
            var genre = _dbContext.Genres.SingleOrDefault(x =>x.IsActive == true && x.Id == genreId);
            if(genre is null){
                throw new InvalidOperationException("Kitap türü bulunamadı!");
            }
            GenreDetailViewModel returnObj = _mapper.Map<GenreDetailViewModel>(genre);
            return returnObj;
        }

    }
    public class GenreDetailViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
    }
}