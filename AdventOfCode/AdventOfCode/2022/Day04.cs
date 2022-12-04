namespace AdventOfCode._2022;

public static class Day04
{
    public static int CampCleanupPart1(string input)
    {
        var lines = input.Split("\r\n");
        var containedCount = 0;

        foreach (var line in lines)
        {
            var pairs = line.Split(',');
            var pair1Sections = pairs[0].Split('-').Select(int.Parse).ToArray();
            var pair2Sections = pairs[1].Split('-').Select(int.Parse).ToArray();
            if (pair1Sections[0] >= pair2Sections[0] && pair1Sections[1] <= pair2Sections[1])
            {
                containedCount++;
            }
            else if (pair2Sections[0] >= pair1Sections[0] && pair2Sections[1] <= pair1Sections[1])
            {
                containedCount++;
            }
        }
        return containedCount;
    }
}