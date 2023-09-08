using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.Core;
using OES.Core.Dto;
using OES.Core.Models;

namespace OES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(DeptDto dto)
        {
            var dept = new Department { Name = dto.name };
            _unitOfWork.dept.Add(dept);
            _unitOfWork.complet();
            return Ok(dept);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
          var result =  _unitOfWork.dept.GetAll();
            if (result is null) return Ok("no dept");
            return Ok(result);
        }
        [HttpGet("GetAll{id}")]
        public async Task<IActionResult> GetAllById(int id)
        {
            var result = _unitOfWork.dept.GetById(id);
            if (result is null) return Ok("no dept");
            return Ok(result);
        }
        [HttpPut("Update{id}")]
        public async Task<IActionResult> Update(int id,DeptDto dto)
        {
            var result = _unitOfWork.dept.GetById(id);
            if (result is null) return BadRequest();
            result.Name= dto.name;
            _unitOfWork.dept.Update(result);
            _unitOfWork.complet();
            return Ok(result);
        }
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _unitOfWork.dept.GetById(id);
            if (result is null) return BadRequest();
            _unitOfWork.dept.Delete(result);
            _unitOfWork.complet();
            return Ok(result);
        }
    }
}
