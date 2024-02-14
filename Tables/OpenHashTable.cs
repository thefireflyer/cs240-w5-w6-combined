using System.Collections;
using System.Numerics;

///////////////////////////////////////////////////////////////////////////////

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

public class OpenHashTable<T>(int radix = 29, int capacity = 500) : ITable<T>
where T : IComparable<T>
{
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

    /// Helper function to find hash
    private int HashValue(T value)
    {
        return Hasher.HornerRadix(value.ToString(), radix, inner.Length);
    }

    /// Adds the `value` to the table.
    ///
    /// Side note, this is a table so duplicates are allowed.
    public void Add(T value)
    {
        // we're using open addressing so we'll need both a dynamic index
        // and our original hash.
        int hash, index;

        hash = index = HashValue(value);

        // while our spot is already taken, keep looking
        while (inner[index] != null)
        {
            // move onto the next spot
            index++;

            if (index == hash)
                // we've come full circle and haven't found a single spot
                // we could resize the hash table, but for now let's just
                // throw an exception.
                throw new Exception("Table is full!");

            // wrap around to the start of the inner array if we're at the end
            if (index >= inner.Length)
                index = 0;

        }

        // claim the slot
        inner[index] = value;

        // increment our size
        size++;

    }

    /// Removes one instance of the `value` from the table.    
    public void Remove(T value)
    {
        // looking for the slot is mostly the same as in the add function
        int hash, index;

        hash = index = HashValue(value);

        // here we're checking if we've found the right entry, rather than
        // if the spot is already taken
        // we're actually going to double check the slot *is* taken because
        // that would mean we have a non-existent target.
        while (inner[index] != null && !value.Equals(inner[index]))
        {
            index++;

            if (index == hash)
                throw new Exception("Not found");

            if (index >= inner.Length)
                index = 0;

        }

        // double check we actually found an existent target
        if (inner[index] != null)
            // decrement size
            size--;

        // set the slot to empty (null)
        inner[index] = default;


    }

    //-----------------------------------------------------------------------//

    public bool Contains(T value)
    {
        // essentially the same as in remove and add
        int hash, index;

        hash = index = HashValue(value);

        while (!value.Equals(inner[index]))
        {
            index++;

            if (index == hash)
                // let the consumer know `value` isn't here
                return false;

            if (index >= inner.Length)
                index = 0;

        }

        // we got past the while loop so we must have found `value`, let the
        // consumer know.
        return true;
    }

    //-----------------------------------------------------------------------//

    public bool IsEmpty()
    {
        return size == 0;
    }
}

///////////////////////////////////////////////////////////////////////////////
