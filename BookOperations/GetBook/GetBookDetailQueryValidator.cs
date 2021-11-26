using FluentValidation;

namespace WebApi.BookOperations.GetBook
{
    public class GetBookDetailQueryValidator:AbstractValidator<GetBookDetailQuery>{
        public GetBookDetailQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}