using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorAoperations.Commands.UpdateAuthor{
    public class UpdateAuthorCommand{
        public UpdateAuthorModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        public int AuthorId { get; set; }
        public UpdateAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(){
            var author =  _dbContext.Authors.SingleOrDefault(x=> x.Id == AuthorId);
            if(author is null) 
                throw new InvalidOperationException("böyle bir Yazar yok");
            
            author.Name = Model.Name != default ? Model.Name:author.Name;
            author.LastName = Model.LastName != default ? Model.LastName:author.LastName;
            author.DateOfBirth = Model.DateOfBirth != default ? Model.DateOfBirth:author.DateOfBirth;
           // _context.Entry(book);
            _dbContext.SaveChanges();
        }
    }
    public class UpdateAuthorModel{
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
