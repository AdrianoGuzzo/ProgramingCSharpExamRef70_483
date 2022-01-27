using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_2
{
    //LISTING 1-37 Creating a deadlock
    public class LISTING1_37
    {
        //Um exemplo de deadlock(impasse) usando lock
        //Evite usar a mesma instância de objeto de bloqueio para diferentes recursos compartilhados,
        //uma vez que ela poderia resultar em deadlock ou contenção de bloqueio.Especificamente,
        //evite usar os seguintes itens como objetos de bloqueio:
        //  - this, uma vez que pode ser usado pelos chamadores como um bloqueio.
        //  - Instâncias Type, pois podem ser obtidas pelo operador ou reflexão typeof.
        //  - Instâncias de cadeia de caracteres, incluindo literais de cadeia de caracteres, pois podem ser internalizadas.
        public static void Start()
        {
            object lockA = new object();
            object lockB = new object();
            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("Locked A and B");
                    }
                }
            });
            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("Locked A and B");
                }
            }
            up.Wait();
        }
    }
}
