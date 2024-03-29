﻿using System;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using Core.Database;
using Core.Entities;
using Core.Model;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly UserService userService;

        private readonly AppDbContext dbContext;

        public UserController (UserService userService, AppDbContext dbContext)
        {
            this.userService = userService;
            this.dbContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser ([FromBody] ApplicationUserModel userData)
        {
            if(userData == null)
            {
                return BadRequest();
            }

            try
            {
                var res = await userService.AddUser(userData);
                if(!res.Status)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized,res.Message);
                }

                return Json(OperationActionResult.Success(res.Value));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login ([FromBody] LoginModel loginData)
        {
            if(loginData == null)
            {
                return BadRequest();
            }

            try
            {
                var user = await dbContext.Users
                    .Include(u => u.ProfilePicture)
                    .FirstOrDefaultAsync(u => u.Email.Equals(loginData.Username));
                if(user == null)
                {
                    return BadRequest("InvalidUserNamePassword");
                }

                var res = userService.CheckPassword(user, loginData.Password);

                if(!res.Status)
                {
                    return BadRequest("InvalidUserNamePassword");
                }

                return Json(OperationActionResult.Success(new ApplicationUserDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    ProfileImage = user.ProfilePicture.Url
                }));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser ([FromRoute] Guid userId)
        {
            if(userId == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                var user = await dbContext.Users
                    .Include(u => u.ProfilePicture)
                    .FirstOrDefaultAsync(u => u.Id == userId);
                if(user == null)
                {
                    return Json(OperationActionResult.Failed<ApplicationUserDTO>("UserNotFound"));
                }

                return Json(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}/favourits")]
        public async Task<IActionResult> GetFavourits ([FromRoute] Guid userId)
        {
            if(userId == Guid.Empty)
            {
                return BadRequest("Invalid Data");
            }

            try
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if(user == null)
                {
                    return BadRequest("Invalid Data");
                }

                var favourits = dbContext.Favourits
                    .Include(f => f.Place).ThenInclude(p => p.Image)
                    .Where(f => f.UserId == userId).ToList();

                return Json(favourits);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}/visits")]
        public async Task<IActionResult> GetVisits([FromRoute] Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("Invalid Data");
            }

            try
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    return BadRequest("Invalid Data");
                }

                var visits = dbContext.Visits
                    .Include(f => f.Place).ThenInclude(p => p.Image)
                    .Where(f => f.UserId == userId).ToList();

                return Json(visits);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{userId}/redeem-points")]
        public async Task<IActionResult> RedeemPoints([FromRoute] Guid userId, [FromBody] PaymentDTO payment)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("Invalid Data");
            }

            try
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    return BadRequest("Invalid Data");
                }

                var score = user.Score - payment.Points;
                user.Score = score > 0 ? score: 0;

                dbContext.Update(user);
                dbContext.SaveChanges();

                return Json(true);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
