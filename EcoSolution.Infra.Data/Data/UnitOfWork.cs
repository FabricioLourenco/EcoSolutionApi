using EcoSolution.Domain.Interface.Infra.Data;
using EcoSolution.Infra.Data.Context;

namespace EcoSolution.Infra.Data.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcoSolutionContext _dbContext;


        public UnitOfWork(EcoSolutionContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void RollBack()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
