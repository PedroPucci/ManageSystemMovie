using FluentValidation;
using ManageSystemMovie.Domain.Entities;
using ManageSystemMovie.Shared.Enums.Error;
using ManageSystemMovie.Shared.Helpers;

namespace ManageSystemMovie.Shared.Validator
{
    public class MovieRequestValidator : AbstractValidator<Movie>
    {
        public MovieRequestValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(4)
                .WithMessage(MovieErrors.Movie_Error_NameCanNotBeNullOrEmpty.Description());

            RuleFor(p => p.Director)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(10)
                .WithMessage(MovieErrors.Movie_Error_DirectorCanNotBeNullOrEmpty.Description());
        }
    }
}