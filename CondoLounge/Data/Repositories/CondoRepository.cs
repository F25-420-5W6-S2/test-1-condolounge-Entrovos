using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;

namespace CondoLounge.Data.Repositories
{
    public class CondoRepository : CondoLoungeGenericGenericRepository<Condo>, ICondoRepository
    {
        public CondoRepository(ApplicationDbContext db, ILogger<CondoRepository> logger) : base(db, logger) 
        {
        }

        public Condo GetOneById(int id)
        {
            try
            {
                _logger.LogInformation($"GetOneById was called for Id '{id}' . . .");

                var result = _context.Set<Condo>().Find(id);

                if (result == null)
                {
                    throw new Exception($"Condo of Id {id} not found.");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get: {ex}");
                return null;
            }
        }

        public void Add(Condo condo)
        {
            try
            {
                _logger.LogInformation("Add was called . . .");

                _context.Set<Condo>().Add(condo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add: {ex}");
            }
        }

        public void Update(Condo condo)
        {
            try
            {
                _logger.LogInformation($"Update was called . . .");

                _context.Set<Condo>().Update(condo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update: {ex}");
            }
        }

        public void Delete(Condo condo)
        {
            try
            {
                _logger.LogInformation($"Delete was called . . .");

                _context.Set<Condo>().Remove(condo);
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
    }
}
