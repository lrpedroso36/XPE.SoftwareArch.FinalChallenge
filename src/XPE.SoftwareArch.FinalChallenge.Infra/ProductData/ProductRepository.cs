using Microsoft.EntityFrameworkCore;
using XPE.SoftwareArch.FinalChallenge.Domain.Exceptions;
using XPE.SoftwareArch.FinalChallenge.Domain.ProductAggregate.Entitites;
using XPE.SoftwareArch.FinalChallenge.Domain.ProductAggregate.Repositories;

namespace XPE.SoftwareArch.FinalChallenge.Infra.ProductData;

public class ProductRepository : IProductRepository
{
    private readonly FinalChallengeDbContext _context;

    public ProductRepository(FinalChallengeDbContext context) 
        => _context = context;

    public async Task<Product> CreateAsync(Product product, CancellationToken cancellation)
    {
        try
        {
            _context.Products.Add(product);
            var result = await _context.SaveChangesAsync(cancellation);
            return product;
        }
        catch (Exception exception)
        {
            throw new DataBaseException(exception.Message);
        }
    }

    public async Task<Product> DeleteAsync(Product product, CancellationToken cancellation)
    {
        try
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
        catch (Exception exception)
        {
            throw new DataBaseException(exception.Message);
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellation)
    {
        try
        {
            var product = await _context.Products.ToListAsync();
            return product;
        }
        catch (Exception exception)
        {
            throw new DataBaseException(exception.Message);
        }
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellation)
    {
        try
        {
            var product = await _context.Products.FindAsync(id, cancellation);
            return product;
        }
        catch (Exception exception)
        {
            throw new DataBaseException(exception.Message);
        }
    }

    public async Task<Product?> GetByNameAsync(string name, CancellationToken cancellation)
    {
        try
        {
            var product = await _context.Products.Where(x => x.Name.StartsWith(name.ToLower()))
                .FirstOrDefaultAsync(cancellation);
            return product;
        }
        catch (Exception exception)
        {
            throw new DataBaseException(exception.Message);
        }
    }

    public async Task<Product> UpdateAsync(Product product, CancellationToken cancellation)
    {
        try
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
        catch (Exception exception)
        {
            throw new DataBaseException(exception.Message);
        }
    }
}
