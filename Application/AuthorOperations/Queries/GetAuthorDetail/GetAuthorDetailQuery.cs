using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entites;

namespace WebApi.Application.AuthorAoperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery{
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id;
        public GetAuthorDetailQuery(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public AuthorDetailViewModel Handle(){
            var author = _context.Authors.FirstOrDefault(x => x.Id == Id);
            if(author is null)
                throw new InvalidOperationException("Böyle bir yazar yok");
            return _mapper.Map<AuthorDetailViewModel>(author);
        }
    }
    public class AuthorDetailViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}