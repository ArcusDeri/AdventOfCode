using AdventOfCode._2022;
using Xunit;

namespace AdventOfCodeTests._2022;

public class Day01Tests
{
    [Fact]
    public void CountCalories_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = "1000\r\n2000\r\n3000\r\n\r\n4000\r\n\r\n5000\r\n6000\r\n\r\n7000\r\n8000\r\n9000\r\n\r\n10000";
        const int expectedResult = 24000;

        // Act
        var result = Day01.CountCaloriesPart1(input);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}