using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.UpdateBook{
    public class UpdateBookCommand{
        public UpdateBookModel Model { get; set; }
        private readonly IBookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public UpdateBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(){
            var book =  _dbContext.Books.SingleOrDefault(x=> x.Id == BookId);
            if(book is null) 
                throw new InvalidOperationException("böyle bir kitap yok");
            
            book.GenreId = Model.GenreId != default ? Model.GenreId:book.GenreId;
            book.Title = Model.Title != default ? Model.Title:book.Title;
            book.PageCount = Model.PageCount != default ? Model.PageCount:book.PageCount;
            book.PublishDate = Model.PublishDate != default ? (DateTime)Model.PublishDate:book.PublishDate;
           // _context.Entry(book);
            _dbContext.SaveChanges();
        }
    }
    public class UpdateBookModel{
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
