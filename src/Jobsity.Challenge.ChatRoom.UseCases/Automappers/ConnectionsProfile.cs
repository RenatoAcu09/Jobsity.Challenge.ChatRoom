using AutoMapper;
using Jobsity.Challenge.ChatRoom.Domain.Dtos;
using Jobsity.Challenge.ChatRoom.Domain.Entities;

namespace Jobsity.Challenge.ChatRoom.UseCases.Automappers
{
    public class ConnectionsProfile : Profile
    {
        public ConnectionsProfile()
        {
            CreateMap<NewUserDto, User>()
                    .ForMember(
                               d => d.ConnectionId,
                               opt => opt.Ignore());
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<ChatRoom.Domain.Entities.ChatRoom, ChatRoomDto>().ReverseMap();
            CreateMap<ChatMessageDto, ChatMessage>().ReverseMap();
        }
    }
}