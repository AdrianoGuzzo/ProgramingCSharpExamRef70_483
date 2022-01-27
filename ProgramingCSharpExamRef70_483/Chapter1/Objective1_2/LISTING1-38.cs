using System.Threading;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_2
{
    //LISTING 1-38 Generated code from a lock statement
    public class LISTING1_38
    {
        //Exemplo de como o lock funciona no compilador,
        //não usar desta forma
        public static void Start()
        {
            object gate = new object();
            bool __lockTaken = false;
            try
            {
                Monitor.Enter(gate, ref __lockTaken);
            }
            finally
            {
                if (__lockTaken)
                    Monitor.Exit(gate);
            }
        }
    }
}
