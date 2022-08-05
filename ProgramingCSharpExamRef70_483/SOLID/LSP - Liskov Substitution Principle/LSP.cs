using System;

/// <summary>
/// LSP— Liskov Substitution Principle
/// 
/// Um exemplo mais simples e de fácil compreensão dessa definição. Seria:
/// 
/// se S é um subtipo de T, então os objetos do tipo T, em um programa,
/// podem ser substituídos pelos objetos de tipo S sem que seja necessário alterar as propriedades deste programa.
/// </summary>
namespace ProgramingCSharpExamRef70_483.SOLID.LSP___Liskov_Substitution_Principle
{
    class X
    {
        public virtual string GetNome()
        {
            return "Meu nome é X";
        }
    }

    class Y : X
    {
        public override string GetNome()
        {
            return "Meu nome é Y";
        }
    }
    /// <summary>
    /// Para facilitar o entendimento, veja esse princípio na prática neste simples exemplo:
    /// </summary>
    class ImprimeNome {

        private string Imprimir(X obj) {

            return obj.GetNome();
        }
        /// <summary>
        /// Estamos passando como parâmetro tanto a classe pai como a classe derivada e o código continua funcionando da forma esperada.
        /// </summary>
        public void Imprimir() {
            X obj1 = new X();
            Y obj2 = new Y();
            Console.WriteLine(Imprimir(obj1));
            Console.WriteLine(Imprimir(obj2));
        }
    }

    //Exemplos de violação do LSP:

    //Sobrescrever/implementar um método que não faz nada;
    //Lançar uma exceção inesperada;
    //Retornar valores de tipos diferentes da classe base;
}
