using System;
using FluentValidation;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>{
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(commond => commond.Model.GenreId).GreaterThan(0);
            RuleFor(commond => commond.Model.PageCount).GreaterThan(0);
            RuleFor(commond => commond.Model.PublishDate).LessThan(DateTime.Now.Date);
            RuleFor(commond => commond.Model.Title).MinimumLength(2);
        }
    }
}