using CondoLounge.Data.Entities;

namespace CondoLounge.Data.Interfaces
{
    public interface IBuildingRepository: ICondoLoungeGenericRepository<Building>
    {
        IEnumerable<Condo> GetAllCondos(int buildingId);

        IEnumerable<ApplicationUser> GetAllUsers(int buildingId);
    }
}
