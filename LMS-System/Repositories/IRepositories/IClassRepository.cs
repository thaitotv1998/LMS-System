using LMS_System.Models;
using LMS_System.RepoCore;
using LMS_System.ViewModels;

namespace LMS_System.Repositories.IRepositories
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<List<ClassDTO>> GetAllClass();
        Task<ClassDTO?> GetClassById(string id);
        Task<ClassDTO?> GetClassByName(string name);
        Task<ClassDTO?> GetClassByYear(int year);
        Task AddNewClass(ClassDTO classDTO);
        Task UpdateClass(string oldClassId, ClassDTO newClass);
        Task DeleteClass(string classId);
    }
}
