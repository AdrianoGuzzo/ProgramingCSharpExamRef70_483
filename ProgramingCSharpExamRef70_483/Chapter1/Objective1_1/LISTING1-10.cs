using System;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-10 Adding a continuation
    public class LISTING1_10
    {
        //exemplo executando uma task com retorno, mas agora usando o continueWith,executa outra task logo em seguida
        public static void Start()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });

            //t.Result obriga a task devolver o resultado
            //Cuidado ao usar o Result. 
            //pois caso a task não consiga retorna o valor a Thread irá fica bloquiada
            Console.WriteLine(t.Result); // Displays 84
        }
    }
}
