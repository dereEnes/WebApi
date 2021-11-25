using System;
using System.Linq;
using WebApi.BookOperations.GetBooks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBook
{
    public class GetBookDetailQuery{
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set;}
        public GetBookDetailQuery(BookStoreDbContext context)
        {
            _dbContext = context;
        }
        public BookViewModel handle(){
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if(book is null)
                throw new InvalidOperationException("kitap bulunamadı!");
            BookViewModel vm = new BookViewModel();
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            vm.Title = book.Title;
            return vm;
        }
    }
    public class BookViewModel{
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}