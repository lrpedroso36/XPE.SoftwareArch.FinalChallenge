using XPE.SoftwareArch.FinalChallenge.Domain.ProductAggregate.Entitites;

namespace XPE.SoftwareArch.FinalChallenge.Domain.ProductAggregate.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellation);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellation);
    Task<Product?> GetByNameAsync(string name, CancellationToken cancellation);
    Task<Product> CreateAsync(Product product, CancellationToken cancellation);
    Task<Product> UpdateAsync(Product product, CancellationToken cancellation);
    Task<Product> DeleteAsync(Product product, CancellationToken cancellation);
}
