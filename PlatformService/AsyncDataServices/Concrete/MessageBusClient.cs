using Microsoft.Extensions.Configuration;
using PaltformService.Dtos;

namespace PlatformService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void PublishPlatform(PlatformPublishedDto platformPublishedDto)
        {
                
        }
    }
}