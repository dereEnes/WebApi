using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Queries.GetBook
{
    public class GetBookDetailQuery{
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set;}
        public GetBookDetailQuery(BookStoreDbContext context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;

        }
        public BookViewModel handle(){
            var book = _dbContext.Books.Include(x =>x.Genre).Include(x => x.Author).SingleOrDefault(x => x.Id == BookId);
            if(book is null)
                throw new InvalidOperationException("kitap bulunamadı!");
            BookViewModel vm = _mapper.Map<BookViewModel>(book);
            // vm.Genre = ((GenreEnum)book.GenreId).ToString();
            // vm.PageCount = book.PageCount;
            // vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            // vm.Title = book.Title;
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