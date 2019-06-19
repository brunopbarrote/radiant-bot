using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.Entities;
using Radiant.Bot.Core.Entities;
using Radiant.Bot.Core.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Radiant.Bot.Discord.Converter
{
    public class RadiantUserConvertor : IArgumentConverter<RadiantUser>
    {
        private readonly DiscordMemberConverter _dmConverter;
        private readonly IRadiantUserProvider _userProvider;

        public RadiantUserConvertor(IRadiantUserProvider userProvider)
        {
            _dmConverter = new DiscordMemberConverter();
            _userProvider = userProvider;
        }

        public async Task<Optional<RadiantUser>> ConvertAsync(string userInput, CommandContext context)
        {
            var result = await _dmConverter.ConvertAsync(userInput, context);
            return DiscordMemberToMiunieUser(result.Value);
        }

        public RadiantUser DiscordMemberToMiunieUser(DiscordMember user)
        {
            var mUser = _userProvider.GetById(user.Id, user.Guild.Id);
            mUser.Name = user.Nickname ?? user.Username;
            _userProvider.StoreUser(mUser);
            return mUser;
        }
    }
}
