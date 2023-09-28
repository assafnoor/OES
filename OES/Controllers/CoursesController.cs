using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.Core;
using OES.Core.Dto;
using OES.Core.Models;

namespace OES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CoursesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CourseDto dto)
        {
            var data = new Course { Name = dto.name };
            _unitOfWork.Courses.Add(data);
            _unitOfWork.complet();
           var result = _mapper.Map<CourseDetailsDto>(data);
            return Ok(result);
        }
    
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            string[] includes = { "room" };
            var result =await _unitOfWork.Courses.GetAllAsync();
            var data = _mapper.Map<List<CourseDetailsDto>>(result);
            return Ok(data);

        }
        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            string[] includes = { "room" };
            var result = await _unitOfWork.Courses.GetByIdAsync(id);
            var data = _mapper.Map<CourseDetailsDto>(result);
            return Ok(data);

        }
        [HttpPut("Update{id}")]
        public async Task<IActionResult> Update(int id,CourseDto dto)
        {
            var result = _unitOfWork.Courses.GetById(id);
            if (result == null) return NotFound();
            result.Name = dto.name;
            _unitOfWork.Courses.Update(result);
            _unitOfWork.complet();
            return Ok(result);
        }   
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delet(int id)
        {   
            var result = _unitOfWork.Courses.GetById(id);
            if (result == null) return NotFound();
            _unitOfWork.Courses.Delete(result);
            _unitOfWork.complet();
            var data = _mapper.Map<CourseDetailsDto>(result);
            return Ok(data);
        }
    }
}
