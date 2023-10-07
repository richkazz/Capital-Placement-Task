using CapitalPlacementTask.Data;
using CapitalPlacementTask.IRepositories;
using CapitalPlacementTask.Models;

namespace CapitalPlacementTask.Repositories
{
    public class ProgramDetailRepository : RepositoryBase<ProgramDetail>, IProgramDetailRepository
    {
        public ProgramDetailRepository(CapitalPlacementTaskDbContext dbContext) : base(dbContext)
        {
        }
    }
}
