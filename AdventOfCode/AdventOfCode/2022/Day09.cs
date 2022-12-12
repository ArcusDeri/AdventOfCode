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

                var yDiff = Math.Abs(headPos.Y - tailPos.Y);
                var xDiff = Math.Abs(headPos.X - tailPos.X);

                if (yDiff == 1 && xDiff == 2 || yDiff == 2 && xDiff == 1)
                {
                    tailPos.X += headPos.X > tailPos.X ? 1 : -1;
                    tailPos.Y += headPos.Y > tailPos.Y ? 1 : -1;
                }
                else if (yDiff > 1)
                {
                    tailPos.Y += yStepSize;
                }
                else if (xDiff > 1)
                {
                    tailPos.X += xStepSize;
                }

                visitedMap[$"X{tailPos.X}Y{tailPos.Y}"] = 1;
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