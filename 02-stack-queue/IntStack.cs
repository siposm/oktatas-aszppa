namespace _02_stack_queue;

class IntStack
{
    int[] items;
    int itemCounter;
    public IntStack(int size)
    {
        items = new int[size];
        itemCounter = 0;
    }
    public void Push(int item)
    {
        if (itemCounter == items.Length)
            throw new StackOverflowException("Stack is full...");
        items[itemCounter++] = item;
    }
    public int Pop()
    {
        return items[--itemCounter];
    }
    public int Top()
    {
        return items[itemCounter - 1];
    }
}
