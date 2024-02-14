using System.Collections;

///////////////////////////////////////////////////////////////////////////////

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

public class ClosedHashTable<T> : ITable<T>
where T : IComparable<T>
{

    //-----------------------------------------------------------------------//

    /*

    */

    //-----------------------------------------------------------------------//

    private readonly LinkedList<T>[] inner;
    private int size = 0;
    private readonly int radix;

    public ClosedHashTable(int radix = 29, int capacity = 500)
    {
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

    private int HashValue(T value)
    {
        return Hasher.HornerRadix(value.ToString(), radix, inner.Length - 1);
    }

    public void Add(T value)
    {
        int hash = HashValue(value);

        inner[hash].Push(value);

        size++;

    }

    public void Remove(T value)
    {

        int hash = HashValue(value);

        inner[hash].Delete((uint)inner[hash].Search(value));

        size--;

    }

    //-----------------------------------------------------------------------//

    public bool Contains(T value)
    {
        int hash = HashValue(value);

        return inner[hash].Search(value) != -1;
    }

    //-----------------------------------------------------------------------//

    public bool IsEmpty()
    {
        return size == 0;
    }
}

///////////////////////////////////////////////////////////////////////////////
