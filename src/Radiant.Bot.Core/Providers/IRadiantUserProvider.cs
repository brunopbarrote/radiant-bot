using Radiant.Bot.Core.Entities;

namespace Radiant.Bot.Core.Providers
{
    public interface IRadiantUserProvider
    {
        RadiantUser GetById(ulong userId, ulong guildId);
        void StoreUser(RadiantUser u);
    }
}
