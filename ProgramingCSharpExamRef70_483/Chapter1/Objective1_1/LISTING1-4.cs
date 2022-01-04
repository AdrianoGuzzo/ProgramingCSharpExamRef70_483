using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-4 Stopping a thread
    public class LISTING1_4
    {
        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
        //exemplo de como parar uma thread em tempo de execução

        //podemos usar o metodo Thread.Interrupt para parar a thread, 
        //mas isso gera um exceção tipo ThreadInterruptedException,
        //o que pode comprometer sua aplicação
        //exemplo: 
        //t.Interrupt();
        //OBS: Interrupt é usado no .Net core, para o .Net Framework usar o Thread.Abort

        //o caminho mais seguro é criar uma variavel compartilhada
        //que controla quando deve parar de executar, conforme o exemplo abaixo:     
        public static void Start()
        {
            //variavel compartilhada
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));
            
            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            //t.Interrupt();
            stopped = true;
            t.Join();
        }
    }
}
