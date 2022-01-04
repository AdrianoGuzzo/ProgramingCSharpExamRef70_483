using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1._1
{
    //LISTING 1-1 Creating a thread with the Thread class
    public class LISTING1_1
    {
        //metodo que vai ser executado pela thread
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
        //exemplo de execução de um thread, normalmente não é recomendado usar thread na aplicação, 
        //existe outras formas mais recomendadas. 
        //A vantagem de usar thread é ter mais controle sobre a mesma, como por exemplo, determinar prioridade(Priority)
        public static void Start()
        {           
            Thread t = new Thread(new ThreadStart(ThreadMethod));

            //Cuidado ao determinar prioridade a thread, pois definir a prioridade como alta(Highest), 
            //pode dificultar a execução de outras threads, só em caso de extrema necessidade
            //Exemplo:
            //t.Priority = ThreadPriority.Highest;

            //inicia a execução da thread
            t.Start();

            //For para concorrer com a thread
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }

            //espera a thread terminar
            t.Join();
        }

    }
}
