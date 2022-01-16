using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-26 Using ForAll
    public class LISTING1_26
    {
        //Caso precise executar um loop em paralelo, pode utilizar o ForAll
        public static void Start()
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel().AsOrdered()
            .Where(i => i % 2 == 0);
            parallelResult.ForAll(e => Console.WriteLine(e));
        }
    }
}
