using AutoMapper;
using LMS_System.Context;
using LMS_System.Models;
using LMS_System.RepoCore;
using LMS_System.Repositories.IRepositories;
using LMS_System.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Xml.Linq;

namespace LMS_System.Repositories
{
    public class ClassRepository : RepositoyBase<Class>, IClassRepository
    {
        private readonly IMapper _mapper;
        //private readonly ApplicationDbContext _context;

        public ClassRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            //_context = context;
        }

        public async Task AddNewClass(ClassDTO classDTO)
        {
            var newClass = _mapper.Map<Class>(classDTO);
            await Add(newClass);
        }

        public async Task DeleteClass(string id)
        {
            var deletedClass = await _dbSet.FindAsync(id);
            if(deletedClass != null)
            {
                await Delete(deletedClass);
            }
        }

        public async Task<List<ClassDTO>> GetAllClass()
        {
            var allClass = await GetAll();
            return _mapper.Map<List<ClassDTO>>(allClass);
        }

        public async Task<ClassDTO?> GetClassById(string id)
        {
            var checkClass = await _dbSet.FindAsync(id);
            return _mapper.Map<ClassDTO>(checkClass);
        }

        public async Task<ClassDTO?> GetClassByName(string name)
        {
            var checkClass = await _dbSet.FirstOrDefaultAsync(c => c.ClassName == name);
            return _mapper.Map<ClassDTO>(checkClass);
        }

        public async Task<ClassDTO?> GetClassByYear(int year)
        {
            var checkClass = await _dbSet.FirstOrDefaultAsync(c => c.SchoolYear == year);
            return _mapper.Map<ClassDTO>(checkClass);
        }

        public async Task UpdateClass(string oldClassId, ClassDTO newClass)
        {
            var checkClass = await _dbSet.FirstOrDefaultAsync(c => c.ClassId == oldClassId);
            _mapper.Map(newClass, checkClass);
            if (checkClass != null)
            {
                await Update(checkClass);
            }
        }
    }
}
