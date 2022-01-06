using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-12 Attaching child tasks to a parent task
    public class LISTING1_12
    {

        //exemplo de 3 task filhas sendo executadas dentro de uma task pai,
        //lembrando que o continueWith só será executada quando três task estiverem prontas
        //isso não significa que irá esperar o resultado de todas
        public static void Start()
        {
            Task<Int32[]> parent = Task.Run(() =>
            {
            var results = new Int32[3];
            new Task(() => results[0] = 0,
            TaskCreationOptions.AttachedToParent).Start();
            new Task(() => results[1] = 1,
            TaskCreationOptions.AttachedToParent).Start();
            new Task(() => {
                //essa task ira executa, mas não irá mostra o resulta pois demora um pouco mais
                Thread.Sleep(200);
                results[2] = 2;
            },
                TaskCreationOptions.AttachedToParent).Start();
            return results;
        });
            //Executa assim que todas as task estiverem prontas
            var finalTask = parent.ContinueWith(
            parentTask =>
            {
                foreach (int i in parentTask.Result)
                    Console.WriteLine(i);
            });

        finalTask.Wait();
        }
}
}
