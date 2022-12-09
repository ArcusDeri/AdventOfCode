namespace AdventOfCode._2022;

public static class Day08
{
    public static int TreetopTreeHousePart1(string input)
    {
        var lines = input.Split("\r\n");
        var grid = new int[lines.Length][];
        var visibleMap = new Dictionary<string, int>();
        var visibleCount = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            var digits = lines[i].ToCharArray();
            grid[i] = new int[digits.Length];
            for (int j = 0; j < digits.Length; j++)
            {
                grid[i][j] = int.Parse(digits[j].ToString());
            }
        }

        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[y].Length; x++)
            {
                if (x == 0 || x == grid[y].Length - 1 || y == 0 || y == grid.Length - 1)
                {
                    visibleCount++;
                    continue;
                }

                var currentValue = grid[y][x];
                var fromLeft = true;
                for (int i = 0; i < x; i++)
                {
                    if (grid[y][i] >= currentValue)
                    {
                        fromLeft = false;
                        break;
                    }
                }

                if (fromLeft)
                {
                    visibleCount++;
                    continue;
                }

                var fromRight = true;
                for (int i = grid[y].Length - 1; i > x; i--)
                {
                    if (grid[y][i] >= currentValue)
                    {
                        fromRight = false;
                        break;
                    }
                }

                if (fromRight)
                {
                    visibleCount++;
                    continue;
                }

                var fromTop = true;
                for (int i = 0; i < y; i++)
                {
                    if (grid[i][x] >= currentValue)
                    {
                        fromTop = false;
                        break;
                    }
                }

                if (fromTop)
                {
                    visibleCount++;
                    continue;
                }

                var fromBottom = true;
                for (int i = grid.Length - 1; i > y; i--)
                {
                    if (grid[i][x] >= currentValue)
                    {
                        fromBottom = false;
                        break;
                    }
                }

                if (fromBottom)
                {
                    visibleCount++;
                }
            }
        }
        return visibleCount;
    }
}