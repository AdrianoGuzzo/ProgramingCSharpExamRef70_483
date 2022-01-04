using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1._1
{
    //LISTING 1-2 Using a background thread
    public class LISTING1_2
    {
        //metodo que vai ser executado pela thread
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }
        // exemplo de thread sendo executado em segundo plano(Background)
        public static void Start()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            // a diferença entre executar em segundo plano(Background) para primeiro plano(Foreground),

            // segundo plano(Background) a thread irá continuar sendo executada mesmo que a aplicação finalize,
            // nesse exemplo a aplicação não irá imprimir o resultado no console, pois irá encerrar antes de executar a thread
            // t.IsBackground = true;

            //primeiro plano(Foreground) a thread irá executar somete com a aplicação em execução,
            //então irá termina de imprimir na tela antes de finalizar
            // t.IsBackground = false;
            t.IsBackground = true;
            t.Start();           
        }
    }
}
