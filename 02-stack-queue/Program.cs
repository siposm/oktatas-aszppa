namespace _02_stack_queue;

class KeyValuePair<K, V>
{
    public K Key { get; set; }
    public V Value { get; set; }
    public KeyValuePair(K key, V value)
    {
        Key = key;
        Value = value;
    }
    public override string ToString()
    {
        return $"{Key} => {Value}";
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
    }
}
