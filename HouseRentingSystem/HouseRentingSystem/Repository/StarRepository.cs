using HouseRentingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentingSystem.Repository
{
    public class StarRepository : IStarRepository
    {
        private readonly HouseRentingSystemDBContext _context = null;
        public StarRepository(HouseRentingSystemDBContext context)
        {
            _context = context;
        }
        public bool IsFavourite(int adId, int userId)
        {
            var query = from c in _context.StarLists
                        where c.Adid == adId && c.Userid == userId
                        select c;
            var star = query.FirstOrDefault<StarLists>();
            return star==null;
        } 
        public async Task<int> AddStar(int userId, int adId)
        {
            var star = new StarLists()
            {
                Userid = userId,
                Adid = adId,
                Stardate = DateTime.UtcNow
            };
            await _context.StarLists.AddAsync(star);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> RemoveStar(int userId, int adId)
        {
            //use LINQ querry
            var query = from c in _context.StarLists
                        where c.Adid == adId && c.Userid == userId
                        select c;
            var remove = query.FirstOrDefault<StarLists>();
            _context.StarLists.Remove(remove);
            return await _context.SaveChangesAsync();
        }
    }
}
