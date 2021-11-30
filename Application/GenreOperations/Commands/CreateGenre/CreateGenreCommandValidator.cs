using FluentValidation;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>{
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(3).NotEmpty();
        }
    }
}