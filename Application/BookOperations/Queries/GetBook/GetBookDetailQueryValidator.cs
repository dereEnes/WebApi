using FluentValidation;

namespace WebApi.Application.BookOperations.Queries.GetBook
{
    public class GetBookDetailQueryValidator:AbstractValidator<GetBookDetailQuery>{
        public GetBookDetailQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}