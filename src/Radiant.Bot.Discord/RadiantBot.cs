using DSharpPlus;
using Radiant.Bot.Core.Configuration;
using Radiant.Bot.Core.Discord;
using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using Radiant.Bot.Discord.Modules;
using Radiant.Bot.Core.Entities;
using Radiant.Bot.Discord.Converter;

namespace Radiant.Bot.Discord
{
    public class RadiantBot : IDiscord, IDiscordMessages
    {
        private readonly IBotConfiguration _configuration;
        private readonly IServiceProvider _services;
        private DiscordClient _discordClient;
        private readonly EntityConverter _entityConverter;
        private CommandsNextExtension _commandService;

        public RadiantBot(IBotConfiguration configuration, IServiceProvider services, EntityConverter entityConverter)
        {
            _configuration = configuration;
            _services = services;
            _entityConverter = entityConverter;
        }
        public async Task RunAsync()
        {
            await InitializeBot();
            InitializeCommandService();
            await Task.Delay(-1);
        }

        private void InitializeCommandService()
        {
            var config = GetDefaultCommandsNextConfiguration();
            _commandService = _discordClient.UseCommandsNext(config);
            _commandService.RegisterCommands<WarzoneCommand>();
            RegisterConvertors();
        }

        private void RegisterConvertors()
        {
            _commandService.RegisterConverter(_entityConverter.ChannelConvertor);
            _commandService.RegisterConverter(_entityConverter.UserConvertor);
        }

        private async Task InitializeBot()
        {
            var config = GetBotConfiguration();
            _discordClient = new DiscordClient(config);
            await _discordClient.ConnectAsync();
        }
     
        private DiscordConfiguration GetBotConfiguration()
        {
            return new DiscordConfiguration()
            {
                Token = _configuration.GetBotToken(),
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Info,
                UseInternalLogHandler = true
            };
        }

        private CommandsNextConfiguration GetDefaultCommandsNextConfiguration()
        {
            return new CommandsNextConfiguration()
            {
                EnableMentionPrefix = true,
                Services = _services
            };
        }

        public async Task SendMessage(RadiantChannel targetChannel, string msg)
        {
            var channel = await _discordClient.GetChannelAsync(targetChannel.ChannelId);
            await channel.SendMessageAsync(msg);
        }
    }
}
