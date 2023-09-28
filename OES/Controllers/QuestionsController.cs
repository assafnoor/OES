using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OES.Core;
using OES.Core.Dto;
using OES.Core.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuestionsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(QuestionDto dto)
        {
            var lecturer = await _unitOfWork.Lecturers.FindAsync(l => l.Name == dto.lecturer);
            if (lecturer == null) return BadRequest();
            var course = await _unitOfWork.Courses.FindAsync(c => c.Name == dto.course);
            if (course == null) return BadRequest();
            var data = new Question
            {
                ques = dto.ques,
                Mark = dto.Mark,
                ans1 = dto.ans1,
                ans2 = dto.ans2,
                ans3 = dto.ans3,
                ans4 = dto.ans4,
                correctAns = dto.correctAns,
                Crerate = DateTime.Now,
                LecturerId = lecturer.Id,
                CourseId = course.Id,
            };
            data.LecturerId = lecturer.Id;
            data.CourseId = course.Id;
            _unitOfWork.Questions.Add(data);
            _unitOfWork.complet();
            var res = _mapper.Map<QuestionDetailsDto>(data);
            return Ok(res);

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            string[] includes = { "lecturer", "course" };
            var result =await _unitOfWork.Questions.FindAllAsync(q=>q.Id!=0, includes);
            var data = _mapper.Map<List<QuestionDetailsDto>>(result);
            return Ok(data);

        }
        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            string[] includes = { "lecturer", "course" };
            var result = await _unitOfWork.Questions.FindAsync(q=>q.Id==id,includes);
            if (result == null) return NotFound();
            var data = _mapper.Map<QuestionDetailsDto>(result);
            return Ok(data);

        }
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delet(int id)
        {   
            var result = _unitOfWork.Questions.GetById(id);
            if (result == null) return NotFound();
            _unitOfWork.Questions.Delete(result);
            _unitOfWork.complet();
            var data = _mapper.Map<QuestionDetailsDto>(result);
            return Ok(data);
        }
    }
}
