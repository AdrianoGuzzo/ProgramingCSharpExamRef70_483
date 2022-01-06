using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-15 Using Task.WaitAny
    public class LISTING1_15
    {
        //exemplo de 3 task sendo executadas, mas usando o metodo WaitAny, 
        
        public static void Start()
        {
            Task<int>[] tasks = new Task<int>[3];
            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });
            while (tasks.Length > 0)
            {
                //o metodo WaitAny espera por alguma task que terminou e retorna qual o index desta task
                //com isso podemos obter o retorno da task conforme o codigo abaixo
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];
                Console.WriteLine(completedTask.Result);
                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }
        }
    }
}
