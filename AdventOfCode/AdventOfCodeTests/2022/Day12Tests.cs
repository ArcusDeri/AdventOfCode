using Xunit;
using AdventOfCode._2022;

namespace AdventOfCodeTests._2022;

public class Day12Tests
{
    [Fact]
    public void HillClimbingPart1_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = "Sabqponm\r\nabcryxxl\r\naccszExk\r\nacctuvwj\r\nabdefghi";
        const int expectedStepCount = 31;

        // Act
        var result = Day12Part1.HillClimbingPart1(input);

        // Assert
        Assert.Equal(expectedStepCount, result);
    }

    [Fact]
    public void HillClimbingPart2_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = "Sabqponm\r\nabcryxxl\r\naccszExk\r\nacctuvwj\r\nabdefghi";
        const int expectedStepCount = 29;

        // Act
        var result = Day12Part2.HillClimbingPart2(input);

        // Assert
        Assert.Equal(expectedStepCount, result);
    }
}