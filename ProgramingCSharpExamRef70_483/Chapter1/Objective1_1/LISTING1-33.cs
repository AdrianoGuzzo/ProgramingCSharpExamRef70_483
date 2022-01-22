using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    /// <summary>
    /// LISTING 1-33 Using a ConcurrentQueue
    /// </summary>
    public class LISTING1_33
    {
        //exemplo simples de usar ConcurrentQueue
        //Represents a thread-safe first in-first out (Fila) (FIFO) collection.
        public static void Start()
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(42);
            stack.Push(10);
            int result;
            if (stack.TryPop(out result))
                Console.WriteLine("Popped: {0}", result);
            stack.PushRange(new int[] { 1, 2, 3 });
            int[] values = new int[2];
            stack.TryPopRange(values);
            foreach (int i in values)
                Console.WriteLine(i);
        }
    }
}
