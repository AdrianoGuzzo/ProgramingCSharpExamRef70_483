using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-14 Using Task.WaitAll
    public class LISTING1_14
    {
        //exemplo de 3 task sendo executadas, mas usando o metodo WaitAll para esperar todas terminarem,

        public static void Start()
        {
            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });
            tasks[1] = Task.Run(() =>
            {
                //essa task será a ultima a termina pois tem um tempo maior de espera
                Thread.Sleep(3000);
                Console.WriteLine("2");
                return 2;
            });
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            }
            );

            //tambem tem o metodo WhenAll, que apos todas a tasks serem executadas permite executar ContinueWith             
            //Task.WhenAll(tasks).ContinueWith(parentTask =>
            //{
            //    Console.WriteLine("Completed");
            //});

            Task.WaitAll(tasks);
        }
    }
}
