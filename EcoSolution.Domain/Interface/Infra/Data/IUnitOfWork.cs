namespace EcoSolution.Domain.Interface.Infra.Data
{
    public interface IUnitOfWork
    {
        int Commit();

        void RollBack();

    }
}
