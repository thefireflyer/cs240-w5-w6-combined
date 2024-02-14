using System.Collections;
using NUnit.Framework;

///////////////////////////////////////////////////////////////////////////////

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

/*

`dotnet test` doesn't seem to be finding these tests on my computer.
I tried moving the actual test code elsewhere and it works fine so I think
there's some weird problem with my setup, or a really silly, well hidden, typo.

*/

[TestFixture(typeof(OpenHashTable<String>))]
[TestFixture(typeof(ClosedHashTable<String>))]
public class TestTable<TTable>
    where TTable : ITable<String>, new()
{

    [Test]
    public void TestBasics()
    {
        TTable table = new();

        Assert.That(table.IsEmpty());

        table.Add("a");

        Assert.Multiple(() =>
        {
            Assert.That(!table.IsEmpty());
            Assert.That(table.Contains("a"));
            Assert.That(!table.Contains("b"));
            Assert.That(!table.Contains("c"));
            Assert.That(table.Size(), Is.EqualTo(1));
        });

        table.Remove("a");

        Assert.Multiple(() =>
        {
            Assert.That(table.IsEmpty());
            Assert.That(!table.Contains("a"));
            Assert.That(table.Size(), Is.EqualTo(0));
        });

        table.Add("a");

        Assert.Multiple(() =>
        {
            Assert.That(!table.IsEmpty());
            Assert.That(table.Contains("a"));
            Assert.That(table.Size(), Is.EqualTo(1));
        });

        table.Add("b");

        Assert.Multiple(() =>
        {
            Assert.That(!table.IsEmpty());
            Assert.That(table.Contains("a"));
            Assert.That(table.Contains("b"));
            Assert.That(table.Size(), Is.EqualTo(2));
        });

        table.Add("c");

        Assert.Multiple(() =>
        {
            Assert.That(!table.IsEmpty());
            Assert.That(table.Contains("a"));
            Assert.That(table.Contains("b"));
            Assert.That(table.Contains("c"));
            Assert.That(table.Size(), Is.EqualTo(3));
        });

        table.Remove("a");

        Assert.Multiple(() =>
        {
            Assert.That(!table.IsEmpty());
            Assert.That(!table.Contains("a"));
            Assert.That(table.Contains("b"));
            Assert.That(table.Contains("c"));
            Assert.That(table.Size(), Is.EqualTo(2));
        });


        table.Remove("b");

        Assert.Multiple(() =>
        {
            Assert.That(!table.IsEmpty());
            Assert.That(!table.Contains("a"));
            Assert.That(!table.Contains("b"));
            Assert.That(table.Contains("c"));
            Assert.That(table.Size(), Is.EqualTo(1));
        });

        table.Add("c");

        Assert.Multiple(() =>
        {
            Assert.That(!table.IsEmpty());
            Assert.That(!table.Contains("a"));
            Assert.That(!table.Contains("b"));
            Assert.That(table.Contains("c"));
            Assert.That(table.Size(), Is.EqualTo(2));
        });

        table.Remove("c");

        Assert.Multiple(() =>
        {
            Assert.That(!table.IsEmpty());
            Assert.That(!table.Contains("a"));
            Assert.That(!table.Contains("b"));
            Assert.That(table.Contains("c"));
            Assert.That(table.Size(), Is.EqualTo(1));
        });

        table.Remove("c");

        Assert.Multiple(() =>
        {
            Assert.That(table.IsEmpty());
            Assert.That(!table.Contains("a"));
            Assert.That(!table.Contains("b"));
            Assert.That(!table.Contains("c"));
            Assert.That(table.Size(), Is.EqualTo(-1));
        });
    }
}

///////////////////////////////////////////////////////////////////////////////
