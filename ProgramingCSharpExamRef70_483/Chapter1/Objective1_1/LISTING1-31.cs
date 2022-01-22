using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-31 Enumerating a ConcurrentBag
    public class LISTING1_31
    {
        //exemplo simples de uso ConcurrentBag,
        //Os pacotes são úteis para armazenar objetos quando a ordem não importa e,
        //diferentemente dos conjuntos, oferecem suporte a duplicatas.
        public static void Start()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });
            Task.Run(() =>
            {
                foreach (int i in bag)
                    Console.WriteLine(i);
            }).Wait();
        }
    }
}
