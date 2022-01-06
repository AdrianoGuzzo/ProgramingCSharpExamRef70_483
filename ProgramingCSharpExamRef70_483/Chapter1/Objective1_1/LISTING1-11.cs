using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-11 Scheduling different continuation tasks
    public class LISTING1_11
    {
        //exemplo executando uma task, mas agora usando o continueWith que faz tratamento para cada situação
        public static void Start()
        {
            var tokenSource = new CancellationTokenSource();
            Task<int> t = Task.Run(() =>
            {
                Thread.Sleep(500);
                // forção exceção
                //throw new Exception();
                return 42;
            }, tokenSource.Token);
            t.ContinueWith((i) =>
            {
                //Executa somente quando a task for cancelada
                Console.WriteLine("Canceled");                
            }, TaskContinuationOptions.OnlyOnCanceled);
            t.ContinueWith((i) =>
            {
                //executa somente de ocorre uma exceção na task
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);
            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            //força cancelamento da task
            //tokenSource.Cancel();
            completedTask.Wait();
        }
    }
}
