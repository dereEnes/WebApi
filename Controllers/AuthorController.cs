using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorAoperations.Commands.CreateAuthor;
using WebApi.Application.AuthorAoperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorAoperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorAoperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorAoperations.Queries.GetAuthors;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(IBookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAuthors(){
            GetAuthorsQuery query = new GetAuthorsQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("id")]
        public IActionResult GetById(int id){
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);
            query.Id = id;
            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddAuthor(CreateAuthorModel newAuthor){
            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
            command.Model = newAuthor;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id){
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor([FromBody] UpdateAuthorModel updateAuthor,int id){
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Model = updateAuthor;
            command.AuthorId = id;

            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}