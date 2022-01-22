using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    /// <summary>
    /// LISTING 1-32 Using a ConcurrentStack
    /// </summary>
    public class LISTING1_32
    {
        //Exemplo simples de uso ConcurrentStack
        //Representa uma coleção thread-safe LIFO(Pilha) (último a entrar, primeiro a sair).
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
