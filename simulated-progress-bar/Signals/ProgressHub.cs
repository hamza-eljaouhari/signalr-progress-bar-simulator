using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace simulated_progress_bar.Signals
{

    public class ProgressHub : Hub
    {
        public async Task StartTask()
        {
            Random rnd = new Random();
            int taskDuration = rnd.Next(10, 40); // Duration in seconds (40 to 120)
            int elapsed = 0;

            while (elapsed < taskDuration)
            {
                await Task.Delay(1000); // Wait for 1 second
                elapsed++;
                int progress = (int)((float)elapsed / taskDuration * 100);
                await Clients.Caller.SendAsync("ReceiveProgress", progress);
            }
        }
    }

}

