using Radiant.Bot.Core.Entities;
using System.Threading.Tasks;

namespace Radiant.Bot.Core.Discord
{
    public interface IDiscordMessages
    {
        Task SendMessage(RadiantChannel targetChannel, string msg);
    }
}
