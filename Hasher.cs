namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

static class Hasher
{
    /// Returns a hash of the given `input`.
    /// 
    /// - Inputs
    ///     - `String input`
    ///         - The input string to hash.
    ///     - `int radix`
    ///         - The radix base used for hashing.
    ///         - Generally the size of the alphabet used in `input`.
    ///         - Ideally should be a prime number.
    ///     - `int capacity`
    ///         - The largest acceptable hash to return.
    ///
    /// - `int` Output
    ///     - The hash of the given `input`
    public static int HornerRadix(String input, int radix, int capacity)
    {
        /*

        We're going to use Horner's method to efficiently run Radix conversion
        hashing* on `input`.

        Horner's method is described here [2].
        Radix conversion hashing is described here [3].

        This is what our textbook [4] described on page 93.

        [5] and [6] both offer additional guidance.

        * We're switching the order of radix exponents. Wikipedia defines it
        as x_ia^(k-i), where x is a list of variables and k is the length of
        the list. Instead, we calculate x_ia^i.

        */

        double result = 0;

        char[] tokens = [.. input];

        // for each token
        for (int i = 0; i < tokens.Length; i++)
        {
            // multiply the current hash by the radix base and add the utf-16
            // value of the current token.
            result = result * radix + tokens[i];
        }

        // wrap result to fit the provided size limit
        return (int)(result % capacity);

    }
}

///////////////////////////////////////////////////////////////////////////////
