
using NUnit.Framework;
using TestProject1;

Console.WriteLine("Run `dotnet test` for testing");
ITable<String> test = new ClosedHashTable<String>();
test.Add("54");
Console.WriteLine(test.ToString());
