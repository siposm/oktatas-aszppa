using System.Diagnostics;

namespace _02_stack_queue;

class GenQueue<T>
{
    private T[] items;
    public int Count { get; private set; }

    public GenQueue(int capacity = 4)
    {
        items = new T[capacity];
        Count = 0;
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }

    public void Enqueue(T item)
    {
        if (Count == items.Length)
            Grow(); // probléma van; verem esetén is

        items[Count++] = item;
    }

    public T Dequeue()
    {
        if (Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        T first = items[0];

        for (int i = 1; i < Count; i++)
            items[i - 1] = items[i]; // shiftelés

        items[--Count] = default!; // default érték beállítása / ref. felszabadítás

        return first;
    }

    public T Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        return items[0];
    }

    public void Clear()
    {
        for (int i = 0; i < Count; i++)
            items[i] = default!;

        Count = 0;
    }

    public void Grow()
    {
        int newSize = items.Length * 2;
        T[] newArr = new T[newSize];

        for (int i = 0; i < Count; i++)
            newArr[i] = items[i];

        this.items = newArr;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var ints = new IntStack(3);
        ints.Push(30);
        ints.Push(10);
        ints.Push(3);
        Console.WriteLine(ints.Top());
        Console.WriteLine(ints.Pop());

        var strs = new StringStack(3);
        strs.Push("string - 30");
        strs.Push("string - 10");
        strs.Push("string - 3");
        Console.WriteLine(strs.Top());
        Console.WriteLine(strs.Pop());

        var gs = new GenStack<User>(3);
        gs.Push(new User("string user 1"));
        gs.Push(new User("string user 2"));
        gs.Push(new User("string user 3"));
        Console.WriteLine(gs.Top());
        Console.WriteLine(gs.Pop());

        var kv1 = new KeyValuePair<string, User>("LDJ34S", new User("Laci"));
        var kv2 = new KeyValuePair<string, User>("ASD123", new User("Zsombi"));

        var gs2 = new GenStack<KeyValuePair<string, User>>(3);
        gs2.Push(kv1);
        gs2.Push(kv2);

        var qu = new GenQueue<string>();
        qu.Enqueue("alma");
        qu.Enqueue("körte");
        qu.Enqueue("szilva");
        qu.Enqueue("barack");
        qu.Enqueue("-x-x-x-");

        Console.WriteLine(qu.Peek());
        Console.WriteLine(qu.Dequeue());
        Console.WriteLine(qu.Peek());
    }
}
