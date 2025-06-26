using OptimaBank.Domain;

namespace OptimaBank.SQLServerDataProvider.Composite.Interfaces
{
    public interface IPatenteDbContext : IDbContext<Patente>
    {
        IList<Patente> GetAllPatentes();
    }
}
