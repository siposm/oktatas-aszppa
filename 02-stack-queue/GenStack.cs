namespace _02_stack_queue;

class GenStack<T>
{
    T[] items;
    int itemCounter;

    public GenStack(int size = 4)
    {
        items = new T[size];
        itemCounter = 0;
    }

    public void Push(T item)
    {
        if (itemCounter == items.Length)
            throw new StackOverflowException("Stack is full...");

        items[itemCounter++] = item;
    }

    public T Pop()
    {
        return items[--itemCounter];
    }

    public T Top()
    {
        return items[itemCounter - 1];
    }
}
