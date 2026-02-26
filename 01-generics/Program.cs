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
