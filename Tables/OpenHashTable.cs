using System.Collections;
using System.Numerics;

///////////////////////////////////////////////////////////////////////////////

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

public class OpenHashTable<T>(int radix = 29, int capacity = 500) : ITable<T>
where T : IComparable<T>
{
    //-----------------------------------------------------------------------//

    /*

    */

    //-----------------------------------------------------------------------//

    private readonly T?[] inner = new T?[capacity];
    private int size = 0;
    private readonly int radix = radix;

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
        return Hasher.HornerRadix(value.ToString(), radix, inner.Length);
    }

    public void Add(T value)
    {
        int hash, index;

        hash = index = HashValue(value);

        while (inner[index] != null)
        {
            index++;

            if (index == hash)
                throw new Exception("Table is full!");

            if (index >= inner.Length)
                index = 0;

        }

        inner[index] = value;

        size++;

    }

    public void Remove(T value)
    {
        int hash, index;

        hash = index = HashValue(value);

        while (!value.Equals(inner[index]))
        {
            index++;

            if (index == hash)
                throw new Exception("Not found");

            if (index >= inner.Length)
                index = 0;

        }

        inner[index] = default;

        size--;

    }

    //-----------------------------------------------------------------------//

    public bool Contains(T value)
    {
        int hash, index;

        hash = index = HashValue(value);

        while (!value.Equals(inner[index]))
        {
            index++;

            if (index == hash)
                return false;

            if (index >= inner.Length)
                index = 0;

        }

        return true;
    }

    //-----------------------------------------------------------------------//

    public bool IsEmpty()
    {
        return size == 0;
    }
}

///////////////////////////////////////////////////////////////////////////////
