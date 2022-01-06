using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-16 Using Parallel.For and Parallel.Foreach
    public class LISTING1_16
    {
        //exemplo simples executando processo paralelo Parallel.For e Parallel.Foreach
        //OBS: não é necessaria usar processo paralelo em todos os loop de sua aplicação,
        //somente em casos de processos que não precisa executar em ordem e que sejam logos
        //avalie as condições antes de usar
        public static void Start()
        {
            //irá executar fora da ordem, observer o resultado do console
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("For :{0}",i);
            });
            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("ForEach :{0}", i);
            });
        }
    }
}
