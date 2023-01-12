using Microsoft.AspNetCore.SignalR;
using OrnekSignalR.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace OrnekSignalR.Hubs
{
    public class MyHub : Hub<IMessageClient>
    {
        static List<string> clients = new List<string>(); 
        public override async Task OnConnectedAsync()
        {
            //Connection ID
            //Hub'a baglanti gerceklestiren client'lara sistem tarafindan verilen, unique/ tekil bir degerdir.
            //Amaci, client'lari birbirlerinden ayirmaktir.
            clients.Add(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId); 
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.Clients(clients); 
            await Clients.All.UserLeaved(Context.ConnectionId);
        }
    }
}
