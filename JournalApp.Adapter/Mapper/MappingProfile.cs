using AutoMapper;
using JournalApp.Contracts;
using JournalApp.Domain.Journal;
using JournalApp.Domain.User;

namespace JournalApp.Adapter.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Journal, JournalDto>();
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<JournalDto, Journal>()
            .ForMember(dest => dest.User, opt => opt.Ignore()); // Ignore User mapping to avoid circular reference
    }
}