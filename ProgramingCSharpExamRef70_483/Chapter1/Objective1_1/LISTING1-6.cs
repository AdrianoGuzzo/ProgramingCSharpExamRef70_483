using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-6 Using ThreadLocal<T>
    public class LISTING1_6
    {     
        public static ThreadLocal<int> _field =
           new ThreadLocal<int>(() =>
           {
               //seta valores diferentes para cada thread,
               //no caso esta pegando um Id da thread atual
               return Thread.CurrentThread.ManagedThreadId;
           });

        //Exemplo de como setar uma variavel local para usar dentro de cada thread,
        //mas inicializando a variavel para cada thread usando ThreadLocal
        public static void Start()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                    Console.WriteLine("Thread B: {0}", x);
                }

            }).Start();
            Console.ReadKey();
        }
    }
}
