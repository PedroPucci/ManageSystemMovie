using FluentValidation;
using ManageSystemMovie.Domain.Entities;
using ManageSystemMovie.Shared.Enums.Error;
using ManageSystemMovie.Shared.Helpers;

namespace ManageSystemMovie.Shared.Validator
{
    public class RoomMovieRequestValidator : AbstractValidator<RoomMovie>
    {
        public RoomMovieRequestValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage(RoomMovieErrors.RoomMovie_Error_DescriptionCanNotBeNullOrEmpty.Description());

            RuleFor(p => p.Description)
                .MinimumLength(10)
                .WithMessage(RoomMovieErrors.RoomMovie_Error_DescriptionCanNotLessTenLetters.Description());
        }
    }
}