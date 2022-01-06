using System;
using System.Threading;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-7 Queuing some work to the thread pool
    public class LISTING1_7
    {
        //exemplo simples do como usar ThreadPool,
        //a vantagem de usar ThreadPool e pelo fator do mesmo gerenciar as threads de forma autimatica,
        //evitando problemas de performance, por exemplo, caso seja requisitado varias threads, 
        //o pool irá limitar a execução e colocar o restante das threads em uma fila de espera, 
        //aguardando a finalização das outras threads.
        public static void Start()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool ");
                Thread.Sleep(500);
            });
            Console.ReadLine();
        }

    }
}
