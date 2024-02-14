
using System.Numerics;

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

public class BST<T, U> : IMap<T, U>
where T : IComparable<T>
where U : IComparable<U>
{

    //-----------------------------------------------------------------------//

    /*

    */

    //-----------------------------------------------------------------------//

    class Node<K, V>(K key, V value, Node<K, V>? parent)
    {
        public K key = key;
        public V value = value;

        public Node<K, V>? parent = parent;
        public Node<K, V>? left;
        public Node<K, V>? right;
    }

    //-----------------------------------------------------------------------//

    private int size = 0;
    private Node<T, U>? root;

    //-----------------------------------------------------------------------//

    private Node<T, U>? GetNode(T key, Node<T, U>? cursor)
    {
        if (cursor == null)
        {
            return null;
        }

        if (cursor.key.Equals(key))
            return cursor;
        else if (cursor.key.CompareTo(key) > 0)
            return GetNode(key, cursor.left);
        else
            return GetNode(key, cursor.right);
    }

    private Node<T, U>? GetMinNode(Node<T, U>? node)
    {
        Node<T, U>? cursor = node;

        while (cursor != null && cursor.left != null)
            cursor = cursor.left;

        return cursor;
    }

    //-----------------------------------------------------------------------//

    public U? Get(T key)
    {
        Node<T, U>? node = GetNode(key, root);
        if (node != null)
            return node.value;
        else
            return default;
    }

    //-----------------------------------------------------------------------//

    public void Set(T key, U value)
    {
        size++;
        SetRec(root, key, value, null);
    }

    private void SetRec(Node<T, U>? cursor, T key, U value, Node<T, U>? parent)
    {
        if (cursor == null && parent == null)
            root = new(key, value, null);
        else if (cursor == null && parent.key.CompareTo(key) > 0)
            parent.left = new(key, value, parent);
        else if (cursor == null)
            parent.right = new(key, value, parent);
        else if (cursor.key.Equals(key))
            cursor.value = value;
        else if (cursor.key.CompareTo(key) > 0)
            SetRec(cursor.left, key, value, cursor);
        else
            SetRec(cursor.right, key, value, cursor);
    }

    //-----------------------------------------------------------------------//

    public U? Delete(T key)
    {
        Node<T, U>? node = GetNode(key, root);

        if (node == null)
            return default;

        size--;

        Node<T, U>? replacement = null;

        if (node.left == null && node.right == null)
            replacement = null;
        else if (node.left == null && node.right != null)
            replacement = node.right;
        else if (node.left != null && node.right == null)
            replacement = node.left;
        else
            replacement = GetMinNode(node.right);

        if (node.parent == null)
            root = replacement;
        else if (node == node.parent.left)
            node.parent.left = replacement;
        else
            node.parent.right = replacement;

        return node.value;
    }

    //-----------------------------------------------------------------------//

    public bool ContainsKey(T key)
    {
        return GetNode(key, root) != null;
    }

    //-----------------------------------------------------------------------//

    public bool IsEmpty()
    {
        return size == 0;
    }

    public int Size()
    {
        return size;
    }

    //-----------------------------------------------------------------------//

    public T? PreOrderSearch(U value)
    {
        return PreOrderSearchRec(value, root);
    }

    private T? PreOrderSearchRec(U value, Node<T, U>? cursor)
    {
        if (cursor == null)
            return default;

        else if (cursor.value.Equals(value))
            return cursor.key;

        T? leftRec = PreOrderSearchRec(value, cursor.left);
        if (leftRec != null)
            return leftRec;
        else
            return PreOrderSearchRec(value, cursor.right);

    }

    //.......................................................................//

    public T? PostOrderSearch(U value)
    {
        return PostOrderSearchRec(value, root);
    }

    private T? PostOrderSearchRec(U value, Node<T, U>? cursor)
    {
        if (cursor == null)
            return default;

        else if (cursor.value.Equals(value))
            return cursor.key;

        T? rightRec = PostOrderSearchRec(value, cursor.right);
        if (rightRec != null)
            return rightRec;
        else
            return PostOrderSearchRec(value, cursor.left);

    }
    //.......................................................................//

    /*
    --- In-order search

    Our tree is organized based on keys, this means the value of a node is not
    related to its position in the tree; so we don't know its successor.
    This means there isn't really a logical in-order form of value search.

    Instead, we can see in-order search used for our key-based searches.

    */

}

///////////////////////////////////////////////////////////////////////////////
