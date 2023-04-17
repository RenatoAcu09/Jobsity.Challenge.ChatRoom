using AutoMapper;
using Jobsity.Challenge.ChatRoom.Domain.Dtos;
using Jobsity.Challenge.ChatRoom.Interfaces.Repositories;
using Jobsity.Challenge.ChatRoom.Interfaces.UseCases;

namespace Jobsity.Challenge.ChatRoom.UseCases.Services
{
    public class GetUserUseCase : IGetUserUseCase
    {
        private readonly IMapper _mapper;

        private readonly IUserConnectionRepository _userConnectionRepository;

        public GetUserUseCase(
                              IUserConnectionRepository userConnectionRepository,
                              IMapper mapper)
        {
            _userConnectionRepository = userConnectionRepository ?? throw new ArgumentNullException(nameof(userConnectionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserDto> GetUserByConnectionId(string connectionId)
        {
            var user = await _userConnectionRepository.GetUserByConnectionId(connectionId);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await _userConnectionRepository.GetUser(id);
            return _mapper.Map<UserDto>(user);
        }
    }
}