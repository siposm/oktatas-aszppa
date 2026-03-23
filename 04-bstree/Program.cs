namespace _04_bstree;

class Program
{
    static void Main(string[] args)
    {
        var bst = new BST<int, string>();
        bst.Insert(30, "alma");
        bst.Insert(20, "körte");
        bst.Insert(40, "szilva");
        bst.Insert(35, "dinnye");

        Console.WriteLine("Törlés előtt:");
        bst.Traverse(
            TraversalTypes.InOrder,
            (key, value) => Console.WriteLine($"[{key}] - {value}")
        );

        Console.WriteLine("Törlés után:");
        bst.Delete(30);
        bst.Traverse(
            TraversalTypes.InOrder,
            (key, value) => Console.WriteLine($"[{key}] - {value}")
        );

        Console.WriteLine("PREORDER:");
        bst.Traverse(
            TraversalTypes.PreOrder,
            (key, value) => Console.WriteLine($"[{key}] - {value}")
        );

        Console.WriteLine("INORDER:");
        bst.Traverse(
            TraversalTypes.InOrder,
            (key, value) => Console.WriteLine($"[{key}] - {value}")
        );

        Console.WriteLine("POSTORDER:");
        bst.Traverse(
            TraversalTypes.PostOrder,
            (key, value) => Console.WriteLine($"[{key}] - {value}")
        );
    }
}
