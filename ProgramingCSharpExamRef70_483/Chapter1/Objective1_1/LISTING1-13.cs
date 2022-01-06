using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-13 Using a TaskFactory
    public class LISTING1_13
    {
        //exemplo de 3 task filhas sendo executadas dentro de uma task pai,
        //mas usando outra abordargem mais elegante que é usando o TaskFactory.        
        public static void Start()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
                TaskContinuationOptions.ExecuteSynchronously);
                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => {
                    //essa task ira executa, mas não irá mostra o resulta no ContinueWith, pois demora um pouco mais
                    Thread.Sleep(3000);
                    results[1] = 1;
                    });
                tf.StartNew(() => results[2] = 2);
                return results;
            });
            var finalTask = parent.ContinueWith(
            parentTask => {
                foreach (int i in parentTask.Result)
                    Console.WriteLine(i);
            });
            finalTask.Wait();
        }
    }
}
