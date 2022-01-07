using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramingCSharpExamRef70_483.Chapter1.Objective1_1
{
    public class LISTING1_19
    {

        //aqui nesse dois exemplos mostra a diferença entre executar uma task ocupando uma thread de uma thread pool que é o SleepAsyncA
        //e o SleepAsyncB espera um timer sem ocupar uma thread o que traz uma escalabilidade
        //isso mostra que quando se fala de async e await, vc deve ter em mente que sua aplicação não irá ganhar performace e sim responsividade

        public static void Start() {
            SleepAsyncA(1000).Wait();
            Console.WriteLine(SleepAsyncB(1000).Result);
        }
        public static Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }
        public static Task<int> SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<int> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(40); }, null, -1, -1);
            tcs = new TaskCompletionSource<int>(t);
            t.Change(millisecondsTimeout, -1);
            return tcs.Task;
        }
    }
}
