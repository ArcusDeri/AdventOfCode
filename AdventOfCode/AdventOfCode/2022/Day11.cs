using System.Numerics;

namespace AdventOfCode._2022;

public static class Day11
{
    public static int MonkeyInTheMiddlePart1(Dictionary<int, Monkey> monkeys)
    {
        var roundCount = 1;
        while (roundCount < 21)
        {
            for (int i = 0; i < monkeys.Count; i++)
            {
                var monkey = monkeys[i];
                while (monkey.Items.Any())
                {
                    var examinationResult = monkey.Examine();
                    var throwTo = monkey.ResolveThrowTo(examinationResult);
                    monkeys[throwTo].Items.Enqueue(examinationResult);
                }
            }
            roundCount++;
        }

        var max1 = 0;
        var max2 = 0;
        for (int i = 0; i < monkeys.Count; i++)
        {
            if (monkeys[i].InspectedCount > max1)
            {
                max2 = max1;
                max1 = monkeys[i].InspectedCount;
                continue;
            }

            if (monkeys[i].InspectedCount > max2)
            {
                max2 = monkeys[i].InspectedCount;
            }
        }

        return max1 * max2;
    }

    public static long MonkeyInTheMiddlePart2(Dictionary<int, DifficultMonkey> monkeys)
    {
        var roundCount = 1;
        var divisors = new List<int>();
        foreach (var monkey in monkeys)
        {
            divisors.Add(monkey.Value.Divisor);
        }

        var lowestCommonMultiple = divisors.Aggregate((val, next) => val * next / GetGreatestCommonDivisor(val, next));

        while (roundCount < 10001)
        {
            for (int i = 0; i < monkeys.Count; i++)
            {
                var monkey = monkeys[i];
                while (monkey.Items.Any())
                {
                    var examinationResult = monkey.Examine() % lowestCommonMultiple;
                    var throwTo = monkey.ResolveThrowTo(examinationResult);
                    monkeys[throwTo].Items.Enqueue(examinationResult);
                }
            }
            roundCount++;
        }

        var max1 = 0L;
        var max2 = 0L;
        for (int i = 0; i < monkeys.Count; i++)
        {
            if (monkeys[i].InspectedCount > max1)
            {
                max2 = max1;
                max1 = monkeys[i].InspectedCount;
                continue;
            }

            if (monkeys[i].InspectedCount > max2)
            {
                max2 = monkeys[i].InspectedCount;
            }
        }

        return max1 * max2;
    }

    private static int GetGreatestCommonDivisor(int x, int y) => y == 0 ? x : GetGreatestCommonDivisor(y, x % y);
}

public class Monkey
{
    public Queue<int> Items { get; init; }
    public Func<int, int> ResolveThrowTo { get; init; }
    public Func<int, int> OperationStrategy { get; init; }
    public int InspectedCount { private set; get; }

    public int Examine()
    {
        InspectedCount++;
        var old = Items.Dequeue();
        return OperationStrategy(old) / 3;
    }
}

public class DifficultMonkey
{
    public Queue<long> Items { get; init; }
    public Func<long, int> ResolveThrowTo { get; init; }
    public Func<long, long> OperationStrategy { get; init; }
    public long InspectedCount { private set; get; }
    public int Divisor { get; set; }

    public long Examine()
    {
        InspectedCount++;
        var old = Items.Dequeue();
        var x = OperationStrategy(old);
        return x;
    }
}
