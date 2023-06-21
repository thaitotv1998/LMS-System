using AutoMapper;
using LMS_System.Models;
using LMS_System.ViewModels;

namespace LMS_System.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
