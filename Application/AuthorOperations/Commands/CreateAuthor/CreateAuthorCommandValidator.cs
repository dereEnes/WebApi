using System;
using FluentValidation;

namespace WebApi.Application.AuthorAoperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>{
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.DateOfBirth).LessThan(DateTime.Today);
            RuleFor(command => command.Model.LastName).MinimumLength(2);
            RuleFor(command => command.Model.Name).MinimumLength(2);
        }
    }
}