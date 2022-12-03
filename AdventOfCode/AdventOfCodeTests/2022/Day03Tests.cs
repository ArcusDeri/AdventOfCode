using AdventOfCode._2022;
using Xunit;

namespace AdventOfCodeTests._2022;

public class Day03Tests
{
    [Fact]
    public void RucksackReorganizationPart1_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = "vJrwpWtwJgWrhcsFMMfFFhFp\r\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\r\nPmmdzqPrVvPwwTWBwg\r\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\r\nttgJtRGJQctTZtZT\r\nCrZsJsPPZsGzwwsLwLmpwMDw";
        const int expectedPrioritySum = 157;

        // Act
        var result = Day03.RucksackReorganizationPart1(input);

        // Assert
        Assert.Equal(expectedPrioritySum, result);
    }

    [Fact]
    public void RucksackReorganizationPart2_ShouldReturnExpectedResult()
    {
        // Arrange
        var input = "vJrwpWtwJgWrhcsFMMfFFhFp\r\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\r\nPmmdzqPrVvPwwTWBwg\r\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\r\nttgJtRGJQctTZtZT\r\nCrZsJsPPZsGzwwsLwLmpwMDw";
        const int expectedPrioritySum = 70;

        // Act
        var result = Day03.RucksackReorganizationPart2(input);

        // Assert
        Assert.Equal(expectedPrioritySum, result);
    }
}