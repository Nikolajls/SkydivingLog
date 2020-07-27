using SkydivingLog.Infrastructure.Queries.CanopyRegulation;
using Xunit;

namespace SkydivingLog.Tests
{
    //Since USPA comes from the land of the free everything is allowed!
    //Properly not in reality but right now in this system it is :)
    public class USPACanopyRegulationsTests
    {
        [Theory]
        [InlineData(500, 105, 107, false, true)]
        [InlineData(399, 75, 190, false, true)]
        [InlineData(100, 95, 190, false, true)]
        [InlineData(100, 95, 230, false, true)]
        [InlineData(100, 100, 190, false, true)]
        [InlineData(300, 100, 190, false, true)]
        [InlineData(300, 100, 190, true, true)]
        public void CanJumperJumpByUSPARegulations(int jumpCount, double exitWeight, double squareFeet, bool isElliptical, bool expected)
        {
            //Arrange
            var regulations = new UspaCanopyRegulations();
            //Act
            var canJump = regulations.CanJump(jumpCount, exitWeight, squareFeet, isElliptical);
            //Assert
            Assert.Equal(expected, canJump);
        }
    }
}