using System.Collections;
using NUnit.Framework;

///////////////////////////////////////////////////////////////////////////////

namespace TestProject1;

///////////////////////////////////////////////////////////////////////////////

[TestFixture(typeof(BST<String, String>))]
public class TestMaps<TMap>
    where TMap : IMap<String, String>, new()
{

    [Test]
    public void TestBasics()
    {
        TMap map = new();

        Assert.That(map.IsEmpty());
        Assert.AreEqual(map.Size(), 0);

        map.Set("a", "b");

        Assert.That(!map.IsEmpty());
        Assert.That(map.ContainsKey("a"));
        Assert.AreEqual(map.Get("a"), "b");
        Assert.AreEqual(map.Size(), 1);


        Assert.AreEqual(map.Delete("a"), "b");
        Assert.AreEqual(map.Delete("a"), null);
        Assert.That(map.IsEmpty());
        Assert.That(!map.ContainsKey("a"));
        Assert.AreEqual(map.Get("a"), null);
        Assert.AreEqual(map.Size(), 0);

        map.Set("a", "b");

        Assert.AreEqual(map.Size(), 1);
        Assert.That(!map.IsEmpty());
        Assert.That(map.ContainsKey("a"));
        Assert.AreEqual(map.Get("a"), "b");

        map.Set("b", "c");

        Assert.AreEqual(map.Size(), 2);
        Assert.That(!map.IsEmpty());
        Assert.That(map.ContainsKey("a"));
        Assert.AreEqual(map.Get("a"), "b");
        Assert.That(map.ContainsKey("b"));
        Assert.AreEqual(map.Get("b"), "c");

        map.Set("c", "d");


        Assert.AreEqual(map.Size(), 3);
        Assert.That(!map.IsEmpty());
        Assert.That(map.ContainsKey("a"));
        Assert.AreEqual(map.Get("a"), "b");
        Assert.That(map.ContainsKey("b"));
        Assert.AreEqual(map.Get("b"), "c");
        Assert.That(map.ContainsKey("c"));
        Assert.AreEqual(map.Get("c"), "d");

        Assert.AreEqual(map.Delete("a"), "b");

        Assert.AreEqual(map.Size(), 2);
        Assert.That(!map.IsEmpty());
        Assert.That(!map.ContainsKey("a"));
        Assert.AreEqual(map.Get("a"), null);
        Assert.That(map.ContainsKey("b"));
        Assert.AreEqual(map.Get("b"), "c");
        Assert.That(map.ContainsKey("c"));
        Assert.AreEqual(map.Get("c"), "d");
    }
}

///////////////////////////////////////////////////////////////////////////////
