/// <summary>
/// Princípio Aberto-Fechado — Objetos ou entidades devem estar abertos para extensão, mas fechados para modificação, ou seja, quando novos comportamentos e 
/// recursos precisam ser adicionados no software, devemos estender e não alterar o código fonte original.
/// </summary>
namespace ProgramingCSharpExamRef70_483.SOLID.OCP
{
    class ContratoCltWrong
    {
        public decimal Salario()
        {
            return 3000;
        }
    }

    class EstagioWrong
    {
        public decimal BolsaAuxilio()
        {
            return 1000;
        }
    }
    /// <summary>
    /// Em um sistema hipotético de RH, temos duas classes que representam os contratos de trabalhos dos funcionários de uma pequena empresa, 
    /// contratados e estágiários. Além de uma classe para processar a folha de pagamento.
    /// 
    /// Qual o problema de se alterar a classe FolhaDePagamento?
    /// 
    /// Não seria mais fácil apenas acrescentar mais um IF e verificar o novo tipo de funcionário PJ aplicando as respectivas regras?
    /// Sim, e provavelmente essa seria a solução que programadores menos experientes iriam fazer.Mas, esse é exatamente o problema!
    /// Alterar uma classe já existente para adicionar um novo comportamento, corremos um sério risco de introduzir bugs em algo que já estava funcionando.
    /// </summary>
    class FolhaDePagamentoWrong
    {
        protected decimal saldo;

        public void Calcular(object funcionario)
        {
            if (funcionario is ContratoCltWrong)
            {
                saldo = ((ContratoCltWrong)funcionario).Salario();
            }
            else if (funcionario is EstagioWrong)
            {
                saldo = ((EstagioWrong)funcionario).BolsaAuxilio();
            }

        }
    }


    interface Remuneravel
    {
        public decimal Remuneracao();
    }

    class ContratoClt : Remuneravel
    {
        public decimal Remuneracao()
        {
            return 3000;
        }
    }

    class Estagio : Remuneravel
    {
        public decimal Remuneracao()
        {
            return 1000;
        }
    }

    /// <summary>
    /// Como adicionamos um novo comportamento sem alterar o código fonte já existente?
    /// 
    /// Separe o comportamento extensível por trás de uma interface e inverta as dependências.
    /// 
    /// </summary>
    class FolhaDePagamento
    {
        protected decimal saldo;

        public void Calcular(Remuneravel funcionario)
        {
            saldo = funcionario.Remuneracao();
        }
    }
}
