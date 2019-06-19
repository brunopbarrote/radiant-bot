using Radiant.Bot.Core.Discord;
using System.Threading.Tasks;

namespace Radiant.Bot.Core
{
    public class RadiantService
    {
        private readonly IDiscord _discord;

        public RadiantService(IDiscord discord)
        {
            _discord = discord;
        }

        public async Task RunAsync()
        {
            await _discord.RunAsync();
        }
    }
}
