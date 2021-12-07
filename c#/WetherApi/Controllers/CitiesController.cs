
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wether.Model;
using Wether.Services;

namespace Wether.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IFavoriteCitiesService favoriteCitiesService;
        public CitiesController(IFavoriteCitiesService favoriteCitiesService)
        {
            this.favoriteCitiesService = favoriteCitiesService;
        }

        [HttpGet]
        [Route("GetFavoriteCitiesNames")]
        public async Task<IActionResult> GetFavoriteCitiesNames()
        {
            List<string> result = await favoriteCitiesService.GetFavoriteCitiesNamesAsync();
            return Ok(result);
        }
        //[HttpGet]
        //[Route("AddFavoriteCity/{cityName}")]
        //public async Task<IActionResult> AddFavoriteCity(string cityName)
        //{
        //    Status status =await favoriteCitiesService.AddCityAsync(cityName);
        //    return Ok((int)status);
        //}
        [HttpPost]
        [Route("AddFavoriteCity")]
        public async Task<IActionResult> AddFavoriteCity(FavoriteCities favoriteCities)
        {
            Status status = await favoriteCitiesService.AddCityAsync(favoriteCities.CityName);
            return Ok((int)status);
        }


    }
}
