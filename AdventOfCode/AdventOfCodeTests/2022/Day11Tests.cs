using System.Collections.Generic;
using AdventOfCode._2022;
using Xunit;

namespace AdventOfCodeTests._2022;

public class Day11Tests
{
    [Fact]
    public void MonkeyInTheMiddlePart1_ShouldReturnExpectedResultForDemoData()
    {
        // Arrange
        const int expectedResult = 10605;
        var monkeys = new Dictionary<int, Monkey>
        {
            {
                0,
                new Monkey
                {
                    Items = new Queue<int>(new[] {79, 98}),
                    OperationStrategy = old => old * 19,
                    ResolveThrowTo = val => val % 23 == 0 ? 2 : 3,
                }
            },
            {
                1,
                new Monkey
                {
                    Items = new Queue<int>(new[] {54, 65, 75, 74}),
                    OperationStrategy = old => old + 6,
                    ResolveThrowTo = val => val % 19 == 0 ? 2 : 0,
                }
            },
            {
                2,
                new Monkey
                {
                    Items = new Queue<int>(new[] {79, 60, 97}),
                    OperationStrategy = old => old * old,
                    ResolveThrowTo = val => val % 13 == 0 ? 1 : 3,
                }
            },
            {
                3,
                new Monkey
                {
                    Items = new Queue<int>(new[] {74}),
                    OperationStrategy = old => old + 3,
                    ResolveThrowTo = val => val % 17 == 0 ? 0 : 1,
                }
            },
        };
        // Act
        var result = Day11.MonkeyInTheMiddlePart1(monkeys);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void MonkeyInTheMiddlePart1_ShouldReturnExpectedResultForActualData()
    {
        // Arrange
        var monkeys = new Dictionary<int, Monkey>
        {
            {
                0,
                new Monkey
                {
                    Items = new Queue<int>(new[] {83, 88, 96, 79, 86, 88, 70}),
                    OperationStrategy = old => old * 5,
                    ResolveThrowTo = val => val % 11 == 0 ? 2 : 3,
                }
            },
            {
                1,
                new Monkey
                {
                    Items = new Queue<int>(new[] {59, 63, 98, 85, 68, 72}),
                    OperationStrategy = old => old * 11,
                    ResolveThrowTo = val => val % 5 == 0 ? 4 : 0,
                }
            },
            {
                2,
                new Monkey
                {
                    Items = new Queue<int>(new[] {90, 79, 97, 52, 90, 94, 71, 70}),
                    OperationStrategy = old => old + 2,
                    ResolveThrowTo = val => val % 19 == 0 ? 5 : 6,
                }
            },
            {
                3,
                new Monkey
                {
                    Items = new Queue<int>(new[] {97, 55, 62}),
                    OperationStrategy = old => old + 5,
                    ResolveThrowTo = val => val % 13 == 0 ? 2 : 6,
                }
            },
            {
                4,
                new Monkey
                {
                    Items = new Queue<int>(new[] {74, 54, 94, 76}),
                    OperationStrategy = old => old * old,
                    ResolveThrowTo = val => val % 7 == 0 ? 0 : 3,
                }
            },
            {
                5,
                new Monkey
                {
                    Items = new Queue<int>(new[] {58}),
                    OperationStrategy = old => old + 4,
                    ResolveThrowTo = val => val % 17 == 0 ? 7 : 1,
                }
            },
            {
                6,
                new Monkey
                {
                    Items = new Queue<int>(new[] {66, 63}),
                    OperationStrategy = old => old + 6,
                    ResolveThrowTo = val => val % 2 == 0 ? 7 : 5,
                }
            },
            {
                7,
                new Monkey
                {
                    Items = new Queue<int>(new[] {56, 56, 90, 96, 68}),
                    OperationStrategy = old => old + 7,
                    ResolveThrowTo = val => val % 3 == 0 ? 4 : 1,
                }
            },
        };
        // Act
        var result = Day11.MonkeyInTheMiddlePart1(monkeys);

        // Assert
        Assert.True(result > 0);
    }
}