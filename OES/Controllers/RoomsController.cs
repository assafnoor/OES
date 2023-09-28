using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OES.Core;
using OES.Core.Dto;
using OES.Core.Models;

namespace OES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoomsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(RoomDto dto)
        {
            var dept = _unitOfWork.Department.Find(n => n.Name == dto.Department);
            if (dept is null) { return BadRequest(); }
            var room = new Room { Name = dto.name, DepartmentId = dept.Id };
            _unitOfWork.room.Add(room);
            _unitOfWork.complet();

            var data = _mapper.Map<RoomDetailsDto>(room);
            return Ok(data);

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() {
            string[] includes = { "department" };
            //  var result=  _unitOfWork.room.GetAll();
            var result1 = await _unitOfWork.room.FindAllAsync(x => x.Id != 0, includes);
            var data = _mapper.Map<List<RoomDetailsDto>>(result1);
            return Ok(data);
        }
        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            string[] includes = { "department" };
            //var result = _unitOfWork.room.GetById(id);
            var result1 = await _unitOfWork.room.FindAsync(x => x.Id == id, includes);
            var data = _mapper.Map<RoomDetailsDto>(result1);
            return Ok(data);
        }
        [HttpPut("Update{id}")]
        public async Task<IActionResult> Update(int id, RoomDto dto)
        {
            var result = _unitOfWork.room.GetById(id);
            if (result == null) return NotFound();
            result.Name = dto.name;
            _unitOfWork.room.Update(result);
            _unitOfWork.complet();
            var data = _mapper.Map<RoomDetailsDto>(result);
            return Ok(data);
        }
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _unitOfWork.room.GetById(id);
            if (result == null) return NotFound();
            _unitOfWork.room.Delete(result);
            _unitOfWork.complet();
            var data = _mapper.Map<RoomDetailsDto>(result);
            return Ok(data);
        }
     
    }
}
