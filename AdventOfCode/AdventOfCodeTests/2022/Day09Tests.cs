using Xunit;
using AdventOfCode._2022;

namespace AdventOfCodeTests._2022;

public class Day09Tests
{
    [Fact]
    public void RopeBridgePart1_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = "R 4\r\nU 4\r\nL 3\r\nD 1\r\nR 4\r\nD 1\r\nL 5\r\nR 2";
        const int expectedPositionsCount = 13;

        // Act
        var result = Day09.RopeBridgePart1(input);

        // Assert
        Assert.Equal(expectedPositionsCount, result);
    }

    [Fact]
    public void RopeBridgePart2_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = "R 5\r\nU 8\r\nL 8\r\nD 3\r\nR 17\r\nD 10\r\nL 25\r\nU 20";
        const int expectedPositionsCount = 36;

        // Act
        var result = Day09.RopeBridgePart2(input);

        // Assert
        Assert.Equal(expectedPositionsCount, result);
    }
}