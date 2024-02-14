using System.Collections;

///////////////////////////////////////////////////////////////////////////////

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

public class ClosedHashTable<T> : ITable<T>
where T : IComparable<T>
{

    private readonly LinkedList<T>[] inner;
    private int size = 0;
    private readonly int radix;

    public ClosedHashTable(int radix = 29, int capacity = 500)
    {
        // we need to initialize our linked lists and properties
        inner = new LinkedList<T>[capacity];
        for (int i = 0; i < capacity; i++)
        {
            inner[i] = new LinkedList<T>();
        }

        this.radix = radix;
    }

    //-----------------------------------------------------------------------//

    public int Size()
    {
        return size;
    }

    public int Capacity()
    {
        return inner.Length;
    }

    //-----------------------------------------------------------------------//

    /// Helper function to find hash
    private int HashValue(T value)
    {
        return Hasher.HornerRadix(value.ToString(), radix, inner.Length - 1);
    }

    /// Adds the `value` to the table.
    ///
    /// Side note, this is a table so duplicates are allowed.
    public void Add(T value)
    {
        // get the hash of `value`
        int hash = HashValue(value);

        // push onto the back of the entry list
        inner[hash].Push(value);

        // increment size
        size++;

    }

    /// Removes one instance of the `value` from the table.    
    public void Remove(T value)
    {
        // get the hash of `value
        int hash = HashValue(value);

        // could be improved, but first search for the value, then delete it.
        inner[hash].Delete((uint)inner[hash].Search(value));

        // decrement size
        size--;

    }

    //-----------------------------------------------------------------------//

    public bool Contains(T value)
    {
        // get the hash
        int hash = HashValue(value);

        // search for `value` among our hash entries
        // if `value` isn't there, return false.
        return inner[hash].Search(value) != -1;
    }

    //-----------------------------------------------------------------------//

    public bool IsEmpty()
    {
        return size == 0;
    }
}

///////////////////////////////////////////////////////////////////////////////
