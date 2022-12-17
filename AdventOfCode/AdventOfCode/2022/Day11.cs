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
