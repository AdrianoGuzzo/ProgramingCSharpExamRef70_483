using System;
using System.Linq;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    public class LISTING1_22
    {
        //exemplo simples usando Parallel em linq (PLINQ)        
        public static void Start()
        {
            var numbers = Enumerable.Range(0, 100000000);
            var parallelResult = numbers.AsParallel()
            .Where(i => i % 2 == 0)
            .ToArray();           
        }
    }
}
