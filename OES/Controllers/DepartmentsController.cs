using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OES.Core;
using OES.Core.Dto;
using OES.Core.Interfaces;
using OES.Core.Models;
using OES.EF.Repositories;
using System.Linq;

namespace OES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public DepartmentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(DeptDto dto)
        {
            var dept = new Department { Name = dto.name };
            _unitOfWork.dept.Add(dept);
            _unitOfWork.complet();
            return Ok(dept);
        }
        [HttpPost("AddRoomToDept")]
        public async Task<IActionResult> AddRoomToDept(DeptDto dto)
        {
            string[] inlude = { "course_departments", "rooms" };
            var dept = _unitOfWork.Department.Find(d => d.Name == dto.name, inlude);
            if (dept == null) { return NotFound("dept"); }
            var room = _unitOfWork.room.Find(d => d.Name == dto.RoomName);
            if (room == null) { return NotFound("room"); }
            //foreach (var d in dept.rooms)
            //{
            //    if (d.Name == dto.RoomName) return BadRequest(" alread added");
            //}
            var dr = dept.rooms.FirstOrDefault(c => c.Name == dto.RoomName);
            if (dr != null) return BadRequest(" alredy added");

           // dept.rooms.FirstOrDefault(room => room.Name == dto.RoomName);
            dept.rooms.Add(room);
            _unitOfWork.complet();
            var result = _unitOfWork.dept.GetByIdDeptWitheDetails(dept.Id);
            var data = _mapper.Map<List<DeptDetailsDto>>(result);
            return Ok(data);

        }
        [HttpDelete("DeleteRoomToDept")]
        public async Task<IActionResult> DeleteRoomToDept(DeptDto dto)
        {
            string[] inlude = { "course_departments", "rooms" };
            var dept = _unitOfWork.Department.Find(d => d.Name == dto.name, inlude);
            if (dept == null) { return NotFound(); }
            var room = _unitOfWork.room.Find(d => d.Name == dto.RoomName);
            if (room == null) { return NotFound(); }

            var dr = dept.rooms.FirstOrDefault(c => c.Name == dto.RoomName);
            if (dr==null) return BadRequest(" no Room");
            dept.rooms.Remove(room);
            _unitOfWork.complet();
            var result = _unitOfWork.dept.GetByIdDeptWitheDetails(dept.Id);
            var data = _mapper.Map<List<DeptDetailsDto>>(result);
            return Ok(data);

        }

        [HttpPost("AddCoursetoDept")]
        public async Task<IActionResult> AddCourseFromDept(DeptDto dto)
        {
            string[] inlude = { "course_departments" , "rooms" };
            var dept = _unitOfWork.Department.Find(d => d.Name == dto.name, inlude);
            if (dept == null) { return NotFound(); }
            var course = await _unitOfWork.Courses.FindAsync(c => c.Name == dto.CourseName);
            if (course == null) return NotFound("course not found");

            var bo = _unitOfWork.dept.isEnrolled(dto, dept, course);
            if (bo)
            {
                return BadRequest();
            }
            var cd = new Course_Department
            {
                courses = course,
                departments = dept
            };
            dept.course_departments.Add(cd);
            _unitOfWork.complet();

            var result = _unitOfWork.dept.GetByIdDeptWitheDetails(dept.Id);
            var data = _mapper.Map<List<DeptDetailsDto>>(result);
            return Ok(data);
            
        }
        [HttpDelete("DeleteCourseFromoDept")]
        public async Task<IActionResult> DeleteCourseFromoDept(DeptDto dto)
        {
            string[] inlude = { "course_departments", "rooms" };
            var dept = _unitOfWork.Department.Find(d => d.Name == dto.name, inlude);
            if (dept == null) { return NotFound("dept not found"); }
            var course = await _unitOfWork.Courses.FindAsync(c => c.Name == dto.CourseName);
            if (course == null) return NotFound("course not found");

         
            var courseDepartmentToRemove = dept.course_departments.FirstOrDefault(cd => cd.courses == course);

            //if (courseDepartmentToRemove != null)
            //{
            //    // Remove the course from the course_departments collection
            //    dept.course_departments.Remove(courseDepartmentToRemove);

            //    // Save changes to the database
            //    _unitOfWork.complet();
            //}

            if (courseDepartmentToRemove == null) return BadRequest();
             dept.course_departments.Remove(courseDepartmentToRemove);
            _unitOfWork.complet();
            var result = _unitOfWork.dept.GetByIdDeptWitheDetails(dept.Id);
            var data = _mapper.Map<List<DeptDetailsDto>>(result);
            return Ok(data);

        }

        [HttpGet("GetAllDeptWitheDetails")]
        public async Task<IActionResult> GetAllDeptWitheDetails()
        {
            string[] include = { "course_departments", "rooms" };
            var result = _unitOfWork.dept.GetAllDeptWitheDetails();
            var data = _mapper.Map<List<DeptDetailsDto>>(result);
            return Ok(data);

        }
        [HttpGet("GetByIdDeptWitheDetails{id}")]
        public async Task<IActionResult> GetByIdDeptWitheDetails(int id)
        {
            string[] include = { "course_departments", "rooms" };
            var result = _unitOfWork.dept.GetByIdDeptWitheDetails(id);
            var data = _mapper.Map<List< DeptDetailsDto> >(result);
            return Ok(data);
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
            if (result is null) return BadRequest("no dept");
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
