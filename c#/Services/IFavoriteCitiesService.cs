using Wether.Model;

namespace Wether.Services
{
    public interface IFavoriteCitiesService
    {
        Task<List<string>> GetFavoriteCitiesNamesAsync();

        Task<Status> AddCityAsync(string cityName);
    }
}