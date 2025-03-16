using Academy_2025.Data;
using Academy_2025.DTOs;

namespace Academy_2025.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User data);
        Task<bool> DeleteAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> GetOlderEightteenAsync();
        Task<int> UpdateAsync();

        Task<User?> GetByEmailAsync(string email);
    }
}
