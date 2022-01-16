using System;
using System.Linq;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-23 Unordered parallel query
    public class LISTING1_23
    {
        //exemplo simples usando Parallel em linq (PLINQ)
        //mas agora podemos perceber que a ordem que foi impressa esta fora
        public static void Start()
        {
            var numbers = Enumerable.Range(0, 10);
            var parallelResult = numbers.AsParallel()
                .Where(i => i % 2 == 0)
                .ToArray();
            foreach (int i in parallelResult)
                Console.WriteLine(i);
        }
    }
}
