using Xunit;
using AdventOfCode._2022;

namespace AdventOfCodeTests._2022;

public class Day07Tests
{
    [Fact]
    public void NoSpaceLeftOnDevicePart1_ShouldReturnExpectedResult()
    {
        // Arrange
        const int expectedCumulativeDirectorySize = 95_437;
        var input = "$ cd /\r\n$ ls\r\ndir a\r\n14848514 b.txt\r\n8504156 c.dat\r\ndir d\r\n$ cd a\r\n$ ls\r\ndir e\r\n29116 f\r\n2557 g\r\n62596 h.lst\r\n$ cd e\r\n$ ls\r\n584 i\r\n$ cd ..\r\n$ cd ..\r\n$ cd d\r\n$ ls\r\n4060174 j\r\n8033020 d.log\r\n5626152 d.ext\r\n7214296 k";

        // Act
        var result = Day07.NoSpaceLeftOnDevicePart1(input);

        // Assert
        Assert.Equal(expectedCumulativeDirectorySize, result);
    }

    [Fact]
    public void NoSpaceLeftOnDevicePart2_ShouldReturnExpectedResult()
    {
        // Arrange
        const int expectedMinSize = 24_933_642;
        var input = "$ cd /\r\n$ ls\r\ndir a\r\n14848514 b.txt\r\n8504156 c.dat\r\ndir d\r\n$ cd a\r\n$ ls\r\ndir e\r\n29116 f\r\n2557 g\r\n62596 h.lst\r\n$ cd e\r\n$ ls\r\n584 i\r\n$ cd ..\r\n$ cd ..\r\n$ cd d\r\n$ ls\r\n4060174 j\r\n8033020 d.log\r\n5626152 d.ext\r\n7214296 k";

        // Act
        var result = Day07.NoSpaceLeftOnDevicePart2(input);

        // Assert
        Assert.Equal(expectedMinSize, result);
    }
}