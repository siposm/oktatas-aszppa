public class MisteryBox<T, K> : Box<T>
{
    public K PlusValue { get; set; }

    public MisteryBox(T paramA, K paramB)
        : base(paramA)
    {
        this.PlusValue = paramB;
    }
}
