using DSharpPlus.Entities;
using Radiant.Bot.Core.Entities;
using Radiant.Bot.Core.Providers;

namespace Radiant.Bot.Discord.Converter
{
    public class EntityConverter
    {
        public RadiantChannelConvertor ChannelConvertor { get; }
        public RadiantUserConvertor UserConvertor { get; }

        public EntityConverter(IRadiantUserProvider miunieUserProvider)
        {
            ChannelConvertor = new RadiantChannelConvertor();
            UserConvertor = new RadiantUserConvertor(miunieUserProvider);
        }

        public RadiantUser ConvertUser(DiscordMember m) => UserConvertor.DiscordMemberToMiunieUser(m);

        public RadiantChannel ConvertChannel(DiscordChannel c) => RadiantChannelConvertor.FromDiscordChannel(c);
    }
}
