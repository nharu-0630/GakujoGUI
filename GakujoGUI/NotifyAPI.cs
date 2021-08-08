using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Todoist.Net;

namespace GakujoGUI
{
    class NotifyAPI
    {
        private DiscordSocketClient discordSocketClient;
        private ulong discordChannelId;
        private ITodoistClient todoistClient;

        public async void LoginDiscord(string token, ulong channel)
        {
            discordSocketClient = new DiscordSocketClient();
            await discordSocketClient.LoginAsync(TokenType.Bot, token);
            await discordSocketClient.StartAsync();
            discordChannelId = channel;
        }


        public async void NotifyDiscord(Embed embed)
        {
            await (discordSocketClient.GetChannel(discordChannelId) as IMessageChannel).SendMessageAsync("", false, embed);
        }

        public void LoginTodoist(string token)
        {
            todoistClient = new TodoistClient(token);
        }

        public async void AddTodoistTask(string message)
        {
            await todoistClient.Items.QuickAddAsync(new Todoist.Net.Models.QuickAddItem(message));
        }
    }
}
