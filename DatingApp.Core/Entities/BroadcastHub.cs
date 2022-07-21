using DatingApp.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace DatingApp.Core.Entities
{
    public class BroadcastHub : Hub<IHubClient>
    {
    }
}
