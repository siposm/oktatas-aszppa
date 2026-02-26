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
