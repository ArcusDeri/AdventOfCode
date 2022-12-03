using System.Text;

namespace AdventOfCode._2022;

public static class Day03
{
    public static int RucksackReorganization(string input)
    {
        var i = 0;
        var lines = input.Split("\r\n");
        var prioritiesSum = 0;
        foreach (var line in lines)
        {
            var c1 = line[..(line.Length / 2)];
            var c2 = line[(line.Length / 2)..];
            var c1CharMap = new Dictionary<char, int>();

            foreach (var ch1 in c1)
            {
                if (c1CharMap.ContainsKey(ch1))
                {
                    c1CharMap[ch1]++;
                }
                else
                {
                    c1CharMap[ch1] = 1;
                }
            }

            var recurringItem = ' ';
            foreach (var ch2 in c2)
            {
                if (c1CharMap.ContainsKey(ch2))
                {
                    if (char.IsLower(ch2))
                    {
                        prioritiesSum += ch2 - 96;
                    }
                    else
                    {
                        prioritiesSum += ch2 - 38;
                    }

                    break;
                }
            }

        }
        return prioritiesSum;
    }
}