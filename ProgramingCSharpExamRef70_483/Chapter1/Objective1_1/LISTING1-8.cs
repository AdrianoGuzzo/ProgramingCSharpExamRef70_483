using System;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    public class LISTING1_8
    {
        //exemplo executando uma simples task
        //Task e uma forma de executar processos assincronos que consegue ter um retorno,
        //e verificar se ela foi finalizada, é mais recomendado uso de Task do que Thread em processo assíncrono
        public static void Start()
        {
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 100; x++)
                {
                    Console.Write("*");                    
                }
            });
            //Faz o mesmo que o Join na thread, espera o processo terminar de ser executado
            t.Wait();
        }
    }
}
