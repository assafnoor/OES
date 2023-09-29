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
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(StudentDto dto)
        {
            var room = _unitOfWork.room.Find(n => n.Name == dto.room);
            if (room is null) { return BadRequest(); }
            var student = new Student { Name = dto.Name ,RoomId=room.Id};
            _unitOfWork.students.Add(student);
            _unitOfWork.complet();
            var data = _mapper.Map<StudentDetailsDto>(student);
            return Ok(data);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            string[] includes = { "room" };
            var result =await _unitOfWork.students.FindAllAsync(x => x.Id != 0, includes);
            var data = _mapper.Map<List<StudentDetailsDto>>(result);
            return Ok(data);

        }
        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            string[] includes = { "room" };
            var result = await _unitOfWork.students.FindAsync(x => x.Id == id, includes);
            var data = _mapper.Map<StudentDetailsDto>(result);
            return Ok(data);

        }
        [HttpPut("Update{id}")]
        public async Task<IActionResult> Update(int id,StudentDto dto)
        {
            var result = _unitOfWork.students.GetById(id);
            if (result == null) return NotFound();
            var room=_unitOfWork.room.Find(r=>r.Name==dto.room);
            if(room == null) return NotFound(); 
            result.Name = dto.Name;
            result.room = room;
            _unitOfWork.students.Update(result);
            _unitOfWork.complet();
            var data = _mapper.Map<StudentDetailsDto>(result);
            return Ok(data);
        }   
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delet(int id)
        {   
            var result = _unitOfWork.students.GetById(id);
            if (result == null) return NotFound();
            _unitOfWork.students.Delete(result);
            _unitOfWork.complet();
            var data = _mapper.Map<Student>(result);
            return Ok(data);
        }
    }
}
