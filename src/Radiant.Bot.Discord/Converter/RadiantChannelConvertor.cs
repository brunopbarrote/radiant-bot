using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.Entities;
using Radiant.Bot.Core.Entities;
using System.Threading.Tasks;

namespace Radiant.Bot.Discord.Converter
{
    public class RadiantChannelConvertor : IArgumentConverter<RadiantChannel>
    {
        private readonly DiscordChannelConverter _dcConverter;

        public RadiantChannelConvertor()
        {
            _dcConverter = new DiscordChannelConverter();
        }

        public async Task<Optional<RadiantChannel>> ConvertAsync(string userInput, CommandContext context)
        {
            var result = await _dcConverter.ConvertAsync(userInput, context);
            return FromDiscordChannel(result.Value);
        }

        public static RadiantChannel FromDiscordChannel(DiscordChannel channel)
        {
            RadiantChannel miunieChannel;
            if (channel is default(DiscordChannel))
            {
                miunieChannel = default(RadiantChannel);
            }
            else
            {
                miunieChannel = new RadiantChannel()
                {
                    ChannelId = channel.Id,
                    GuildId = channel.GuildId
                };
            }
            return miunieChannel;
        }
    }
}
