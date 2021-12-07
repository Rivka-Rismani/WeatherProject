using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wether.Model;

namespace Wether.Services
{
    public class FavoriteCitiesService : IFavoriteCitiesService
    {
        private readonly WetherDBContext context;
        public FavoriteCitiesService(WetherDBContext context)
        {
            this.context = context;
        }

        public async Task<Status> AddCityAsync(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
                return Status.NotValid;
            if (context.FavoriteCities.FirstOrDefault(x => x.CityName == cityName) != null)
                return Status.Exists;
            await context.FavoriteCities.AddAsync(new FavoriteCities { CityName = cityName });
            await context.SaveChangesAsync();
            return Status.Success;
        }

        public async Task<List<string>> GetFavoriteCitiesNamesAsync()
        {
            return await context.FavoriteCities.Select(x => x.CityName).ToListAsync();
        }
    }
}
