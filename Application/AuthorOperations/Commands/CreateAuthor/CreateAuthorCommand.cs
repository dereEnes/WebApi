using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entites;

namespace WebApi.Application.AuthorAoperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand{
        private readonly BookStoreDbContext _context;
        public CreateAuthorModel Model {get; set;}
        private readonly IMapper _mapper;
        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle(){
            var author = _context.Authors.SingleOrDefault( x => x.Name == Model.Name && x.LastName == Model.LastName && x.DateOfBirth == Model.DateOfBirth);
            if(author is not null)
                throw new InvalidOperationException("böyle bir yazar zaten var");
            author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();
            
            
        }
    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}