namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

/// Common map interface
public interface IMap<T, U>
where T : IComparable<T>
where U : IComparable<U>
{

    public U? Get(T key);
    public void Set(T key, U value);
    public U? Delete(T key);

    //-----------------------------------------------------------------------//

    public bool ContainsKey(T key);

    //-----------------------------------------------------------------------//

    public int Size();

    public bool IsEmpty();

}

///////////////////////////////////////////////////////////////////////////////
