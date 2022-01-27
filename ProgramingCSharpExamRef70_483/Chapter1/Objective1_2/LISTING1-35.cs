using System;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_2
{
    //LISTING 1-35 Accessing shared data in a multithreaded application
    public class LISTING1_35
    {
        //Segue um exemplo simples da forma errada de compartilhar uma variarial em uma task
        public static void Start()
        {
            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    n++;
            });
            for (int i = 0; i < 1000000; i++)
                n--;
            up.Wait();
            //o resultado irá variar
            //isso acontece por não ser uma operação atomica
            Console.WriteLine(n);
        }
    }
}
