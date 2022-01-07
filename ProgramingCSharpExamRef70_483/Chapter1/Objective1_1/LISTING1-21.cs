using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    //LISTING 1-21 Continuing on a thread pool instead of the UI thread
    public class LISTING1_21
    {
        //exemplo simples usando task, mas agora desabilitando o SynchronizationContext,
        //o que podemos observar que o ConfigureAwait(false) irá funciona perfeitamente, 
        //pois não existe interação com interface com o usuário, apenas salvando o resultado em arquivo
        public async static Task Start()
        {
            await ConfigureAwaitFalse();
        }
        public async static Task ConfigureAwaitFalse()
        {
            HttpClient httpClient = new HttpClient();
            string content = await httpClient
            .GetStringAsync("http://www.microsoft.com")
            .ConfigureAwait(false);

            using (FileStream sourceStream = new FileStream("temp.html",
            FileMode.Create, FileAccess.Write, FileShare.None,
            4096, useAsync: true))
            {
                byte[] encodedText = Encoding.Unicode.GetBytes(content);
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length)
                .ConfigureAwait(false);
            };
        }
    }
}
