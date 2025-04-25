using XPE.SoftwareArch.FinalChallenge.Application.Exceptions;
using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Absctrations;
using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Extensions;
using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Inputs;
using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Outputs;
using XPE.SoftwareArch.FinalChallenge.Domain.ProductAggregate.Repositories;

namespace XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases;

public class ProductUseCase : IProductUseCase
{
    private readonly IProductRepository _repository;

    public ProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<long> CountAsync(CancellationToken cancellation)
    {
        var products = await _repository.GetAllAsync(cancellation);
        return products.Count();
    }

    public async Task CreateAsync(ProductInput input, CancellationToken cancellation)
    {
        var product = input.ToProductCreate();
        await _repository.CreateAsync(product, cancellation);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellation)
    {
        var product = await _repository.GetByIdAsync(id, cancellation);

        if (product == null)
        {
            throw new NotFoundException("Product not found, when deleted.");
        }

        await _repository.DeleteAsync(product, cancellation);
    }

    public async Task<IEnumerable<ProductOutput>> GetAllAsync(CancellationToken cancellation)
    {
        var products = await _repository.GetAllAsync(cancellation);
        return products == default ? [] : products.ToProductsOutput();
    }

    public async Task<ProductOutput> GetByIdAsync(Guid id, CancellationToken cancellation)
    {
        var product = await _repository.GetByIdAsync(id, cancellation);

        if (product == null)
        {
            throw new NotFoundException("Products not found, when get by id.");
        }

        return product.ToProductOutput();
    }

    public async Task<ProductOutput> GetByNameAsync(string name, CancellationToken cancellation)
    {
        var product = await _repository.GetByNameAsync(name, cancellation);

        if (product == null)
        {
            throw new NotFoundException("Products not found, when get by name.");
        }

        return product.ToProductOutput();
    }

    public async Task UpdateAsync(ProductInput input, CancellationToken cancellation)
    {
        var product = await _repository.GetByIdAsync(input.Id, cancellation);

        if (product == null)
        {
            throw new NotFoundException("Products not found, when get by id.");
        }

        input.ToProductUpdate(product);
        await _repository.UpdateAsync(product, cancellation);
    }
}
