using AutoMapper;
using CommandService.Dtos;
using CommandsService.Dtos;
using CommandsService.Models;

namespace CommandsService.Profiles
{
    public class CommandsProfile:Profile
{
    public CommandsProfile()
    {
        CreateMap<Platform,PlatformReadDto>();
        CreateMap<CommandCreateDto,Command>();
        CreateMap<Command,CommandReadDto>();
        CreateMap<PlatformPublishedDto,Platform>()
                    .ForMember(dest => dest.ExtarnalID, opt => opt.MapFrom(src=> src.Id));
    }
}
}