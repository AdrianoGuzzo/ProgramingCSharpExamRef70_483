using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-28 Using BlockingCollection<T>
    public class LISTING1_28
    {
        //exemplo simples usando BlockingCollection,
        //o metodo Take() fica bloquiado enquanto a BlockingCollection estiver vazia, entâo ele quando for adicionado um item a collection,
        //o Take() irá pegar este item e remove-lo da lista
        public static void Start()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                while (!col.IsAddingCompleted)
                {
                    //fica bloquiado enquanto não tiver item na lista
                    Console.WriteLine(col.Take());
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
                    if (!col.IsAddingCompleted)
                        //adiciona um item na lista
                        col.Add(s);
                }
            });
            write.Wait();
        }

    }
}
