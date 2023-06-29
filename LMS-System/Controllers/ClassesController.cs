using LMS_System.Models;
using LMS_System.Repositories.IRepositories;
using LMS_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LMS_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassRepository _classRepository;

        public ClassesController(IClassRepository classRepository) 
        {
            _classRepository = classRepository;
        }
        // GET: api/<ClassesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDTO>>> GetAllClass() => await _classRepository.GetAllClass();

        // GET api/<ClassesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetClassById(string id)
        {
            var findClass = await _classRepository.GetClassById(id);
            if(findClass == null)
            {
                return NotFound("Class not found");
            }
            return Ok(findClass);
        }

        [HttpGet("name")]
        public async Task<ActionResult> GetClassByName(string name)
        {
            var findClass = await _classRepository.GetClassByName(name);
            if (findClass == null)
            {
                return NotFound("Class not found");
            }
            return Ok(findClass);
        }

        // POST api/<ClassesController>
        [HttpPost]
        public async Task<ActionResult<Class>> AddNewClass(ClassDTO addClass)
        {
            var checkClass = await _classRepository.GetClassById(addClass.ClassId);
            if(checkClass != null)
            {
                return BadRequest("Class already exists!");
            }
            await _classRepository.AddNewClass(addClass);
            return Ok(addClass);
        }

        // PUT api/<ClassesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClass(string oldClassId, ClassDTO newClass)
        {
            var checkClass = await _classRepository.GetClassById(oldClassId);
            if(checkClass == null)
            {
                return NotFound("Class not found");
            }
            await _classRepository.UpdateClass(oldClassId, newClass);
            return Ok(new
            {
                Message = "Update successfully",
                newClass
            });
        }

        // DELETE api/<ClassesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(string id)
        {
            var deleteClass = await _classRepository.GetClassById(id);
            if(deleteClass == null)
            {
                return NotFound("Class not found");
            }
            await _classRepository.DeleteClass(id);
            return Ok("Class deleted!");
        }
    }
}
