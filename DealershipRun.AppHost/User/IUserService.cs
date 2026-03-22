

namespace DealershipRun.AppHost.User
{
    public interface IUserService
    {
        Task register(UserEntity user);
        Task Login(string username, string password);
        Task<UserEntity> getById(long id);
        Task delete(long id);
        Task updateRole(long id, Role role);
    }
}
