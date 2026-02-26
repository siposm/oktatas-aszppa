namespace _02_stack_queue;

class StringStack
{
    string[] items;
    int itemCounter;
    public StringStack(int size)
    {
        items = new string[size];
        itemCounter = 0;
    }
    public void Push(string item)
    {
        if (itemCounter == items.Length)
            throw new StackOverflowException("Stack is full...");
        items[itemCounter++] = item;
    }
    public string Pop()
    {
        return items[--itemCounter];
    }
    public string Top()
    {
        return items[itemCounter - 1];
    }
}
