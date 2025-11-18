using CondoLounge.Data.Interfaces;
using CondoLounge.Data;
using Microsoft.EntityFrameworkCore;
using CondoLounge.Data.Entities;

namespace CondoLounge.Data.Repositories
{
    public class CondoLoungeGenericGenericRepository<T> : ICondoLoungeGenericRepository<T> where T : class
    {
        internal readonly ILogger<CondoLoungeGenericGenericRepository<T>> _logger;
        internal readonly ApplicationDbContext _context;
        internal readonly DbSet<T> _dbSet;

        public CondoLoungeGenericGenericRepository(ApplicationDbContext db, ILogger<CondoLoungeGenericGenericRepository<T>> logger) 
        {
            _logger = logger;
            _context = db;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAll was called...");

                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get: {ex}");
                return null;
            }
        }

        public T GetOneById(object id)
        {
            try
            {
                _logger.LogInformation($"GetOneById was called for Id '{id}' . . .");

                var result = _context.Set<T>().Find(id);

                if (result == null)
                {
                    throw new Exception($"Item of Id {id} not found.");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get: {ex}");
                return null;
            }
        }

        public void Add(T entity)
        {
            try
            {
                _logger.LogInformation("Add was called . . .");

                _context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add: {ex}");
            }
        }

        public void Update(T entity)
        {
            try
            {
                _logger.LogInformation($"Update was called . . .");

                _context.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update: {ex}");
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _logger.LogInformation($"Delete was called . . .");

                _context.Set<T>().Remove(entity);
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
