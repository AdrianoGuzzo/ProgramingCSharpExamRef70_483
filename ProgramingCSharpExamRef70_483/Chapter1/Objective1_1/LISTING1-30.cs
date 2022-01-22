using System;
using System.Collections.Concurrent;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-30 Using a ConcurrentBag
    public class LISTING1_30
    {
        //exemplo simples de uso ConcurrentBag,
        //Os pacotes são úteis para armazenar objetos quando a ordem não importa e,
        //diferentemente dos conjuntos, oferecem suporte a duplicatas.
        public static void Start()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(42);
            bag.Add(21);
            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);
            if (bag.TryPeek(out result))
                Console.WriteLine("There is a next item: {0}", result);
        }
    }
}
