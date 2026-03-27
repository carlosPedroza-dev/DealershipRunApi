

namespace DealershipRun.AppHost.User
{
    public interface IUserService
    {
        Task<UserEntity> Register(UserEntity user,string password);
        Task<string> Login(string email, string password);
        Task<UserEntity?> GetById(long id);
        Task<UserEntity?> GetByEmail(string email);
        Task Delete(long id);
        Task UpdateRole(long id, Role role);
    }
}
