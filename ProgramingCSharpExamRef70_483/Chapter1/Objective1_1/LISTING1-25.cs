using System;
using System.Linq;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-25 Making a parallel query sequential    
    public class LISTING1_25
    {
        //se for preciso executar um processo em Pararelo e depois tiver a necessidade de executar sequecial,
        //precisa somente de executar o AsSequential
        public static void Start()
        {
            var numbers = Enumerable.Range(0, 20);
            var parallelResult = numbers.AsParallel().AsOrdered()
            .Where(i => i % 2 == 0)
            //desativa processamento paralelo
            .AsSequential();
            foreach (int i in parallelResult.Take(5))
                Console.WriteLine(i);
        }
    }
}
