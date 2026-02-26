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
