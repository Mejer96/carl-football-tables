using System;
using System.Collections;

namespace FootballTables 
{
    public class QueueWithMaxSize<T> : Queue<T>
    {
        public int Size { get; set; }

        public QueueWithMaxSize(int size) 
        {
            this.Size = size;
        }
        // inspiration for limiting the max size of a queue:
        // https://stackoverflow.com/questions/1292/limit-size-of-queuet-in-net

        // documentation on new vs override keyword:
        // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords
        public new void Enqueue(T obj) 
        {
          while (Count >= 5) 
          {
            Dequeue();
          }
          // base keyword is used to refer to members of the base class (parent/super class) within a derived class.
          base.Enqueue(obj);
        }
    }
}