using Academy_2025.Data;
using Academy_2025.DTOs;

namespace Academy_2025.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserDto data);
        Task<bool> DeleteAsync(int id);
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<List<User>> GetOlderEightteenAsync();
        Task<UserDto?> UpdateAsync(int id, UserDto data);
    }
}
