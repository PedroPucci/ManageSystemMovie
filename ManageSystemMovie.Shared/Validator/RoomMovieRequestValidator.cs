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
                .MinimumLength(4)
                .WithMessage(RoomMovieErrors.RoomMovie_Error_DescriptionCanNotBeNullOrEmpty.Description());
        }
    }
}