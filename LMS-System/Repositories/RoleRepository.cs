using AutoMapper;
using LMS_System.Context;
using LMS_System.Models;
using LMS_System.RepoCore;
using LMS_System.Repositories.IRepositories;
using LMS_System.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LMS_System.Repositories
{
    public class RoleRepository : RepositoyBase<Role>, IRoleRepository
    {
        private readonly IMapper _mapper;

        public RoleRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task AddRole(RoleDTO role)
        {
            role.RoleId = Guid.NewGuid();
            var newRole = _mapper.Map<Role>(role);
            await Add(newRole);
        }

        public async Task DeleteRole(Guid id)
        {
            var deleteRole = await _dbSet.FindAsync(id);
            if (deleteRole != null)
            {
                await Delete(deleteRole);
            }
        }

        public async Task<List<RoleDTO>> GetAllRole()
        {
            var allRoles = await GetAll();
            return _mapper.Map<List<RoleDTO>>(allRoles);
        }

        public async Task<RoleDTO> GetRoleById(Guid id)
        {
            var role = await _dbSet.FindAsync(id);
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task<RoleDTO> GetRoleByName(string name)
        {
            var role = await _dbSet.FirstOrDefaultAsync(r => r.RoleName == name);
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task UpdateRole(string oldRole, RoleDTO role)
        {
            var checkRole = await _dbSet.FirstOrDefaultAsync(r => r.RoleName == oldRole);
            if (checkRole != null)
            {
                var updateRole = _mapper.Map<Role>(role);
                await Update(updateRole);
            }
        }
    }
}
