using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_2
{
    //LISTING 1-41 Compare and exchange as a nonatomic operation
    public class LISTING1_41
    {
        static int value = 1;
        public static void Start()
        {
            Task t1 = Task.Run(() =>
            {
                //pode resolver isso com                
                //Interlocked.CompareExchange(ref value, 2, 1);
                if (value == 1)
                {
                    // Removing the following line will change the output
                    Thread.Sleep(1000);
                    value = 2;
                }
            });
            Task t2 = Task.Run(() =>
            {
              
                value = 3;
            });
            Task.WaitAll(t1, t2);
            Console.WriteLine(value); // Displays 2
        }
    }
}
