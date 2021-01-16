using API.DTOs;
using Core.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/leaderboard")]
    public class LeaderboardController : Controller
    {

        private readonly AppDbContext dbContext;

        public LeaderboardController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
        [HttpGet("")]
        public async Task<IActionResult> getLeaderboard()
        {
            var users = dbContext.Users.OrderByDescending(u => u.Score).ToList();
            if (users == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No quiz found for this place");
            }


            var QuizDto = users.Select(u => new UserDTO
            {
                Id =u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Score = u.Score,
                ProfileImage = u.ProfilePicture!=null? u.ProfilePicture.Url:null
            }).ToList();

            return Json(QuizDto);
        }

    
    }
}