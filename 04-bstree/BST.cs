namespace _04_bstree;

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
    public void Traverse(TraversalTypes type, Action<K, T> action)
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

    private void PreOrder(TreeItem? p, Action<K, T> action)
    {
        if (p != null)
        {
            action(p.key, p.content);
            PreOrder(p.left, action!);
            PreOrder(p.right, action!);
        }
    }

    private void InOrder(TreeItem? p, Action<K, T> action)
    {
        if (p != null)
        {
            InOrder(p.left, action!);
            action(p.key, p.content);
            InOrder(p.right, action!);
        }
    }

    private void PostOrder(TreeItem? p, Action<K, T> action)
    {
        if (p != null)
        {
            PostOrder(p.left, action!);
            PostOrder(p.right, action!);
            action(p.key, p.content);
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

    private void DeleteWithTwoChildren(TreeItem e, ref TreeItem? r)
    {
        // e = target csúcs amit törölni / felülírni akarunk
        if (r == null) return;

        if (r.right != null) DeleteWithTwoChildren(e, ref r.right);
        else
        {
            e.key = r.key;
            e.content = r.content;
            r = r.left;
        }
    }
    #endregion
}
