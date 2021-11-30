using AutoMapper;
using WebApi.Application.AuthorAoperations.Commands.CreateAuthor;
using WebApi.Application.AuthorAoperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorAoperations.Queries.GetAuthors;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Queries.GetBook;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenresDetail;
using WebApi.Entites;

namespace WebApi.Common
{
    public class MappingProfile:Profile{
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            //CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().
            ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            //.ForMember(dest => dest.AuthorName ,opt => opt.MapFrom(src => src.Author.Name))
            //.ForMember(dest => dest.AuthorLastName , opt => opt.MapFrom(src => src.Author.LastName))
            .ForMember(dest => dest.Author , opt => opt.MapFrom(src =>src.Author));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();
            CreateMap<CreateAuthorModel,Author>();
        }
    }
}