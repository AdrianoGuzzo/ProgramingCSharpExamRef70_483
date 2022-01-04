using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1._1
{
    //LISTING 1-3 Using the ParameterizedThreadStart
    public class LISTING1_3
    {
        public static void ThreadMethod(object o)
        {
            //faz um cast do object o para int,
            //esse "o" é setado no t.Start(valor)
            var count = (int)o;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
        //exemplo de como setar parametro para uma thread
        public static void Start()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            //foi setado o valor para thread, e iniciado
            t.Start(10);
            t.Join();
        }
    }
}
