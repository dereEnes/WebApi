using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.GetBook;

namespace WebApi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase{
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult GetBooks(){
            
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
            
        }
        [HttpGet("{id}")] // root dan almak
        public IActionResult GetById(int id){
            GetBookById command = new GetBookById(_context);
            var result = command.handle(id);
            if(result is null)
                return BadRequest("böyle bir kitap yok");
            return Ok(result);
            
        }
        // [HttpGet] // root dan almak
        // public Book GetById([FromQuery] string id){
        //     var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
            
        // }
        [HttpPost]
        public IActionResult AddBook([FromBody]CreateBookModel newBook){
            
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook){
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                 command.Model = updatedBook;
                 command.Handle(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            var book =  _context.Books.SingleOrDefault(x => x.Id == id);
            if(book is null)
                return BadRequest("böyle bir kitap yok");

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }

    }
    
}
