using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entites;

namespace WebApi.Application.AuthorAoperations.Queries.GetAuthors
{
    public class GetAuthorsQuery{
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Author> Handle(){
            var authors = _context.Authors.ToList();
            return _mapper.Map<List<Author>>(authors);
        }
    }
    public class AuthorsViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}