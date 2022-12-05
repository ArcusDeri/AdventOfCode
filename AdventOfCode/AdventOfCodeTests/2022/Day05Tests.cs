using Xunit;
using AdventOfCode._2022;

namespace AdventOfCodeTests._2022;

public class Day05Tests
{
    [Fact]
    public void SupplyStacksPart1_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = "    [D]    \r\n[N] [C]    \r\n[Z] [M] [P]\r\n 1   2   3 \r\n\r\nmove 1 from 2 to 1\r\nmove 3 from 1 to 3\r\nmove 2 from 2 to 1\r\nmove 1 from 1 to 2";
        const string expectedTopCrates = "CMZ";

        // Act
        var result = Day05Part1.SupplyStacks(input);
        
        // Assert
        Assert.Equal(expectedTopCrates, result);
    }

    [Fact]
    public void SupplyStacksPart2_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = "    [D]    \r\n[N] [C]    \r\n[Z] [M] [P]\r\n 1   2   3 \r\n\r\nmove 1 from 2 to 1\r\nmove 3 from 1 to 3\r\nmove 2 from 2 to 1\r\nmove 1 from 1 to 2";
        const string expectedTopCrates = "MCD";

        // Act
        var result = Day05Part2.SupplyStacks(input);
        
        // Assert
        Assert.Equal(expectedTopCrates, result);
    }
}