using Academy_2025.Data;
using Academy_2025.DTOs;
using Academy_2025.Repositories;

namespace Academy_2025.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository=userRepository;
        }

        public Task CreateAsync(UserDto data)
        => _userRepository.CreateAsync(MapToModel(data));

        public Task<bool> DeleteAsync(int id)
        => _userRepository.DeleteAsync(id);

        public async Task<List<UserDto>> GetAllAsync()
        {
           var users= await _userRepository.GetAllAsync();
            return users.Select(MapToDto).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
           var user=await _userRepository.GetByIdAsync(id);
            return user != null ? MapToDto(user) : null;
        }

        public Task<List<User>> GetOlderEightteenAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto?> UpdateAsync(int id, UserDto data)
        {
           var user = await _userRepository.GetByIdAsync(id);
            if (user!=null)
            {
               user.Name = data.Name;
                await _userRepository.UpdateAsync();
            }
            return user != null ? MapToDto(user) :null;
        }

        private static UserDto MapToDto(User user) => new()
        {
            Id = user.Id,
            Name=user.Name,
            Email=user.Email,
            Password=user.Password
        };

        private static User MapToModel(UserDto userDto) => new()
        {
            Id = userDto.Id,
            Name = userDto.Name,
            Email=userDto.Email,
            Password=userDto.Password
        };

    }
}
