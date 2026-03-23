namespace _05_graph;

class Graph<T>
{
    private readonly List<List<T>> adjacencyList = new();
    private readonly List<T> content = new();

    public void AddNode(T node)
    {
        content.Add(node);
        adjacencyList.Add(new List<T>());
    }

    public void AddEdge(T from, T to)
    {
        int indexFrom = content.IndexOf(from);
        int indexTo = content.IndexOf(to);

        adjacencyList[indexFrom].Add(content[indexTo]);
        adjacencyList[indexTo].Add(content[indexFrom]);
    }

    public bool HasEdge(T from, T to)
    {
        int indexFrom = content.IndexOf(from);
        int indexTo = content.IndexOf(to);

        return adjacencyList[indexFrom].Contains(content[indexTo]);
    }

    public List<T> Neighbors(T whichNode)
    {
        int index = content.IndexOf(whichNode);
        return adjacencyList[index];
    }

    public void DFS(T startNode, Action<T> action)
    {
        var F = new List<T>();
        DFS(startNode, F, action);
    }

    private void DFS(T k, List<T> F, Action<T> action)
    {
        F.Add(k);
        action(k);

        foreach (T x in Neighbors(k))
            if (!F.Contains(x))
                DFS(x, F, action);
    }

    public void BFS(T startNode, Action<T> action)
    {
        var S = new Queue<T>();
        var F = new List<T>();

        S.Enqueue(startNode);
        F.Add(startNode);

        T k;

        while (S.Count != 0)
        {
            k = S.Dequeue();
            action(k);
            foreach (T x in Neighbors(k))
            {
                if (!F.Contains(x))
                {
                    S.Enqueue(x);
                    F.Add(x);
                }
            }
        }
    }
}
