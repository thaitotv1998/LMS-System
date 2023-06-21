using LMS_System.Models;
using LMS_System.RepoCore;
using LMS_System.ViewModels;

namespace LMS_System.Repositories.IRepositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<List<RoleDTO>> GetAllRole();
        Task<RoleDTO> GetRoleById(Guid id);
        Task<RoleDTO> GetRoleByName(string name);
        Task AddRole(RoleDTO role);
        Task UpdateRole(string oldRole, RoleDTO role);
        Task DeleteRole(Guid id);
    }
}
