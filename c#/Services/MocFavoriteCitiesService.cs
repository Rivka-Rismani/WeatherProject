using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wether.Model;

namespace Wether.Services
{
    public class MocFavoriteCitiesService : IFavoriteCitiesService
    {
        private static List<FavoriteCities> favoriteCities;
        protected static List<FavoriteCities> FavoriteCities => LazyInitializer.EnsureInitialized(ref favoriteCities, FillData);

        private static List<FavoriteCities> FillData()
        {
            return new List<FavoriteCities>
            {
                new FavoriteCities{CityId=1,CityName="Ramat-Gan"},
                new FavoriteCities{CityId=2,CityName="Bnei-Brak"},
                new FavoriteCities{CityId=1,CityName="Raanana"},
                new FavoriteCities{CityId=2,CityName="Kfar Saba"},
                new FavoriteCities{CityId=1,CityName="Tel Aviv"},
                new FavoriteCities{CityId=2,CityName="Beer Sheva"},
            };
        }

        public async Task<Status> AddCityAsync(string cityName)
        {
            if (string.IsNullOrEmpty(cityName))
                return Status.NotValid;
            if (favoriteCities.FirstOrDefault(x => x.CityName == cityName) != null)
                return Status.Exists;
            await Task.Run(() => favoriteCities.Add(new FavoriteCities { CityName = cityName }));
            return Status.Success;
        }

        public async Task<List<string>> GetFavoriteCitiesNamesAsync()
        {
            var result = await Task.Run(() => FavoriteCities.Select(x => x.CityName).ToList());
            return result;
        }
    }
}
