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
    public class C_ExamsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public C_ExamsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("AddC_E")]
        public async Task<IActionResult> AddC_E([FromForm] C_ExamDto dto)
        {
            var course = _unitOfWork.Courses.Find(c => c.Name == dto.course);
            if (course is null) return BadRequest("course");
            var lecturer = _unitOfWork.Lecturers.Find(l => l.Name == dto.lecturer);
            if (lecturer is null) return BadRequest("lecturer");

            var c_exam = new C_Exam
            {
                Name = dto.name,
                no_Question = dto.no_Question,
                course = course,
                lecturer = lecturer,
                End = dto.End,
                Start = dto.Start,
                Time = dto.Time,
                Token = dto.Token,
            };
            _unitOfWork.c_e.Add(c_exam);
            _unitOfWork.complet();
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            string[] includes={ "lecturer", "course" };
           var result = _unitOfWork.c_e.FindAll(c=>c.Id!=0,includes);
            var data = _mapper.Map<List< C_ExamDetailsDto>>(result);
            return Ok(data);
        }
        [HttpGet("GetquestionforCE{id}")]
        public async Task<IActionResult> GetquestionforCE(int id)
        {
            string[] includes = { "lecturer", "course" };
            var result = _unitOfWork.c_e.Find(c => c.Id ==id, includes);
            var result1 = await _unitOfWork.Questions.FindAllAsync(q => q.LecturerId ==result.LecturerId&&q.CourseId==result.CourseId, includes);
            if (result1 == null) return NotFound();
            var data = _mapper.Map<List<QuestionDetailsDto>>(result1);
            return Ok(data);
        }

    }
}
