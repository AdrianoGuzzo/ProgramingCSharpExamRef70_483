using System;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_2
{
    //LISTING 1-36 Using the lock keyword
    public class LISTING1_36
    {
        //Segue um exemplo simples da forma certa de compartilhar uma variarial em uma task
        //de compartilhar uma variarial em uma task
        //lock obtém o bloqueio de exclusão mútua para um determinado objeto,
        //executa um bloco de instruções e, em seguida, libera o bloqueio.Embora um bloqueio seja mantido,
        //o thread que mantém o bloqueio pode adquiri-lo novamente e liberá-lo.
        //Qualquer outro thread é impedido de adquirir o bloqueio e aguarda até que ele seja liberado.
        public static void Start()
        {
            int n = 0;
            object _lock = new object();
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    //espera o objeto ser liberado para atribuir valo a n
                    lock (_lock)
                        n++;
            });
            for (int i = 0; i < 1000000; i++)
                //espera o objeto ser liberado para atribuir valo a n
                lock (_lock)
                    n--;
            up.Wait();
            Console.WriteLine(n);
        }
    }
}
