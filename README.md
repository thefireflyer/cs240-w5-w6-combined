# CS 240 | Week 5 and 6

[![.NET](https://github.com/thefireflyer/cs240-w5-w6-combined/actions/workflows/dotnet.yml/badge.svg)](https://github.com/thefireflyer/cs240-w5-w6-combined/actions/workflows/dotnet.yml)

| | |
|-|-|
| Author | Aidan Beil |
| Date | 13/2/2024 |
| Class | CS240 2963 |
| Professor | Darrell Criss |

---

### Organization

- Hash Tables
    - [Hashing algorithm](Hasher.cs)
    - Using open addressing - [`OpenHashMap`](Tables/OpenHashTable.cs)
    - Using closed addressing - [`ClosedHashMap`](Tables/ClosedHashTable.cs)
    - [Unit testing](Tables/TestTable.cs)
- Maps
    - [Interface](Maps/IMap.cs)
    - BST Maps
        - Unbalanced - [`BST`](Maps/BSTs/BST.cs)
    - [Unit testing](Maps/TestMaps.cs)
- Stacks
    - [Interface](Stacks/IStack.cs)
    - Using linked lists - [`LinkedStack`](Stacks/LinkedStack.cs)
    - Using arrays - [`ArrayStack`](Stacks/ArrayStack.cs)
    - [Unit testing](Stacks/TestStacks.cs)
- Queues
    - [Interface](Queues/IQueue.cs)
    - Using linked lists - [`LinkedQueue`](Queues/LinkedQueue.cs)
    - Using arrays - [`ArrayQueue`](Queues/ArrayQueue.cs)
    - [Unit testing](Queues/TestQueues.cs)

---

### Usage

`dotnet test`

> ...
>
>

`dotnet run`

> ...
>
>

---

### Sectioning

`///////////////////////////////////////////////////////////////////////////////`

`//---------------------------------------------------------------------------//`

`//...........................................................................//`


---

### Sources

[1] [Grokking Algorithms](https://livebook.manning.com/book/grokking-algorithms-second-edition/chapter-1/v-4/)

[2] [Wikipedia](https://en.wikipedia.org/wiki/Horner's_method)

[3] [Wikipedia](https://en.wikipedia.org/wiki/Hash_function#Radix_conversion_hashing)

[4] [The Algorithm Design Manual]()

[5] <https://csguide.tech/s/articles/horners_method_of_hash_calculation>

[6] <https://www.cs.umd.edu/class/fall2019/cmsc420-0201/Lects/lect10-hash-basics.pdf>

---
