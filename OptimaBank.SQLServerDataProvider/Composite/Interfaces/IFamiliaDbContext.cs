using OptimaBank.Domain;

namespace OptimaBank.SQLServerDataProvider.Composite.Interfaces
{
    public interface IFamiliaDbContext : IDbContext<Familia>
    {
        IList<Familia> GetAllFamilias();
    }
}
