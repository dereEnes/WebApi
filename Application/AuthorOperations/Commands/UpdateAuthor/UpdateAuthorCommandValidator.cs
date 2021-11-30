using System;
using FluentValidation;

namespace WebApi.Application.AuthorAoperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>{
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.Name).MinimumLength(3);
            RuleFor(command => command.Model.LastName).MinimumLength(3);
            RuleFor(command => command.Model.DateOfBirth).LessThan(DateTime.Today);
        }
    }
}