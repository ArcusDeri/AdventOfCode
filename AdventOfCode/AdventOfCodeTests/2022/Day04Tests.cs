using AdventOfCode._2022;
using Xunit;

namespace AdventOfCodeTests._2022;

public class Day04Tests
{
    [Fact]
    public void CampCleanupPart1_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = "2-4,6-8\r\n2-3,4-5\r\n5-7,7-9\r\n2-8,3-7\r\n6-6,4-6\r\n2-6,4-8";
        const int expectedFullyContainedPairs = 2;

        // Act
        var result = Day04.CampCleanupPart1(input);

        // Assert
        Assert.Equal(expectedFullyContainedPairs, result);
    }

    [Fact]
    public void CampCleanupPart2_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = "2-4,6-8\r\n2-3,4-5\r\n5-7,7-9\r\n2-8,3-7\r\n6-6,4-6\r\n2-6,4-8";
        const int expectedOverlappingPairsCount = 4;

        // Act
        var result = Day04.CampCleanupPart2(input);

        // Assert
        Assert.Equal(expectedOverlappingPairsCount, result);
    }
}