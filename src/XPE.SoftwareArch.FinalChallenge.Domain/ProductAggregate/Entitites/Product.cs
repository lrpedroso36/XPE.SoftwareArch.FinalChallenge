using XPE.SoftwareArch.FinalChallenge.Domain.Exceptions;

namespace XPE.SoftwareArch.FinalChallenge.Domain.ProductAggregate.Entitites;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }

    public void Create(string name, decimal price, int stockQuantity, string? description = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
        Description = description;

        Validate(this);
    }

    public void Update(Guid id, string name, decimal price, int stockQuantity, string? description = null)
    {
        Id = id;
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
        Description = description;

        Validate(this);
    }

    private static void Validate(Product product)
    {
        if (product.Id == default || product.Id == Guid.Empty)
        {
            throw new EntityValidationException("Product 'Id' is required.");
        }

        if (string.IsNullOrEmpty(product.Name))
        {
            throw new EntityValidationException("Product 'Name' is required.");
        }

        if (product.Name.Length < 5)
        {
            throw new EntityValidationException("Product 'Name' invalid, has need min lenght is 5.");
        }

        if (product.Name.Length > 100)
        {
            throw new EntityValidationException("Product 'Name' invalid, has need max lenght is 100.");
        }

        if (product.Price == default)
        {
            throw new EntityValidationException("Product 'Price' is required.");
        }

        if (product.StockQuantity == default)
        {
            throw new EntityValidationException("Product 'StockQuantity' is required.");
        }

        if (!string.IsNullOrEmpty(product.Description) && product.Description.Length > 100)
        {
            throw new EntityValidationException("Product 'Description' invalid, has need max lenght is 500.");
        }
    }
}
