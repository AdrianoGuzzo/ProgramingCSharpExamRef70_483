using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-29 Using GetConsumingEnumerable on a BlockingCollection
    public class LISTING1_29
    {
        //Outro exemplo usando BlockingCollection, mas com GetConsumingEnumerable
        //o GetConsumingEnumerable deixa o foreach bloqueado enquanto não tiver item adicionado a lista
        //outra forma de comsumir o BlockingCollection

        public static void Start()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                foreach (string v in col.GetConsumingEnumerable()){

                    Console.WriteLine(v);
                    //importante saber que o metodo CompleteAdding avisa a lista que o processo de add foi finalizado,
                    //assim e liberado o bloqueio do BlockingCollection, dando sequencia ao algoritmo
                    //col.CompleteAdding();
                }
            });
            Task write = Task.Run(() =>
            {
                while (!col.IsAddingCompleted)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    if(!col.IsAddingCompleted)
                    //adiciona um item na lista
                    col.Add(s);
                }
            });
            write.Wait();
        }
    }
}
