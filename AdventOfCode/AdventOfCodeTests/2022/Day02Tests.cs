using Xunit;
using AdventOfCode._2022;

namespace AdventOfCodeTests._2022;

public class Day02Tests
{
    [Fact]
    public void RockPaperScissorsPart1_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = "A Y\r\nB X\r\nC Z";
        
        const int expectedResult = 15;

        // Act
        var score = Day02.RockPaperScissorsPart1(input);

        // Assert
        Assert.Equal(expectedResult, score);
    }
}