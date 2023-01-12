﻿using Microsoft.AspNetCore.SignalR;
using OrnekSignalR.Hubs;
using System.Threading.Tasks;

namespace OrnekSignalR.Business
{
    public class MyBusiness
    {
        readonly IHubContext<MyHub> _hubContext;
        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task SendMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
