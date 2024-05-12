using ManageSystemMovie.Domain.Entities;

namespace ManageSystemMovie.Test.Entities
{
    public class MovieTest
    {
        [Fact]
        public void Movie_Success_ShouldHaveCorrectProperties()
        {
            // Arrange
            string expectedName = "Guerra dos mundos";
            string expectedDirector = "Pedro Ighor Holanda";
            int expectedTimeMovie = 200;

            // Act
            var movie = new Movie
            {
                Name = expectedName,
                Director = expectedDirector,
                TimeMovie = expectedTimeMovie
            };

            // Assert
            Assert.Equal(expectedName, movie.Name);
            Assert.Equal(expectedDirector, movie.Director);
            Assert.Equal(expectedTimeMovie, movie.TimeMovie);
        }
    }
}