using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-20 Using ConfigureAwait
    public class LISTING1_20
    {
        //exemplo simples usando task, mas agora desabilitando o SynchronizationContext,
        //SynchronizationContext mantem o contexto da aplicação, 
        //isso faz com que a task ao ser finalizada recupere o context para atualizar a interface com o usuário por exemplo,        
        //caso não tenha essa necessidade vc pode disabilitar, assim melhorando a perfomance da task
        //mais explicações sobre SynchronizationContext acessar: https://docs.microsoft.com/pt-br/archive/msdn-magazine/2011/february/msdn-magazine-parallel-computing-it-s-all-about-the-synchronizationcontext
        public async static Task Start()
        {
            await ConfigureAwaitFalse();
        }
        public async static Task ConfigureAwaitFalse() {
            HttpClient httpClient = new HttpClient();
            string content =
            await httpClient
            .GetStringAsync("http://www.microsoft.com")
            //Essa é uma boa opção para bibliotecas independentes da interface.
            //mais informações: https://docs.microsoft.com/pt-br/dotnet/fundamentals/code-analysis/quality-rules/ca2007
            .ConfigureAwait(false);
            //no caso de um aplicativo windows forms ou WPF, esse codigo irá da erro por causa do ConfigureAwait(false), 
            //pois não irá consiguir acessar o contexto da aplicação
            //Output.Content = content;

        }
    }
}
