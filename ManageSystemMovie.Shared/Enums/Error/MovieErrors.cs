using System.ComponentModel;

namespace ManageSystemMovie.Shared.Enums.Error
{
    public enum MovieErrors
    {
        [Description("'Name' can not be null or empty!")]
        Movie_Error_NameCanNotBeNullOrEmpty,

        [Description("'Director' can not be null or empty!")]
        Movie_Error_DirectorCanNotBeNullOrEmpty        
    }
}