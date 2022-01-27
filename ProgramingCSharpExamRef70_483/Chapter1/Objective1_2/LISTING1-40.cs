using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_2
{
    //LISTING 1-40 Using the Interlocked class
    public class LISTING1_40
    {
        //exemplo de uso Interlocked
        //Os métodos dessa classe ajudam a proteger contra erros que podem ocorrer quando
        //o Agendador alterna contextos enquanto um thread está atualizando uma variável
        //que pode ser acessada por outros threads ou quando dois threads são executados
        //simultaneamente em processadores separados.Os membros dessa classe não lançam exceções.
        public static void Start()
        {
            int n = 0;            
            var up = Task.Run(() =>
            {

                for (int i = 0; i < 1000000; i++)
                    Interlocked.Increment(ref n);
            });
            for (int i = 0; i < 1000000; i++)
                Interlocked.Decrement(ref n);
            up.Wait();
            Console.WriteLine(n);
        }

        //Define uma variável com um valor especificado como uma operação atômica.
        //if ( Interlocked.Exchange(ref isInUse, 1) == 0) { }
    }
}
