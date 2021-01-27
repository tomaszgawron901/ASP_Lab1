using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_PROJECT.Hubs
{
    
    public class CounterHub: Hub
    {
        private static int connections = 0;

        public CounterHub():base()
        {
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            connections++;
            await Clients.All.SendAsync("ConnectionsChange", connections);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
            connections--;
            await Clients.All.SendAsync("ConnectionsChange", connections);
        }
    }

}
