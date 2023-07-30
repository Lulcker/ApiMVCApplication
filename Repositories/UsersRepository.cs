using ApiMVCApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMVCApplication.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationContext _db;
        public UsersRepository(ApplicationContext db) 
        { 
            _db = db;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _db.Users
                .Include(g => g.UserGroup)
                .Include(s => s.UserState)
                .OrderBy(s => s.Id)
                .ToListAsync();
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await _db.Users
                .Include(g => g.UserGroup)
                .Include(s => s.UserState)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task CreateUser(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            user.UserStateId = 2;
            await _db.SaveChangesAsync();
        }

        public int CountAdmin => _db.Users.Count(u => u.UserGroupId == 1 && u.UserStateId != 2);
    }
}
