using System.Collections;
using System.Net.WebSockets;

namespace _03_linked_list;

class ChainedList<T> //: IEnumerator, IEnumerable
{
    private ListItem? head;
    private ListItem? iteratorPointer;
    public int Count { get; private set; }

    class ListItem
    {
        public T? content;
        public ListItem? next;
    }

    public T this[int i]
    {
        get { return SearchAndUpdate(i); }
        set { SearchAndUpdate(i, value); }
    }

    public static ChainedList<T> operator +(ChainedList<T> list, T newValue)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        list.InsertToBack(newValue);
        return list;
    }

    private T SearchAndUpdate(int index, T? newValue = default)
    {
        var p = this.head;
        int count = 0;
        while (p != null && count < index)
        {
            p = p.next;
            count++;
        }
        if (p != null && count == index)
        {
            if (newValue != null) p.content = newValue;
            return p.content;
        }
        else throw new IndexOutOfRangeException("Error, index was outside...");
    }

    public int SearchByContent(T content)
    {
        var p = head;
        int counter = 0;
        while (p != null && !p.content.Equals(content))
        {
            p = p.next; counter++;
        }
        return (p == null) ? -1 : counter;
    }

    public void InsertToFront(T newContent)
    {
        var newItem = new ListItem();
        newItem.content = newContent;
        newItem.next = this.head;
        this.head = newItem;
        this.Count++;
    }

    public void InsertToBack(T newContent)
    {
        var newItem = new ListItem();
        newItem.content = newContent;
        if (this.head == null)
        {
            this.head = newItem;
        }
        else
        {
            var p = this.head;
            while (p.next != null)
            {
                p = p.next;
            }
            p.next = newItem;
        }
    }

    public void InsertToPlace(T newContent, int index)
    {
        var newItem = new ListItem();
        newItem.content = newContent;

        if (this.head == null || index == 0)
        {
            newItem.next = this.head;
            this.head = newItem;
        }
        else
        {
            var p = this.head;
            int i = 1;
            while (p.next != null && i < index)
            {
                p = p.next;
                i++;
            }
            newItem.next = p.next;
            p.next = newItem;
        }
    }

    public void Clear()
    {
        this.head = null;
        this.Count = 0;
        // while (this.head != null)
        // {
        //     var p = this.head;
        //     this.head = this.head.next;
        //     p = default;
        //     p = null;
        //     GC.Collect();
        // }
    }

    public void Traverse(Action<T?> actionToInvoke)
    {
        var p = this.head; // ListItem? p = this.head;
        while (p != null)
        {
            actionToInvoke(p.content); // korábban cw...
            p = p.next;
        }
    }

    #region iterator methods
    // public object Current
    // {
    //     get
    //     {
    //         if (iteratorPointer == null) throw new InvalidOperationException();
    //         return this.iteratorPointer.content;
    //     }
    // }
    // public IEnumerator GetEnumerator()
    // {
    //     return this;
    // }

    // public bool MoveNext()
    // {
    //     if (iteratorPointer == null) // first call
    //     {
    //         iteratorPointer = this.head;
    //         return true;
    //     }
    //     else if(iteratorPointer.next != null) // n'th call
    //     {
    //         iteratorPointer = iteratorPointer.next;
    //         return true;
    //     }
    //     else // last call
    //     {
    //         this.Reset();
    //         return false;
    //     }
    // }

    // public void Reset()
    // {
    //     this.iteratorPointer = default;
    // }
    #endregion
    // rossz taktika --> jobb helyette külön counter-t használni
    // public int Count()
    // {
    //     int count = 0;
    //     var p = this.head;
    //     while (p != null)
    //     {
    //         p = p.next;
    //         count++;
    //     }
    //     return count;
    // }
}

class Program
{
    static void Main(string[] args)
    {
        var clist = new ChainedList<string>();
        clist.InsertToFront("alma");
        clist.InsertToFront("körte");
        clist.InsertToFront("szilva");

        clist.Traverse((x) => Console.WriteLine(" -> " + x));
        clist.Traverse(Process);
        clist.Traverse(x =>
        {
            if (x!.Contains('a'))
            {
                Console.WriteLine("A betű van benne: " + x);
            }
        });

        Console.WriteLine("--------------------------");

        clist.InsertToBack("utolsó előtti elem");
        clist.InsertToBack("utolsó elem");
        clist.Traverse(Process);

        Console.WriteLine("--------------------------");

        clist.InsertToPlace("új elem", 10);
        clist.InsertToPlace("első új elem", 0);
        clist.Traverse(Process);

        Console.WriteLine("--------------------------");

        Console.WriteLine(clist[0]);
        clist[3] = "ÚJ ÉRTÉK";
        Console.WriteLine(clist[3]);
        Console.WriteLine("Process:");
        clist.Traverse(Process);

        Console.WriteLine("--------------------------");

        clist += "plusz egyenlős új elem 1";
        clist += "plusz egyenlős új elem 2";
        clist.Traverse(Process);

        Console.WriteLine("--------------------------");

        foreach (var item in clist)
        {
            Console.WriteLine(item);
        }
    }

    static void Process(string? param)
    {
        Console.WriteLine(" ~> " + param);
    }
}
