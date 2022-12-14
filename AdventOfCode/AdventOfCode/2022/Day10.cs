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
}