namespace _05_graph;

class Program
{
    static void Main(string[] args)
    {
        var g = new Graph<User>();

        var Joseph = new User() { Name = "Joseph" };
        var Stew   = new User() { Name = "Stew"   };
        var Marge  = new User() { Name = "Marge"  };
        var Gerald = new User() { Name = "Gerald" };
        var Zack   = new User() { Name = "Zack"   };
        var Peter  = new User() { Name = "Peter"  };
        var Janet  = new User() { Name = "Janet"  };

        g.AddNode(Joseph);
        g.AddNode(Stew);
        g.AddNode(Marge);
        g.AddNode(Gerald);
        g.AddNode(Zack);
        g.AddNode(Peter);
        g.AddNode(Janet);

        //      Marge
        //     /     \
        //  Stew-----Joseph
        //             |  \
        //             |   \
        //             |    Gerald
        //             |   /
        //             |  /
        //            Zack
        //           /
        //        Peter
        //          |
        //        Janet

        g.AddEdge(Joseph, Stew);
        g.AddEdge(Joseph, Marge);
        g.AddEdge(Joseph, Zack);
        g.AddEdge(Joseph, Gerald);

        g.AddEdge(Marge, Stew);
        g.AddEdge(Gerald, Zack);

        g.AddEdge(Peter, Zack);
        g.AddEdge(Peter, Janet);

        Console.WriteLine("\n>> DFS\n");
        g.DFS(Janet, Console.WriteLine);

        Console.WriteLine("\n>> BFS\n");
        g.BFS(Janet, Console.WriteLine);
    }
}
