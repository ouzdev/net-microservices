using System.Threading.Tasks;
using PlatformService.Dtos;

namespace PlatformService.SyncDataService.Http
{

    public interface ICommandDataClient
    {
        Task SendPaltformCommand(PlatformReadDto platform);
    }
}