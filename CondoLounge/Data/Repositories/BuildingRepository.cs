using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;

namespace CondoLounge.Data.Repositories
{
    public class BuildingRepository : CondoLoungeGenericGenericRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(ApplicationDbContext db, ILogger<BuildingRepository> logger) : base(db, logger) 
        {
        }

        public IEnumerable<Condo> GetAllCondos(int buildingId)
        {
            return _context.Buildings
                .First(b => b.Id == buildingId)
                .Condos;
        }

        public IEnumerable<ApplicationUser> GetAllUsers(int buildingId)
        {
            IEnumerable<Condo> condos = _context.Buildings
                .First(b => b.Id == buildingId)
                .Condos;

            IEnumerable<ApplicationUser> users = [];
            
            foreach (Condo condo in condos)
            {
                foreach (ApplicationUser user in condo.Users)
                {
                    if (!users.Contains(user))
                    {
                        users.Append(user);
                    }
                }
            }

            return users;
        }
    }
}
