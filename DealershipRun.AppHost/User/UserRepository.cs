
using DealershipRun.AppHost.Data;
using Microsoft.EntityFrameworkCore;

namespace DealershipRun.AppHost.User
{
    public class UserRepository :IUserRepository
    {
        private readonly DealershipRunDBcontext _context;

        public UserRepository(DealershipRunDBcontext context)
        {
            _context = context;
        }

        public async Task Delete(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null) {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UserEntity?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserEntity?> GetById(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        

        public async Task<UserEntity> Register(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateRole(long id, Role role)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null) {
                user.Role = role;
                await _context.SaveChangesAsync();
            }
        }
    }
}
