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
    public void TuningTrouble_ShouldReturnExpectedResult_WhenStartSequenceConsistsOf4DistinctCharacters(int expectedStartOfMessageIndex, string input)
    {
        // Arrange
        const int distinctCharactersCount = 4;

        // Act
        var result = Day06.TuningTrouble(input, distinctCharactersCount);

        // Assert
        Assert.Equal(expectedStartOfMessageIndex, result);
    }

    [Theory]
    [InlineData(19, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(23, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(23, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(29, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(26, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void TuningTrouble_ShouldReturnExpectedResult_WhenStartSequenceConsistsOf14DistinctCharacters(int expectedStartOfMessageIndex, string input)
    {
        // Arrange
        const int distinctCharactersCount = 14;

        // Act
        var result = Day06.TuningTrouble(input, distinctCharactersCount);

        // Assert
        Assert.Equal(expectedStartOfMessageIndex, result);
    }
}