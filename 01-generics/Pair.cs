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
