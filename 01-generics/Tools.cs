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
