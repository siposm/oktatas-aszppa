namespace _05_graph;

class User
{
    public string Name { get; set; } = "_anonymous_";

    public override string ToString()
    {
        return this.Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not User other)
            return false;

        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
