using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Radiant.Bot.Core.Discord;
using Radiant.Bot.Core.Entities;
using Radiant.Bot.Discord.Converter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Bot.Discord.Modules
{
    public class WarzoneCommand: BaseCommandModule
    {
        private readonly IDiscordMessages _discordMessages;

        private readonly EntityConverter _converter;
        public WarzoneCommand(EntityConverter converter, IDiscordMessages discordMessages)
        {
            _converter = converter;
            _discordMessages = discordMessages;
        }

        [Command("warzone")]
        public async Task ConfigureWarzone(CommandContext ctx, RadiantChannel warzoneChannel)
        {
            var channel = _converter.ConvertChannel(ctx.Channel);

            foreach(var user in ctx.Channel.Users)
            {
                _converter.ConvertUser(user);
            }

            await _discordMessages.SendMessage(channel, "olá mundo");
        }
    }
}
