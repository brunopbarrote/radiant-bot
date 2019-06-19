using Radiant.Bot.Core.Entities;
using Radiant.Bot.Core.Storage;

namespace Radiant.Bot.Core.Providers
{
    public class RadiantUserProvider : IRadiantUserProvider
    {
        private const string KeyFormat = "u{0}";
        private const string CollectionFormat = "g{0}";
        private readonly IDataStorage _dataStorage;

        public RadiantUserProvider(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public RadiantUser GetById(ulong userId, ulong guildId)
        {
            var user = _dataStorage.RestoreObject<RadiantUser>(
                GetCollectionById(guildId),
                GetKeyById(userId)
            );

            return EnsureExistence(user, userId, guildId);
        }

        public void StoreUser(RadiantUser u)
            => _dataStorage.StoreObject(u,
                GetCollectionById(u.GuildId),
                GetKeyById(u.Id));

        private RadiantUser EnsureExistence(
            RadiantUser user,
            ulong userId,
            ulong guildId)
        {
            if (user is null)
            {
                user = new RadiantUser
                {
                    GuildId = guildId,
                    Id = userId
                };
                StoreUser(user);
            }

            return user;
        }

        private static string GetKeyById(ulong userId)
            => string.Format(KeyFormat, userId);

        private static string GetCollectionById(ulong guildId)
            => string.Format(CollectionFormat, guildId);
    }
}
