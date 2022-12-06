namespace AdventOfCode._2022;

public static class Day06
{
    public static int TuningTroublePart1(string input)
    {
        var charMap = new Dictionary<char, int>();
        var charPos = 0;
        while (charMap.Count < 4)
        {
            for (int aheadLookupPos = charPos; aheadLookupPos <  charPos + 4 ; aheadLookupPos++)
            {
                if (charMap.ContainsKey(input[aheadLookupPos]))
                {
                    charMap.Clear();
                    break;
                }

                charMap[input[aheadLookupPos]] = default;
                if (charMap.Count == 4)
                {
                    return aheadLookupPos + 1;
                }
            }

            charPos++;
        }

        throw new Exception("Packet start sequence not found");
    }
}