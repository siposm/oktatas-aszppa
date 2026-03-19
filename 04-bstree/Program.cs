namespace _04_bstree;

enum TraversalTypes
{
    PreOrder,
    InOrder,
    PostOrder,
}

class BST<K, T>
    where K : IComparable
{
    private TreeItem? root = null;

    class TreeItem
    {
        public K key;
        public T content;
        public TreeItem? left;
        public TreeItem? right;

        public TreeItem(K key, T content)
        {
            this.key = key;
            this.content = content;
            this.left = null;
            this.right = null;
        }

        public override string ToString()
        {
            return $"{key?.ToString()} - {content?.ToString()}";
        }
    }

    #region insertion
    public void Insert(K key, T content)
    {
        Insert(ref this.root!, key, content);
    }

    private void Insert(ref TreeItem p, K key, T content)
    {
        if (p == null)
            p = new TreeItem(key, content);
        else if (p.key.CompareTo(key) < 0)
            Insert(ref p.right, key, content);
        else if (p.key.CompareTo(key) > 0)
            Insert(ref p.left, key, content);
        else
            throw new Exception("Item with the given key already exists.");
    }
    #endregion

    #region  traversal
    public void Traverse(TraversalTypes type, Action<string> action)
    {
        if (this.root == null)
            return;

        if (type == TraversalTypes.PreOrder)
            PreOrder(this.root, action);
        else if (type == TraversalTypes.InOrder)
            InOrder(this.root, action);
        else if (type == TraversalTypes.PostOrder)
            PostOrder(this.root, action);
    }

    private void PreOrder(TreeItem? p, Action<string> action)
    {
        if (p != null)
        {
            action(p.ToString());
            PreOrder(p.left, action!);
            PreOrder(p.right, action!);
        }
    }

    private void InOrder(TreeItem? p, Action<string> action)
    {
        if (p != null)
        {
            InOrder(p.left, action!);
            action(p.ToString());
            InOrder(p.right, action!);
        }
    }

    private void PostOrder(TreeItem? p, Action<string> action)
    {
        if (p != null)
        {
            PostOrder(p.left, action!);
            PostOrder(p.right, action!);
            action(p.ToString());
        }
    }
    #endregion

    #region deletion
    public void Delete(K key)
    {
        Delete(ref this.root, key);
    }

    private void Delete(ref TreeItem? p, K key)
    {
        if (p == null) throw new InvalidOperationException("Item with this key does not exist.");

        int cmp = p.key.CompareTo(key);

        if (cmp > 0) Delete(ref p.left, key);
        else if (cmp < 0) Delete(ref p.right, key);
        else
        {
            // megtaláltuk a törlendő csúcsot
            if (p.left == null) p = p.right;
            else if (p.right == null) p = p.left;
            else DeleteWithTwoChildren(p, ref p.left);
        }
    }

    private void DeleteWithTwoChildren(TreeItem target, ref TreeItem? r)
    {
        if (r == null) return;

        if (r.right != null) DeleteWithTwoChildren(target, ref r.right);
        else
        {
            target.key = r.key;
            target.content = r.content;
            r = r.left;
        }
    }
    #endregion
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello BSTree!\n----------------\n");
        var bst = new BST<int, string>();
        bst.Insert(20, "alma");
        bst.Insert(10, "szilva");
        bst.Insert(30, "körte");
        bst.Insert(22, "barack");
        bst.Insert(31, "narancs");
        bst.Insert(9, "eper");

        bst.Delete(30);

        bst.Traverse(TraversalTypes.InOrder, s => Console.WriteLine(" > " + s));
    }
}
