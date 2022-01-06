using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-17 Using Parallel.Break
    public class LISTING1_17
    {
        //exemplo executando processo paralelo, usando o metodo loopState.Break(); que cancela o loop
        public static void Start()
        {
            ParallelLoopResult result = Parallel.
                For(0, 1000, (int i, ParallelLoopState loopState) =>
                {
                    Console.WriteLine("index:{0}", i);
                    if (i == 1)
                    {
                        Console.WriteLine("Breaking loop");
                        //cancela o loop, mas cuidado não é cancelado na sequencia, verifica o retorno do console
                        loopState.Break();
                    }
                    return;
                });
        }
        //*When breaking the parallel loop, the result variable has an IsCompleted value of false and a
        //LowestBreakIteration of 500. When you use the Stop method, the LowestBreakIteration is null.
    }
}
