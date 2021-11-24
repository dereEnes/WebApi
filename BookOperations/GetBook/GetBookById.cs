using System.Linq;
using WebApi.BookOperations.GetBooks;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBook
{
    public class GetBookById{
        private readonly BookStoreDbContext _dbContext;
        public GetBookById(BookStoreDbContext context)
        {
            _dbContext = context;
        }
        public BooksViewModel handle(int id){
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == id);
            if(book is null)
                return null;
            BooksViewModel vm = new BooksViewModel();
            vm.Genre = book.GenreId.ToString();
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString();
            vm.Title = book.Title;
            return vm;
        }
    }
}