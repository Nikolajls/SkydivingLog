using SkydivingLog.Infrastructure.Queries.CanopyRegulation;
using Xunit;

namespace SkydivingLog.Tests
{
    public class DanishCanopyRegulationsTests
    {
        [Theory]
        [InlineData(500, 105, 107, false, true)]
        [InlineData(399, 75, 190, false, true)]
        [InlineData(100, 95, 190, false, true)]
        [InlineData(100, 95, 230, false, true)]
        [InlineData(100, 100, 190, false, false)]
        [InlineData(300, 100, 190, false, true)]
        [InlineData(300, 100, 190, true, false)]
        public void CanJumperJumpByDanishRegulations(int jumpCount, double exitWeight, double squareFeet, bool isElliptical, bool expected)
        {
            //Arrange
            var regulations = new DanishCanopyRegulations();
            //Act
            var canJump = regulations.CanJump(jumpCount, exitWeight, squareFeet, isElliptical);
            //Assert
            Assert.Equal(expected, canJump);
        }
    }
}