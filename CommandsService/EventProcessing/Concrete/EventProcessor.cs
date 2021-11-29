using System;
using System.Text.Json;
using AutoMapper;
using CommandService.Data.Abstract;
using CommandService.Dtos;
using CommandService.EventProcessing;
using CommandsService.Dtos;
using CommandsService.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CommandsService.EventProcessing
{
    public class EventProcessor : IEventProcessing
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.PlatformPublished:
                    // To Do
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine("--> Determining EventType: " + notificationMessage);

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

            switch (eventType.Event)
            {
                case "Platform_Published":
                    Console.WriteLine("--> Platform Published Event Detected");
                    return EventType.PlatformPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void AddPlatform(string platformPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                 var repo = scope.ServiceProvider.GetRequiredService<ICommandRepo>();

                 var platformPubishedDto = JsonSerializer.Deserialize<PlatformPublishedDto>(platformPublishedMessage);

                try
                {
                     var platform = _mapper.Map<Platform>(platformPubishedDto);

                     if (!repo.ExtarnalPlatformExists(platform.ExtarnalID))
                     {
                         repo.CreatePlatform(platform);
                         repo.SaveChanges();
                     }
                     else{
                         Console.WriteLine("--> Paltform already exists");
                     }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Platform to database {ex.Message}");
                }
            }
        }

    }
    enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}