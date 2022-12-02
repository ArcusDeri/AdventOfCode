
namespace AdventOfCode._2022;

public static class Day02
{
    // Scoring:
    // 1 for Rock (A, X)
    // 2 for Paper (B, Y)
    // 3 for Scissors (C, Z)
    // +0 for lose
    // +3 for draw
    // +6 for win
    private static Dictionary<string, int> RoundToScoreMap = new()
    {
        {"A X", 1 + 3},
        {"A Y", 2 + 6},
        {"A Z", 3 + 0},
        {"B X", 1 + 0},
        {"B Y", 2 + 3},
        {"B Z", 3 + 6},
        {"C X", 1 + 6},
        {"C Y", 2 + 0},
        {"C Z", 3 + 3},
    };

    public static int RockPaperScissorsPart1(string input)
    {
        var score = 0;
        for (int i = 0; i < input.Length; i += 5)
        {
            score += RoundToScoreMap[input[i..(i + 3)]];
        }

        return score;
    }
}
