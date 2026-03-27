

namespace DealershipRun.AppHost.User
{
    public interface IUserRepository
    {
        Task<UserEntity> Register(UserEntity user);
        Task<UserEntity?> GetById(long id);
        Task<UserEntity?> GetByEmail(string email);
        Task Delete(long id);
        Task UpdateRole(long id, Role role);
    }
}
