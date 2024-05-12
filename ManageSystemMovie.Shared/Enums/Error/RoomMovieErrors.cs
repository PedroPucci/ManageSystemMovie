using System.ComponentModel;

namespace ManageSystemMovie.Shared.Enums.Error
{
    public enum RoomMovieErrors
    {
        [Description("'Description' can not be null or empty!")]
        RoomMovie_Error_DescriptionCanNotBeNullOrEmpty,

        [Description("'Description' can not be less 10 letters!")]
        RoomMovie_Error_DescriptionCanNotLessTenLetters
    }
}