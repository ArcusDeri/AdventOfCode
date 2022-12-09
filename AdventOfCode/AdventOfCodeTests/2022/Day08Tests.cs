using Xunit;
using AdventOfCode._2022;

namespace AdventOfCodeTests._2022;

public class Day08Tests
{
    [Fact]
    public void TreetopTreeHousePart1_ShouldReturnExpectedResult()
    {
        // Arrange
        const int expectedResult = 21;
        var input = "30373\r\n25512\r\n65332\r\n33549\r\n35390";

        // Act
        var result = Day08.TreetopTreeHousePart1(input);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void TreetopTreeHousePart2_ShouldReturnExpectedResult()
    {
        // Arrange
        const int expectedScenicScore = 8;
        var input = "30373\r\n25512\r\n65332\r\n33549\r\n35390";

        // Act
        var result = Day08.TreetopTreeHousePart2(input);

        // Assert
        Assert.Equal(expectedScenicScore, result);
    }
}