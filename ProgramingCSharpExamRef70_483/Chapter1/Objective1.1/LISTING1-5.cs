using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1._1
{
    //LISTING 1-5 Using the ThreadStaticAttribute
    public class LISTING1_5
    {
        [ThreadStatic]
        public static int _field;

        //Exemplo de como setar uma variavel local para usar dentro de cada thread,
        //com o annotation ThreadStatic, cada thread vai ter sua propria variavel local idependente uma da outra,
        //caso contrario a variavel será compartilhada entre threads
        public static void Start()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {                  
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {                  
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}

