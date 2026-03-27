using DealershipRun.AppHost.Exceptions;
using BCrypt.Net;


namespace DealershipRun.AppHost.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Delete(long id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null) { throw new NotFoundException($"user with id {id} not found"); }
            await _userRepository.Delete(id);
        }

        public async Task<UserEntity?> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null) { throw new NotFoundException($"user not found"); }
            return user;
        }

        public async Task<UserEntity?> GetById(long id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null) { throw new NotFoundException($"user not found"); }
            return user;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null) { throw new NotFoundException("User not found"); }
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) {
                throw new BadRequestException("Invalid password");
            }
            return "JWT_TOKEN_PLACEHOLDER";

        }

        public async Task<UserEntity> Register(UserEntity user,string password)
        {
            var existing = await _userRepository.GetByEmail(user.Email);
            if (existing != null) { throw new BadRequestException("Email already in use"); }
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            user.Role = Role.CUSTOMER;
            return await _userRepository.Register(user);
        }

        public async Task UpdateRole(long id, Role role)
        {
            var user = await _userRepository.GetById(id);
            if (user == null) { throw new NotFoundException($"user with id {id} not found"); }
            await _userRepository.UpdateRole(id, role);
        }
    }
}
