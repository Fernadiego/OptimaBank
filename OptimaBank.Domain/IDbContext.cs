using OptimaBank.Abstractions;

namespace OptimaBank.Domain
{
    public interface IDbContext<T> : IBASystem<T>
    {
    }
}
