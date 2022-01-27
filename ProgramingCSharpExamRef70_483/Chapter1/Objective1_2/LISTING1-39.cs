using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_2
{
    //LISTING 1-39 A potential problem with multithreaded code
    public class LISTING1_39
    {
        // esse é um exemplo que pode dá problema em uma execução em thread,
        //pois o compilador tenta otimizar o algoritmo mudando a ordem de execução
        //vc pode resolver isso com lock ou exite outra forma de resolver com System.Threading.Volatile
        private static int _value { get; set; }
        private static int _flag { get; set; }
        public static void Thread1()
        {
            _value = 5;
            _flag = 1;
        }
        public static void Thread2()
        {
            if (_flag == 1)
                Console.WriteLine(_value);
        }      
    }
}
