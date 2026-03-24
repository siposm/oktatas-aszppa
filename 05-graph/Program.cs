namespace _05_graph;

class Program
{
    static void Main(string[] args)
    {
        var g = new Graph<User>();

        var joseph = new User() { Name = "Joseph" };
        var stew   = new User() { Name = "Stew"   };
        var marge  = new User() { Name = "Marge"  };
        var gerald = new User() { Name = "Gerald" };
        var zack   = new User() { Name = "Zack"   };
        var peter  = new User() { Name = "Peter"  };
        var janet  = new User() { Name = "Janet"  };

        g.AddNode(joseph);
        g.AddNode(stew);
        g.AddNode(marge);
        g.AddNode(gerald);
        g.AddNode(zack);
        g.AddNode(peter);
        g.AddNode(janet);

        //      Marge
        //     /     \
        //  Stew ---- Joseph
        //             |   \
        //             |    \
        //             |    Gerald
        //             |    /
        //             |   /
        //             Zack
        //            /
        //         Peter
        //           |
        //         Janet

        g.AddEdge(joseph, stew);
        g.AddEdge(joseph, marge);
        g.AddEdge(joseph, zack);
        g.AddEdge(joseph, gerald);

        g.AddEdge(marge, stew);
        g.AddEdge(gerald, zack);

        g.AddEdge(peter, zack);
        g.AddEdge(peter, janet);

        Console.WriteLine("\n>> DFS");
        Console.WriteLine("▀▀▀▀▀▀▀▀\n");
        g.DFS(janet, Console.WriteLine);

        Console.WriteLine("\n>> BFS");
        Console.WriteLine("▀▀▀▀▀▀▀▀\n");
        g.BFS(janet, Console.WriteLine);
    }
}
