using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// ISP — Interface Segregation Principle
/// 
/// Princípio da Segregação da Interface — Uma classe não deve ser forçada a implementar interfaces e métodos que não irão utilizar.
/// </summary>
namespace ProgramingCSharpExamRef70_483.SOLID.ISP___Interface_Segregation_Principle
{
    interface AvesWrong
    {
        public void SetLocalizacao(long longitude, long latitude);
        public void SetAltitude(long altitude);
        public void renderizar();
    }

    class PapagaioWrong : AvesWrong
    {
        public void renderizar()
        {
            //Faz alguma coisa
        }

        public void SetAltitude(long altitude)
        {
            //Faz alguma coisa
        }

        public void SetLocalizacao(long longitude, long latitude)
        {
            //Faz alguma coisa
        }
    }

    class PinguimWrong : AvesWrong
    {
        public void renderizar()
        {
            //Faz alguma coisa
        }
        /// <summary>
        /// Percebam que ao criar a interface Aves, atribuímos comportamentos genéricos e isso acabou forçando a classe Pinguim a implementar o método setAltitude()
        /// do qual ela não deveria ter, pois pinguins não voam! Dessa forma, estamos violando o Interface Segregation Principle — E o LSP também!
        /// </summary>
        /// <param name="altitude"></param>
        public void SetAltitude(long altitude)
        {
            //Não faz nada...  Pinguins são aves que não voam!
        }

        public void SetLocalizacao(long longitude, long latitude)
        {
            //Faz alguma coisa
        }
    }

    interface Aves
    {
        public void SetLocalizacao(long longitude, long latitude);
        public void Renderizar();
    }

    /// <summary>
    /// Para resolver esse problema, devemos criar interfaces mais específicas, veja:
    /// </summary>
    interface AvesQueVoam : Aves
    {
        public void SetAltitude(long altitude);
    }

    class Papagaio : AvesQueVoam
    {
        public void Renderizar()
        {
            //Faz alguma coisa
        }

        public void SetAltitude(long altitude)
        {
            //Faz alguma coisa
        }

        public void SetLocalizacao(long longitude, long latitude)
        {
            //Faz alguma coisa
        }
    }

    class Pinguim : Aves
    {
        public void Renderizar()
        {
            //Faz alguma coisa
        }

        public void SetLocalizacao(long longitude, long latitude)
        {
            //Faz alguma coisa
        }
    }
}
