namespace AdventOfCode._2022;

public class Day07
{
    public static int NoSpaceLeftOnDevicePart1(string input)
    {
        var root = ResolveFileSystemTree(input);
        var stack = new Stack<TreeNode>(new[] {root});
        var candidateDirSizes = 0;
        while (stack.Any())
        {
            var current = stack.Pop();
            if (current.Size < 100_000)
            {
                candidateDirSizes += current.Size;
            }

            foreach (var dir in current.Directories.Values)
            {
                stack.Push(dir);
            }
        }

        return candidateDirSizes;
    }

    private static TreeNode ResolveFileSystemTree(string input)
    {
        var root = new TreeNode("/");
        var currentNode = root;
        var inputLines = input.Split("\r\n");

        for (int i = 1; i < inputLines.Length; i++)
        {
            var currentLine = inputLines[i];
            if (currentLine == "$ ls")
            {
                continue;
            }

            if (currentLine.StartsWith("dir"))
            {
                var dirName = currentLine[4..];
                currentNode.Directories[dirName] = new TreeNode(dirName, currentNode);
            }
            else if (char.IsDigit(currentLine[0]))
            {
                var lineParts = currentLine.Split(" ");
                var size = int.Parse(lineParts[0]);
                var name = lineParts[1];
                currentNode.Size += size;
                currentNode.Files[name] = new TreeNode(name, currentNode, size);
                var ancestor = currentNode.Parent;
                while (ancestor is not null)
                {
                    ancestor.Size += size;
                    ancestor = ancestor.Parent;
                }
            }
            else if (currentLine == "$ cd /")
            {
                currentNode = root;
            }
            else if (currentLine == "$ cd ..")
            {
                currentNode = currentNode.Parent;
            }
            else
            {
                var nextNodeName = currentLine[5..];
                currentNode = currentNode.Directories[nextNodeName];
            }
        }

        return root;
    }

    private class TreeNode
    {
        public string Name { get; }
        public Dictionary<string, TreeNode> Directories { get; }
        public Dictionary<string, TreeNode> Files { get; }
        public TreeNode? Parent { get; }
        public int Size { get; set; }

        public TreeNode(string name, TreeNode? parent = null, int size = 0)
        {
            Name = name;
            Directories = new Dictionary<string, TreeNode>();
            Files = new Dictionary<string, TreeNode>();
            Parent = parent;
            Size = size;
        }
    }
}