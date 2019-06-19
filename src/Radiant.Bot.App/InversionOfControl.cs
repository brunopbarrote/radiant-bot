using Microsoft.Extensions.DependencyInjection;
using Radiant.Bot.Configuration;
using Radiant.Bot.Core.Configuration;
using Radiant.Bot.Core.Discord;
using Radiant.Bot.Core.Providers;
using Radiant.Bot.Core.Storage;
using Radiant.Bot.Discord;
using Radiant.Bot.Discord.Converter;
using Radiant.Bot.Storage;
using System;

namespace Radiant.Bot.App
{
    public static class InversionOfControl
    {
        private static ServiceProvider _provider;

        public static ServiceProvider Provider => GetOrInitProvider();

        private static ServiceProvider GetOrInitProvider()
        {
            if (_provider is null)
            {
                InitializeProvider();
            }

            return _provider;
        }

        private static void InitializeProvider()
            => _provider = new ServiceCollection()
                //.AddSingleton<ProfileService>()
                //.AddTransient<ILanguageResources, LanguageResources>()
                //.AddSingleton<IConfiguration, ConfigManager>()
                .AddSingleton<IBotConfiguration, BotConfiguration>()
                .AddSingleton<EntityConverter>()
                .AddSingleton<RadiantBot>()
                .AddSingleton<IDiscord>(s => s.GetRequiredService<RadiantBot>())
                .AddSingleton<IDiscordMessages>(s => s.GetRequiredService<RadiantBot>())
                .AddSingleton<IDataStorage, JsonDataStorage>()
                .AddSingleton<IRadiantUserProvider, RadiantUserProvider>()
                .BuildServiceProvider();
    }
}
