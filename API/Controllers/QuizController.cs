using API.DTOs;
using Core.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DTOs;

namespace API.Controllers
{
    [Route("api/quiz")]
    public class QuizController: Controller
    {

        private readonly AppDbContext dbContext;

        public QuizController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        [HttpGet("{placeId}")]
        public async Task<IActionResult> getQuizByPlaceId([FromRoute] Guid placeId)
        {
            var quiz = await dbContext.Quizzes
                .FirstOrDefaultAsync(q => q.PlaceId == placeId);
            if (quiz == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No quiz found for this place");
            }

            var questions = await dbContext.QuizQuestions.Where(q => q.QuizId == quiz.Id).ToListAsync();

            var QuizDto = new QuizDTO
            {
                Id = quiz.Id,
                Questions = (questions.Select(qs =>
                new QuizQuestionDTO() {
                    Id = qs.Id,
                    Text = qs.Title,
                    Options = qs.AnswerOptions,
                    CorrectAnswer = qs.CorrectAnswer,
                    Time = qs.Time,
                    Points = qs.Points,

                }).ToList()),
                
            };

            return Json(QuizDto);
        }

        [HttpPost("result")]
        public async Task<IActionResult> UpdateQuizResults ([FromBody] QuizResultInputDTO quizResult)
        {
            if (quizResult == null)
            {
                return BadRequest();
            }

            try
            {
                var user = await dbContext.Users
                    .FirstOrDefaultAsync(u => u.Id.Equals(quizResult.userId));


                user.Score += quizResult.score;
                dbContext.Update(user);
                dbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
