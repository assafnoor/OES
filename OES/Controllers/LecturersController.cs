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
    public class LecturersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LecturersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(LecturerDto dto)
        {
            var course = await _unitOfWork.Courses.FindAsync(c => c.Name == dto.CourseName);
            if (course == null) return BadRequest();
            
            var data = new Lecturer { Name = dto.name ,CourseId=course.Id };
            _unitOfWork.Lecturers.Add(data);
            _unitOfWork.complet();
            var result = _mapper.Map<LecturerDetailsDto>(data);
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            
            var result =await _unitOfWork.Lecturers.GetAllAsync();
            var data = _mapper.Map<List<LecturerDetailsDto>>(result);
            return Ok(data);

        }
        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            
            var result = await _unitOfWork.Lecturers.GetByIdAsync(id);
            var data = _mapper.Map<LecturerDetailsDto>(result);
            return Ok(data);

        }
        [HttpPut("Update{id}")]
        public async Task<IActionResult> Update(int id,LecturerDto dto)
        {
            var result = _unitOfWork.Lecturers.GetById(id);
            if (result == null) return NotFound();
            result.Name = dto.name;
            _unitOfWork.Lecturers.Update(result);
            _unitOfWork.complet();
            return Ok(result);
        }   
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delet(int id)
        {   
            var result = _unitOfWork.Lecturers.GetById(id);
            if (result == null) return NotFound();
            _unitOfWork.Lecturers.Delete(result);
            _unitOfWork.complet();
            var data = _mapper.Map<LecturerDetailsDto>(result);
            return Ok(data);
        }
    }
}
