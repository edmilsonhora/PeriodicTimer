using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_PeriodicTimer
{
    public class Operacao
    {
        Task timerTask;
        PeriodicTimer timer;
        CancellationTokenSource cts = new CancellationTokenSource();

        public Operacao(TimeSpan intervalo)
        {
            timer = new PeriodicTimer(intervalo); 
        }

        public void Start()
        {
            Console.Clear();
            timerTask = DoWorkAsyns();
        }

        private async Task DoWorkAsyns()
        {
            try
            {
                while (await timer.WaitForNextTickAsync(cts.Token))
                {
                   await SubMetodo();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task SubMetodo()
        {
            await Task.Delay(900);
            Console.WriteLine(DateTime.Now.ToString("O"));
            
        }

        public async void StopAsync()
        {
            if (timerTask == null) return;
            cts.Cancel();
            await timerTask;
            cts.Dispose();
            Console.WriteLine("Operação foi cancelada");
            Console.Clear();
        }

    }
}
