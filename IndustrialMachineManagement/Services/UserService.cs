using IndustrialMachineManagement.Models;

namespace IndustrialMachineManagement.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new();

        public UserService()
        {
            // Add sample user
            _users.Add(new User
            {
                Id = Guid.NewGuid(),
                Username = "Manager",
                Email = "manager@example.com",
                Role = "Admin"
            });
        }

        public async Task<List<User>> GetAllUsersAsync() =>
            await Task.FromResult(_users);

        public async Task<User?> GetUserByIdAsync(Guid id) =>
            await Task.FromResult(_users.FirstOrDefault(u => u.Id == id));

        public async Task<User> AddUserAsync(User user)
        {
            user.Id = Guid.NewGuid();
            _users.Add(user);
            return await Task.FromResult(user);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var index = _users.FindIndex(u => u.Id == user.Id);
            if (index != -1)
            {
                _users[index] = user;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
