using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace SecretChatRelay
{
    public class ChatRelayHub : Hub
    { 
        public static ConcurrentDictionary<string, string> users;
        public static ConcurrentDictionary<string, string> pubKeys;

        static ChatRelayHub()
        {
            users = new ConcurrentDictionary<string, string>();
            pubKeys = new ConcurrentDictionary<string, string>();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var caller = Context.ConnectionId;
            var user = users.FirstOrDefault(pair => pair.Value == caller);

            if (!string.IsNullOrEmpty(user.Key))
            {
                Logout(user.Key).Wait();
            }
            
            return base.OnDisconnectedAsync(exception);
        }

        public async Task Login(string user, string pubKey)
        {
            var loginResult = users.TryAdd(user, Context.ConnectionId);
            await Clients.Caller.SendAsync("LoginResult", loginResult);

            if (loginResult)
            {
                pubKeys.TryAdd(user, pubKey);
                await BroadcastNewUser(user);
            }
        }

        public async Task Logout(string user)
        {
            Console.WriteLine("USER TRIED LOGOUT: {0}", user);
            var logoutResult = users.TryRemove(user, out _) && pubKeys.TryRemove(user, out _);
            
            if (logoutResult) {
                await Clients.Caller.SendAsync("LogoutResult", logoutResult);
                await BroadcastUserOut(user);
            }
        }

        public async Task BroadcastNewUser(string user)
        {
            Console.WriteLine("USER LOGIN : {0}", user);
            await Clients.All.SendAsync("BroadcastNewUser", user);
        }

        public async Task BroadcastUserOut(string user)
            => await Clients.All.SendAsync("BroadcastUserOut", user);

        public async Task RequestUserList()
            => await Clients.Caller.SendAsync("CurrentUserList", users.Keys.Select(k => k + ":" + pubKeys[k]).ToList());

        public async Task SendMessage(string message)
        {
            var caller = Context.ConnectionId;
            var user = users.FirstOrDefault(pair => pair.Value == caller);

            if (user.Equals(default))
                return;

            await Clients.All.SendAsync("MessageBroadcast", user.Key, message);
            Console.WriteLine("{0}: {1}", user.Key, message);    
        }

        public async Task CommonKeyExchange(string from, string user, string pubKey)
            => await Clients.Client(users[user]).SendAsync("CommonKeyExchange", from, pubKey);

        public async Task CommonKeyExchangeResponse(string from, string user, string response)
            => await Clients.Client(users[user]).SendAsync("CommonKeyExchangeResponse", from, response);

        public async Task PublicKeyExchange(string user)
            => await Clients.Client(users[user]).SendAsync("PublicKeyExchange", user);

        public async Task PublicKeyExchangeResponse(string user)
            => await Clients.Client(users[user]).SendAsync("PublicKeyExchangeResponse", user);

    }
}
