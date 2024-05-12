using ManageSystemMovie.Domain.Entities;

namespace ManageSystemMovie.Test.Entities
{
    public class RoomMovieTest
    {
        [Fact]
        public void RoomMovie_WhenInitialized_ShouldHaveCorrectProperties()
        {
            // Arrange
            int expectedNumber = 1;
            string expectedDescription = "Description 1";
            var expectedMovies = new List<Movie>
            {
                new Movie { Name = "The Gladiator Redemption", Director = "Francis Ford Coppola", TimeMovie = 192 },
                new Movie { Name = "The Godfather The Final History", Director = "Francis Ford Coppola", TimeMovie = 105 }
            };

            // Act
            var roomMovie = new RoomMovie
            {
                Number = expectedNumber,
                Description = expectedDescription,
                Movies = expectedMovies
            };

            // Assert
            Assert.Equal(expectedNumber, roomMovie.Number);
            Assert.Equal(expectedDescription, roomMovie.Description);
            Assert.Equal(expectedMovies, roomMovie.Movies);
        }
    }
}