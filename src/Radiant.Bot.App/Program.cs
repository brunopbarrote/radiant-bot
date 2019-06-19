using Microsoft.Extensions.DependencyInjection;
using Radiant.Bot.Core;
using System.Threading.Tasks;

namespace Radiant.Bot.App
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            await ActivatorUtilities.CreateInstance<RadiantService>(InversionOfControl.Provider).RunAsync();
        }
    }
}
