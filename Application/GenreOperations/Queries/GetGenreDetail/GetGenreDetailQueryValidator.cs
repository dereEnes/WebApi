using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenresDetail{
    public class GetGenreDetailQueryValidator:AbstractValidator<GetGenreDetailQuery>{
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.genreId).GreaterThan(0);
        }
    }
}