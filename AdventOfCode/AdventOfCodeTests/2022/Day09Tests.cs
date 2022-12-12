﻿using Xunit;
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
}