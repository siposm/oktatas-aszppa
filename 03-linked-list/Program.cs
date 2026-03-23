namespace _03_linked_list;

class Program
{
    static void Main(string[] args)
    {
        var clist = new ChainedList<string>();
        clist.InsertToFront("alma");
        clist.InsertToFront("körte");
        clist.InsertToFront("szilva");

        clist.Traverse((x) => Console.WriteLine(" -> " + x));
        clist.Traverse(Process);
        clist.Traverse(x =>
        {
            if (x!.Contains('a'))
            {
                Console.WriteLine("A betű van benne: " + x);
            }
        });

        Console.WriteLine("--------------------------");

        clist.InsertToBack("utolsó előtti elem");
        clist.InsertToBack("utolsó elem");
        clist.Traverse(Process);

        Console.WriteLine("--------------------------");

        clist.InsertToPlace("új elem", 10);
        clist.InsertToPlace("első új elem", 0);
        clist.Traverse(Process);

        Console.WriteLine("--------------------------");

        Console.WriteLine(clist[0]);
        clist[3] = "ÚJ ÉRTÉK";
        Console.WriteLine(clist[3]);
        Console.WriteLine("Process:");
        clist.Traverse(Process);

        Console.WriteLine("--------------------------");

        clist += "plusz egyenlős új elem 1";
        clist += "plusz egyenlős új elem 2";
        clist.Traverse(Process);

        Console.WriteLine("--------------------------");

        Console.WriteLine("\nBejárás foreach:");
        foreach (var item in clist)
            Console.WriteLine(item);

        Console.WriteLine("\nBejárás for:");
        for (int i = 0; i < clist.Count; i++)
            Console.WriteLine(clist[i]);
    }

    static void Process(string? param)
    {
        Console.WriteLine(" ~> " + param);
    }
}
