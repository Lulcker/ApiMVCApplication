using ApiMVCApplication.Models;

namespace ApiMVCApplication.Repositories
{
    public interface IUsersRepository
    {
        Task<IndexViewModel> GetUsersAsync(int count, int page, int pageSize = 5);

        Task<User?> GetUserAsync(int id);

        Task CreateUser(User user);

        Task UpdateUser(User user);

        Task DeleteUser(int id);

        int CountAdmin { get; }

        int TotalCount { get; }
    }
}
