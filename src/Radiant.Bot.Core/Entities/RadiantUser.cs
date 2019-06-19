using System.Collections.Generic;

namespace Radiant.Bot.Core.Entities
{
    public class RadiantUser
    {
        public string Name { get; set; }
        public ulong GuildId { get; set; }
        public ulong Id { get; set; }
        public List<ulong> NavCursor { get; set; }

        public RadiantUser()
        {
            NavCursor = new List<ulong>();
        }
    }
}
