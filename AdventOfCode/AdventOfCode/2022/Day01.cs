using System.Text;

namespace AdventOfCode._2022;

public static class Day01
{
    public static int CountCaloriesPart1(string input)
    {
        var sb = new StringBuilder();
        var i = 0;
        var max = 0;
        var currentElfSum = 0;

        while (i < input.Length)
        {
            if (input[i..(i + 4)] == "\r\n\r\n")
            {
                max = currentElfSum > max ? currentElfSum : max;
                currentElfSum = 0;
                i += 4;
            }
            else
            {
                if (input[i..(i + 2)] == "\r\n")
                {
                    i += 2;
                }

                while (i < input.Length && input[i] != '\r')
                {
                    sb.Append(input[i++]);
                }

                currentElfSum += int.Parse(sb.ToString());
                sb.Clear();
            }
        }

        return max;
    }
}