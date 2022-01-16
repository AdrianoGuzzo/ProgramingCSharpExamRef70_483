using System;
using System.Linq;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-24 Ordered parallel query
    public class LISTING1_24
    {
        //exemplo simples usando Parallel em linq (PLINQ)
        //mas agora podemos perceber que a ordem esta sendo respeitada agora
        public static void Start()
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel()
            //manter a ordem do array    
            .AsOrdered()
            .Where(i => i % 2 == 0)
            .ToArray();
            foreach (int i in parallelResult)
                Console.WriteLine(i);
        }
    }
}
