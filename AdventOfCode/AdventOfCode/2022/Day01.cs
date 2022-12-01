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

    public static int CountCaloriesPart2(string input)
    {
        var sb = new StringBuilder();
        var i = 0;
        int max1 = 0, max2 = 0, max3 = 0;
        var currentElfSum = 0;

        while (i < input.Length)
        {
            if (input[i..(i + 4)] == "\r\n\r\n")
            {
                if (currentElfSum > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = currentElfSum;
                }
                else if (currentElfSum > max2)
                {
                    max3 = max2;
                    max2 = currentElfSum;
                }
                else if (currentElfSum > max3)
                {
                    max3 = currentElfSum;
                }
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

        if (currentElfSum > max1)
        {
            return currentElfSum + max1 + max2;
        }

        if (currentElfSum > max2)
        {
            return max1 + currentElfSum + max2;
        }

        if (currentElfSum > max3)
        {
            return max1 + max2 + currentElfSum;
        }

        return max1 + max2 + max3;
    }
}