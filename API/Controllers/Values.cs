using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using API.DTOs;
using Core.Database;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        private readonly AppDbContext dbContext;
        public ValuesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("seedDb")]
        public bool SeedDb()
        {
            try
            {
                SeedData.SeedDatabase(dbContext);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpGet("stations")]
        public async Task<IActionResult> getStations()
        {
            return Json(dbContext.Stations.ToList());
        }

        [HttpGet("places")]
        public async Task<IActionResult> getPlaces([FromQuery(Name = "userId")] Guid userId)
        {
            var x = dbContext.Places.Include(p => p.Image).ToList();
           var placeList = x.Select(place => new PlaceDTO {
                Id = place.Id,
                MainImage = place.Image.Url,
                Name = place.Name,
                Description = place.LongDescription,
                ShortDescription = place.ShortDescription,
                Liked = dbContext.Favourits.Any(f => f.PlaceId == place.Id && f.UserId == userId),
                Rating = Calculate(dbContext.Reviews.Where(r => r.PlaceId == place.Id).ToList()),
             }).ToList();

            return Json(placeList);
         
        }

        private int Calculate(List<Review> reviews)
        {
            var total = 0;
            reviews.ForEach(r =>
            {
                total += (int)r.Rating;
            }
                );
            return reviews.Count!=0?(int)(total/reviews.Count):0;
        }

        [HttpGet("trains")]
        public async Task<IActionResult> GetTrains()
        {
            return Json(dbContext.Trains.ToList());
        }

        [HttpGet("stations/{startId}/{endId}")]
        public async Task<IActionResult> GetStations([FromRoute] Guid startId,[FromRoute] Guid endId)
        {
            if(startId == Guid.Empty || endId == Guid.Empty)
            {
                return BadRequest("Invalid Data");
            }
            try
            {
                var startStation = await dbContext.Stations.FirstOrDefaultAsync(s => s.Id == startId);
                var endStation = await dbContext.Stations.FirstOrDefaultAsync(s => s.Id == endId);

                var v = new {
                    Start = startStation,
                    End = endStation
                };
                return Json(v);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("trains/{id}")]
        public async Task<IActionResult> getTrain ([FromRoute] Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("Invalid Data");
            }
            try
            {
                var train = await dbContext.Trains.FirstOrDefaultAsync(t => t.Id == id);
                return Json(train);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
