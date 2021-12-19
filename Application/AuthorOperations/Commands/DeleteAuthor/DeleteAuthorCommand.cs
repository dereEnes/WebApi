using System.Linq;
using WebApi.DBOperations;
using System;

namespace WebApi.Application.AuthorAoperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand{
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        public DeleteAuthorCommand(IBookStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle(){
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if(author is null)
                throw new InvalidOperationException("böyle bir Yazar yok");
            var book = _dbContext.Books.FirstOrDefault(book => book.AuthorId == AuthorId);
            if(book is not null)
                throw new InvalidOperationException("Bu yazarın önce kitaplarını siliniz");
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}