namespace AdventOfCode._2022;

public static class Day03
{
    public static int RucksackReorganizationPart1(string input)
    {
        var lines = input.Split("\r\n");
        var prioritiesSum = 0;
        foreach (var line in lines)
        {
            var c1 = line[..(line.Length / 2)];
            var c2 = line[(line.Length / 2)..];
            var c1CharMap = new Dictionary<char, int>();

            foreach (var ch1 in c1)
            {
                c1CharMap[ch1] = 1;
            }

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

    public static int RucksackReorganizationPart2(string input)
    {
        var lines = input.Split("\r\n");
        var groups = new List<List<string>>();
        for (int i = 0; i < lines.Length / 3; i++)
        {
            groups.Add(lines.Skip(i * 3).Take(3).ToList());
        }
        var prioritiesSum = 0;
        foreach (var group in groups)
        {
                var c1 = group[0].ToCharArray();
                var c2 = group[1].ToCharArray();
                var c1CharMap = new Dictionary<char, int>();
                var c2CharMap = new Dictionary<char, int>();

                foreach (var ch1 in c1)
                {
                    c1CharMap[ch1] = 1;
                }

                foreach (var ch2 in c2)
                {
                    c2CharMap[ch2] = 1;
                }

                foreach (var ch3 in group[2].ToCharArray())
                {
                    if (c1CharMap.ContainsKey(ch3) && c2CharMap.ContainsKey(ch3))
                    {
                        if (char.IsLower(ch3))
                        {
                            prioritiesSum += ch3 - 96;
                        }
                        else
                        {
                            prioritiesSum += ch3 - 38;
                        }

                        break;
                    }
                }
        }
        
        return prioritiesSum;
    }
}