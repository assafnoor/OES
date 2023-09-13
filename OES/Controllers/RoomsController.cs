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
            if(dept is null) { return BadRequest(); }
            var room = new Room {Name =dto.name,DepartmentId=dept.Id };
            _unitOfWork.room.Add(room);
            _unitOfWork.complet();
            var data = _mapper.Map<RoomDetailsDto>(room);
            return Ok(data);
            
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() {
          var result=  _unitOfWork.room.GetAll();
            return Ok(result);
        }
        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = _unitOfWork.room.GetById(id);
            return Ok(result);
        }
     
    }
}
