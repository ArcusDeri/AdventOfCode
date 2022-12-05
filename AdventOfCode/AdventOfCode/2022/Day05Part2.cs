using System.Text;

namespace AdventOfCode._2022;

public static class Day05Part2
{
    public static string SupplyStacks(string input)
    {
        var inputParts = input.Split("\r\n\r\n");
        var cratesSetupLines = inputParts[0].Split("\r\n");
        var rearrangementInstructions = ResolveRearrangementInstructions(inputParts[1]);
        var stackMap = ResolveStackMap(cratesSetupLines);

        foreach (var instruction in rearrangementInstructions)
        {
            if (instruction.CratesToBeMovedCount == 1)
            {
                stackMap[instruction.ToStackId].Push(stackMap[instruction.FromStackId].Pop());
                continue;
            }

            var helperStack = new Stack<char>();
            for (int i = 0; i < instruction.CratesToBeMovedCount; i++)
            {
                helperStack.Push(stackMap[instruction.FromStackId].Pop());
            }

            while (helperStack.Any())
            {
                stackMap[instruction.ToStackId].Push(helperStack.Pop());
            }
        }

        var sb = new StringBuilder();
        foreach (var stack in stackMap.Values)
        {
            sb.Append(stack.Peek());
        }

        return sb.ToString();
    }

    private static RearrangementInstruction[] ResolveRearrangementInstructions(string instructionsInput)
    {
        var instructionLines = instructionsInput.Split("\r\n");

        return instructionLines.Select(instructionLine => instructionLine.Split(" "))
            .Select(words =>
                new RearrangementInstruction(int.Parse(words[1]), int.Parse(words[3]), int.Parse(words[5])))
            .ToArray();
    }

    private static Dictionary<int, Stack<char>> ResolveStackMap(string[] setupLines)
    {
        var stackMap = new Dictionary<int, Stack<char>>();

        // Resolve how many stacks are needed
        for (int i = 1, j = 1; i < setupLines[0].Length; i += 4, j++)
        {
            stackMap[j] = new Stack<char>();
        }

        // fill the stacks: start from the top so the top crate will be at the bottom - it will be inverted later
        foreach (var setupLine in setupLines)
        {
            for (int i = 1, j = 1; i < setupLine.Length; i += 4, j++)
            {
                if (char.IsLetter(setupLine[i]))
                {
                    stackMap[j].Push(setupLine[i]);
                }
            }
        }

        // invert the stacks
        foreach (var stackEntry in stackMap)
        {
            var inversionStack = new Stack<char>();
            while (stackEntry.Value.Any())
            {
                inversionStack.Push(stackEntry.Value.Pop());
            }

            stackMap[stackEntry.Key] = inversionStack;
        }

        return stackMap;
    }

    private record RearrangementInstruction(int CratesToBeMovedCount, int FromStackId, int ToStackId);
}