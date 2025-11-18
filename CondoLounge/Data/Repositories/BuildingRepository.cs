using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;

namespace CondoLounge.Data.Repositories
{
    public class BuildingRepository : CondoLoungeGenericGenericRepository<Building>, IBuildingRepository
    {
        public BuildingRepository(ApplicationDbContext db, ILogger<BuildingRepository> logger) : base(db, logger) 
        {
        }

        public Building GetOneById(int id)
        {
            try
            {
                _logger.LogInformation($"GetOneById was called for Id '{id}' . . .");

                var result = _context.Set<Building>().Find(id);

                if (result == null)
                {
                    throw new Exception($"Building of Id {id} not found.");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get: {ex}");
                return null;
            }
        }

        public void Add(Building building)
        {
            try
            {
                _logger.LogInformation("Add was called . . .");

                _context.Set<Building>().Add(building);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add: {ex}");
            }
        }

        public void Update(Building building)
        {
            try
            {
                _logger.LogInformation($"Update was called . . .");

                _context.Set<Building>().Update(building);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update: {ex}");
            }
        }

        public void Delete(Building building)
        {
            try
            {
                _logger.LogInformation($"Delete was called . . .");

                _context.Set<Building>().Remove(building);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to delete: {ex}");
            }
        }

        public bool SaveAll()
        {
            //Returns true when the number of state entries written to the database is > 0.
            return _context.SaveChanges() > 0;
        }

        //public IEnumerable<Condo> GetAllCondos()
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<ApplicationUser> GetAllUsers()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
