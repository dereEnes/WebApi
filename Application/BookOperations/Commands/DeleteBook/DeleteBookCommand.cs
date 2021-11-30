using System.Linq;
using WebApi.DBOperations;
using System;

namespace WebApi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand{
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public DeleteBookCommand(BookStoreDbContext context)
        {
            _dbContext = context;
        }
        public void Handle(){
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if(book is null)
                throw new InvalidOperationException("böyle bir kitap yok");
            _dbContext.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}