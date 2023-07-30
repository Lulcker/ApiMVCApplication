using ApiMVCApplication.Models;

namespace ApiMVCApplication.Repositories
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User?> GetUserAsync(int id);

        Task CreateUser(User user);

        Task UpdateUser(User user);

        Task DeleteUser(int id);

        int CountAdmin { get; }
    }
}
