
using System.Numerics;

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

public class BST<T, U> : IMap<T, U>
where T : IComparable<T>
where U : IComparable<U>
{

    //-----------------------------------------------------------------------//

    /*
    --- Structure (standard binary search tree)

    |
    | `root` - the root tree node
    | `size` - the number of items in the map
    |

    */

    //-----------------------------------------------------------------------//

    class Node<K, V>(K key, V value, Node<K, V>? parent)
    {

        /*
        --- Structure

        |
        | `key` - the key to access data
        | `value` - the associated data for the key
        |
        | `parent` - the parent of the current node
        |
        | `left` - the node tree with a smaller key
        | `right` - the node tree with a larger key
        |
        
        Based on [4]
        */

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

    /// Returns the Node with the given key, if it exists.
    /// Uses in-order search.
    private Node<T, U>? GetNode(T key, Node<T, U>? cursor)
    {
        // We've reached a dead end, let's let the consumer know.
        if (cursor == null)
        {
            return null;
        }

        // check if we've found the target
        if (cursor.key.Equals(key))
            return cursor;

        // check if we're smaller than target
        else if (cursor.key.CompareTo(key) > 0)
            return GetNode(key, cursor.left);

        // otherwise
        else
            return GetNode(key, cursor.right);
    }

    /// Helper function, returns smallest (most leftward leaf) node in the
    /// provided tree.
    private Node<T, U>? GetMinNode(Node<T, U>? node)
    {
        // Based off [4]

        Node<T, U>? cursor = node;

        while (cursor != null && cursor.left != null)
            cursor = cursor.left;

        return cursor;
    }

    //-----------------------------------------------------------------------//

    /// Returns the value associated with the provided `key`, if it exists.
    public U? Get(T key)
    {
        // Get node for the key
        Node<T, U>? node = GetNode(key, root);
        // Check for valid result
        if (node != null)
            return node.value;
        else
            return default; // should be eq. to null
    }

    //-----------------------------------------------------------------------//

    /// Set the value associated with given `key` to `value`.
    public void Set(T key, U value)
    {
        // increment size tracker
        size++;
        // we'll use a modified version of [4]'s recursive method.
        // we'll start searching at the tree's root.
        SetRec(root, key, value, null);
    }

    private void SetRec(Node<T, U>? cursor, T key, U value, Node<T, U>? parent)
    {
        // check if we're the root and are still uninitialized
        if (cursor == null && parent == null)
            // create new root
            root = new(key, value, null);

        // check if we are uninitialized and smaller than the parent
        else if (cursor == null && parent.key.CompareTo(key) > 0)
            // initialize ourselves on the parent
            parent.left = new(key, value, parent);

        // check if we are uninitialized and bigger than the parent
        else if (cursor == null)
            // initialize ourselves on the parent
            parent.right = new(key, value, parent);

        // check if we're on the initialized target node
        else if (cursor.key.Equals(key))
            // just update the value
            cursor.value = value;

        // we haven't found our target position yet, we need to keep looking

        // check if we're looking for a smaller node
        else if (cursor.key.CompareTo(key) > 0)
            // recursively continue on the left branch
            SetRec(cursor.left, key, value, cursor);

        // we're looking for a bigger node
        else
            // recursively continue on the right branch 
            SetRec(cursor.right, key, value, cursor);
    }

    //-----------------------------------------------------------------------//

    /// Deletes the value associated with `key`.
    /// Returns the previous value.
    public U? Delete(T key)
    {
        // get the target node
        Node<T, U>? node = GetNode(key, root);

        // check if our key is valid
        if (node == null)
            // if not, just return null (we can't delete a non-existent entry)
            return default;


        // decrement size record
        size--;

        // we'll first find our replacement, then worry about parents
        // to start with, let's assume we have no replacement
        Node<T, U>? replacement = null;

        // check if we are a leaf (have no children)
        if (node.left == null && node.right == null)
            // we have no replacement
            replacement = null;

        // check if we only have a right child
        else if (node.left == null && node.right != null)
            // our right child is our replacement
            replacement = node.right;

        // check if we only have a left child
        else if (node.left != null && node.right == null)
            // our left child is our replacement
            replacement = node.left;

        // we have two children
        else
            // based [4]'s spec, we need to find our successor
            // our successor is always the smallest of the elements
            // bigger (rightward) of us, so GetMin on the right branch.
            replacement = GetMinNode(node.right);

        // check if we have no parent (if we're root)
        if (node.parent == null)
            // update root
            root = replacement;

        // check if we're our parent's left child
        else if (node == node.parent.left)
            // update parent's left child slot
            node.parent.left = replacement;

        // we must be our parent's right child
        else
            // update parent's right child slot
            node.parent.right = replacement;

        // return the deleted node's value
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

    /// Returns the key for the given `value`
    ///
    /// Searches in pre-order (leftward depth first)
    public T? PreOrderSearch(U value)
    {
        // start at the root
        return PreOrderSearchRec(value, root);
    }

    private T? PreOrderSearchRec(U value, Node<T, U>? cursor)
    {
        // check if we're still a valid node
        if (cursor == null)
            // if not, just return null
            return default;

        // check if we're the target node
        else if (cursor.value.Equals(value))
            // return the node's key
            return cursor.key;

        // we need to keep looking, recursively search the left branch
        T? leftRec = PreOrderSearchRec(value, cursor.left);

        // check if we found the result in the left branch
        if (leftRec != null)
            // return the result
            return leftRec;

        // target isn't in the left branch, return the result of recursively
        // searching the right branch.
        else
            return PreOrderSearchRec(value, cursor.right);

    }

    //.......................................................................//

    /// Returns the key for the given `value`
    ///
    /// Searches in post-order (rightward depth first)
    public T? PostOrderSearch(U value)
    {
        // start at root
        return PostOrderSearchRec(value, root);
    }

    private T? PostOrderSearchRec(U value, Node<T, U>? cursor)
    {
        // check if we're still a valid node
        if (cursor == null)
            // if not, just return null
            return default;

        // check if we're the target node
        else if (cursor.value.Equals(value))
            // return the node's key
            return cursor.key;

        // we need to keep looking, recursively search the right branch
        T? rightRec = PostOrderSearchRec(value, cursor.right);

        // check if we found the result in the right branch
        if (rightRec != null)
            // return the result
            return rightRec;

        // target isn't in the right branch, return the result of recursively
        // searching the left branch.
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
