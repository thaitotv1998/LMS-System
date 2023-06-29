using LMS_System.Models;
using LMS_System.RepoCore;
using LMS_System.ViewModels;

namespace LMS_System.Repositories.IRepositories
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        Task<List<UserAccountDTO>> GetAllUser();
        Task<UserAccountDTO> GetUserById(Guid id);
        Task<UserAccountDTO> GetUserByName(string name);
        Task<UserAccountDTO> GetUserByEmail(string email);
        Task<UserAccountDTO> GetUserRoleById(Guid id);
        //Task AddUser(UserAccountDTO user);
        Task UpdateUser(UserAccountDTO oldUser, UserAccountDTO newUser);
        Task DeleteUser(Guid id);
    }
}
