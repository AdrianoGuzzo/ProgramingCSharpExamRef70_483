using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-27 Catching AggregateException
    public class LISTING1_27
    {
        public static void Start()
        {
            var numbers = Enumerable.Range(0, 20);
            try
            {
                var parallelResult = numbers.AsParallel()
                .Where(i => IsEven(i));
                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count);
            }
        }
        public static bool IsEven(int i)
        {
            if (i % 10 == 0) throw new ArgumentException($"i: {i}");
            return i % 2 == 0;

        }
    }
}
