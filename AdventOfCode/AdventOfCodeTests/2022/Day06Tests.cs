using AdventOfCode._2022;
using Xunit;

namespace AdventOfCodeTests._2022;

public class Day06Tests
{
    [Theory]
    [InlineData(7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(5, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(6, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void TuningTroublePart1_ShouldReturnExpectedResult(int expectedStartOfMessageIndex, string input)
    {
        // Arrange
        // Act
        var result = Day06.TuningTroublePart1(input);

        // Assert
        Assert.Equal(expectedStartOfMessageIndex, result);
    }
}