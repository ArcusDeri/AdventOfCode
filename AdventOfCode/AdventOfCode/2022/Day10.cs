using System.Text;

namespace AdventOfCode._2022;

public class Day10
{
    public static int CathodeRayTubePart1(string input)
    {
        var instructionLines = input.Split("\r\n");
        var x = 1;
        var cycleCount = 0;
        var result = 0;
        var readAtCycle = 20;

        foreach (var instructionLine in instructionLines)
        {
            if (instructionLine == "noop")
            {
                cycleCount++;
                if (cycleCount == readAtCycle && readAtCycle < 221)
                {
                    result += cycleCount * x;
                    readAtCycle += 40;
                }
                continue;
            }

            var addValue = int.Parse(instructionLine.Split(" ")[1]);
            for (int i = 0; i < 2; i++)
            {
                cycleCount++;
                
                if (cycleCount == readAtCycle && readAtCycle < 221)
                {
                    result += cycleCount * x;
                    readAtCycle += 40;
                }
            }

            x += addValue;
        }
        
        return result;
    }

    public static string CathodeRayTubePart2(string input)
    {
        var instructionLines = input.Split("\r\n");
        var x = 1;
        var sb = new StringBuilder();
        var instructionIndex = 0;
        var cycle = 0;

        while (cycle < 240)
        {
            if (instructionLines[instructionIndex] == "noop")
            {
                DrawPixel();

                instructionIndex++;
                cycle++;
                continue;
            }

            DrawPixel();
            cycle++;
            var addValue = int.Parse(instructionLines[instructionIndex].Split(" ")[1]);

            DrawPixel();
            cycle++;

            x += addValue;
            instructionIndex++;
        }

        for (int i = 1; i < 6; i++)
        {
            sb.Insert(40 * i + 2 * (i - 1), "\r\n");
        }

        void DrawPixel()
        {
            var normalizedCycle = cycle % 40;
            if (x - 1 <= normalizedCycle && normalizedCycle <= x + 1)
            {
                sb.Append('#');
            }
            else
            {
                sb.Append('.');
            }
        } 
        return sb.ToString();
    }
}