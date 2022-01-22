using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    /// <summary>
    /// LISTING 1-34 Using a ConcurrentDictionary
    /// </summary>
    public class LISTING1_34
    {
        //uso simples do ConcurrentDictionary<string, int>();
        //é um lista de chave e valor
        public static void Start()
        {
            var dict = new ConcurrentDictionary<string, int>();
            //tenta adiciona um valor se não existir
            if (dict.TryAdd("k1", 42))
            {
                Console.WriteLine("Added");
            }
            //substitui valor caso a comparação seja igual
            if (dict.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("42 updated to 21");
            }
            // substitui incondicionalmente
            dict["k1"] = 42; 
            //adiciona o valor 3 se a chave K1 não existir, caso contrario executa a função de multiplicação i * 2 
            int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            //adiciona o valor caso não exista e pega o valor
            int r2 = dict.GetOrAdd("k2", 10);
        }
    }
}
