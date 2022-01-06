using System;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-9 Using a Task that returns a value.
    public class LISTING1_9
    {
        //exemplo executando uma task com retorno
        public static void Start()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });
            //t.Result obriga a task devolver o resultado
            //Cuidado ao usar o Result. 
            //pois caso a task não consiga retorna o valor a Thread irá fica bloquiada
            Console.WriteLine(t.Result); // Displays 42
        }
    }
}
