using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.UpdateBook;
using WebApi.BookOperations.GetBook;
using WebApi.BookOperations.DeleteBook;

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
            GetBookDetailQuery command = new GetBookDetailQuery(_context);
            command.BookId = id;
            BookViewModel result = new BookViewModel();
            try
            {
                result = command.handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
                command.BookId = id;
                 command.Model = updatedBook;
                 command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            try
            {
                 command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

    }
    
}
