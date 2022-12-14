namespace AdventOfCode._2022;

public static class Day09
{
    public static int RopeBridgePart1(string input)
    {
        var lines = input.Split("\r\n");
        var visitedMap = new Dictionary<string, int> {{"X0Y0", 1}};
        var tailPos = new Point(0, 0);
        var headPos = new Point(0, 0);

        foreach (var instruction in lines)
        {
            var instructionPart = instruction.Split(" ");
            var direction = instructionPart[0];
            var steps = int.Parse(instructionPart[1]);
            var xStepSize = direction == "L" ? -1 : 1;
            var yStepSize = direction == "D" ? -1 : 1;
            for (int i = 0; i < steps; i++)
            {
                if (direction is "R" or "L")
                {
                    headPos.X += xStepSize;
                }
                else
                {
                    headPos.Y += yStepSize;
                }

                if (Math.Abs(tailPos.X - headPos.X) <= 1 && Math.Abs(tailPos.Y - headPos.Y) <= 1)
                {
                    continue;
                }

                var yDiff = Math.Sign(tailPos.Y - headPos.Y);
                var xDiff = Math.Sign(tailPos.X - headPos.X);
                tailPos.X -= xDiff;
                tailPos.Y -= yDiff;
                visitedMap[$"X{tailPos.X}Y{tailPos.Y}"] = 1;
            }
        }
        return visitedMap.Count;
    }

    public static int RopeBridgePart2(string input)
    {
        var lines = input.Split("\r\n");
        var visitedMap = new Dictionary<string, int> {{"X0Y0", 1}};
        var knots = new[]
        {
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
            new Point(0, 0),
        };
        var headPos = knots[0];

        foreach (var instruction in lines)
        {
            var instructionPart = instruction.Split(" ");
            var direction = instructionPart[0];
            var steps = int.Parse(instructionPart[1]);
            var xStepSize = direction == "L" ? -1 : 1;
            var yStepSize = direction == "D" ? -1 : 1;

            for (int i = 0; i < steps; i++)
            {
                if (direction is "R" or "L")
                {
                    headPos.X += xStepSize;
                }
                else
                {
                    headPos.Y += yStepSize;
                }

                 
                for (int j = 1; j < knots.Length; j++)
                {
                    if (Math.Abs(knots[j].X - knots[j - 1].X) <= 1 && Math.Abs(knots[j].Y - knots[j - 1].Y) <= 1)
                    {
                        continue;
                    }
                    var yDiff = Math.Sign(knots[j].Y - knots[j - 1].Y);
                    var xDiff = Math.Sign(knots[j].X - knots[j - 1].X);

                    knots[j].Y -= yDiff;
                    knots[j].X -= xDiff;
                }
                visitedMap[$"X{knots[9].X}Y{knots[9].Y}"] = 1;
            }
        }
        return visitedMap.Count;
    }

    private class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    };
}