public class Tools
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public void Log<T_type>(T_type param)
    {
        Console.WriteLine(param);
    }

    public T FindMax<T>(T paramA, T paramB)
        where T : IComparable
    {
        return paramA.CompareTo(paramB) > 0 ? paramA : paramB;
    }

    public bool CompareByValue<T, K>(T paramA, K paramB)
    {
        return paramA.Equals(paramB);
    }

    public bool CompareByType<T, K>()
    {
        return typeof(T).Equals(typeof(K));
    }
}

public class Box<T>
{
    public T Value { get; set; }

    public Box(T value)
    {
        this.Value = value;
    }

    public Box() { }

    public override string ToString()
    {
        return $"Box value: {this.Value}";
    }
}

public class AnotherBox : Box<string> { }

public class MisteryBox<T, K> : Box<T>
{
    public K PlusValue { get; set; }

    public MisteryBox(T paramA, K paramB)
        : base(paramA)
    {
        this.PlusValue = paramB;
    }
}

public class Pair<K, V>
    where K : IComparable
    where V : class // referencia típus
    // where V : struct // érték típus
{
    public K Key { get; set; }
    public V Value { get; set; }

    public Pair(K key, V value)
    {
        this.Key = key;
        this.Value = value;
    }
    public Pair(){}
}

public class ObjectFactory<T> where T : new()
{
    public List<T> Create(int number)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < number; i++)
        {
            list.Add(new T());
        }
        return list;
    }
}

public class User
{
    public string Name{get;set;}
}

internal class Program
{
    private static void Main(string[] args)
    {
        var tools = new Tools();
        tools.Log<string>("alma");
        tools.Log<int>(123);

        var pair1 = new Pair<string, User>();
        // var pair2 = new Pair<string, int>();
        var pair3 = new Pair<int, Box<User>>();

        var of = new ObjectFactory<User>();
        var users = of.Create(4);
        ;
    }
}
