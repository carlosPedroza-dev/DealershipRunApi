

namespace DealershipRun.AppHost.User
{
    public interface IUserService
    {
        Task<UserEntity> Register(UserEntity user);
        Task Login(string username, string password);
        Task<UserEntity?> GetById(long id);
        Task<UserEntity?> GetByEmail(string email);
        Task Delete(long id);
        Task UpdateRole(long id, Role role);
    }
}
