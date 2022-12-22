namespace AdventOfCode._2022;

public class Day12
{
    public static int HillClimbingPart1(string input)
    {
        var rows = input.Split("\r\n");
        var heights = new int[rows.Length, rows[0].Length];
        Coords start = null, end = null;
        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < rows[i].Length; j++)
            {
                heights[i, j] = ResolveHeightForChar(rows[i][j]);
                if (rows[i][j] == 'S')
                {
                    start = new Coords(j, i);
                }

                if (rows[i][j] == 'E')
                {
                    end = new Coords(j, i);
                }
            }
        }

        var finder = new CoordsFinder(new HeightMap(heights), start);
        var result = 0;
        while (finder.IsCrawling)
        {
            var current = finder.CrawlNext();
            if (current == end)
            {
                result = finder.DistanceTo(current);
                break;
            }
        }

        int ResolveHeightForChar(char c) => c switch
        {
            'S' => 0,
            'E' => 'z' - 'a',
            _ => c - 'a'
        };
        return result;
    }

    private class CoordsFinder
    {
        private int[,] _distances;
        private Coords _start;
        private HeightMap _map;
        private readonly Queue<Coords> _queue;

        public CoordsFinder(HeightMap map, Coords start)
        {
            _start = start;
            _map = map;
            _distances = new int[_map.RowCount, _map.ColumnCount];
            for (int i = 0; i < _map.RowCount; i++)
            {
                for (int j = 0; j < _map.ColumnCount; j++)
                {
                    _distances[i, j] = -1;
                }
            }

            _distances[_start.Y, _start.X] = 0;
            _queue = new Queue<Coords>();
            _queue.Enqueue(start);
        }

        public int DistanceTo(Coords xy)
        {
            return _distances[xy.Y, xy.X];
        }

        public bool IsCrawling => _queue.Any();

        public Coords CrawlNext()
        {
            var currentXy = _queue.Dequeue();

            foreach (var neighbor in _map.GetAccessibleNeighbors(currentXy))
            {
                if (_distances[neighbor.Y, neighbor.X] == -1)
                {
                    _distances[neighbor.Y, neighbor.X] = _distances[currentXy.Y, currentXy.X] + 1;
                    _queue.Enqueue(neighbor);
                }
            }

            return currentXy;
        }
    }

    private class HeightMap
    {
        public int RowCount => Heights.GetLength(0);
        public int ColumnCount => Heights.GetLength(1);
        public int[,] Heights { get; }

        public HeightMap(int[,] heights)
        {
            Heights = heights;
        }

        public IEnumerable<Coords> GetAccessibleNeighbors(Coords xy)
        {
            return xy.Neighbors.Where(neighbor => CanMoveFromTo(xy, neighbor));
        }

        public bool Contains(Coords xy)
        {
            return xy.X >= 0 && xy.Y >= 0 && xy.X < ColumnCount && xy.Y < RowCount;
        }

        public bool CanMoveFromTo(Coords from, Coords to)
        {
            if (!Contains(from) || !Contains(to))
            {
                return false;
            }

            var destinationHeight = Heights[to.Y, to.X];
            var startHeight = Heights[from.Y, from.X];

            return destinationHeight <= startHeight + 1;
        }
    }

    private record Coords(int X, int Y)
    {
        public Coords Up => this with {Y = Y + 1};
        public Coords Right => this with {X = X + 1};
        public Coords Down => this with {Y = Y - 1};
        public Coords Left => this with {X = X - 1};

        public IEnumerable<Coords> Neighbors => new[] {Up, Right, Down, Left};
    }
}