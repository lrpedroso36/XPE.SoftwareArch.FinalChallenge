using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Inputs;
using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Outputs;

namespace XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Absctrations;

public interface IProductUseCase
{
    Task<IEnumerable<ProductOutput>> GetAllAsync(CancellationToken cancellation);
    Task<ProductOutput> GetByIdAsync(Guid id, CancellationToken cancellation);
    Task<ProductOutput> GetByNameAsync(string name, CancellationToken cancellation);
    Task CreateAsync(ProductInput input, CancellationToken cancellation);
    Task UpdateAsync(ProductInput input, CancellationToken cancellation);
    Task DeleteAsync(Guid id, CancellationToken cancellation);
    Task<long> CountAsync(CancellationToken cancellation);
}
