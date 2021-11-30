using FluentValidation;

namespace WebApi.Application.AuthorAoperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidator:AbstractValidator<GetAuthorDetailQuery>{
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}