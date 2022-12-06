namespace AdventOfCode._2022;

public static class Day06
{
    public static int TuningTrouble(string input, int distinctCharactersCount)
    {
        var charMap = new Dictionary<char, int>();
        var charPos = 0;
        while (charMap.Count < distinctCharactersCount)
        {
            for (int aheadLookupPos = charPos; aheadLookupPos <  charPos + distinctCharactersCount ; aheadLookupPos++)
            {
                if (charMap.ContainsKey(input[aheadLookupPos]))
                {
                    charMap.Clear();
                    break;
                }

                charMap[input[aheadLookupPos]] = default;
                if (charMap.Count == distinctCharactersCount)
                {
                    return aheadLookupPos + 1;
                }
            }

            charPos++;
        }

        throw new Exception("Packet start sequence not found");
    }
}