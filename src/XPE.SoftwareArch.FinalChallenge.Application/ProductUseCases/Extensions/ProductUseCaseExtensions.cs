using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Inputs;
using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Outputs;
using XPE.SoftwareArch.FinalChallenge.Domain.ProductAggregate.Entitites;

namespace XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Extensions;

public static class ProductUseCaseExtensions
{
    public static Product ToProductCreate(this ProductInput input)
    {
        var product = new Product();
        product.Create(input.Name, input.Price, input.StockQuantity, input.Description);
        return product;
    }

    public static void ToProductUpdate(this ProductInput input, Product product)
        => product.Update(input.Id, input.Name, input.Price, input.StockQuantity, input.Description);

    public static ProductOutput ToProductOutput(this Product product)
        => new() { 
            Id = product.Id, 
            Name = product.Name, 
            Price = product.Price, 
            StockQuantity = product.StockQuantity, 
            Description = product.Description 
        };

    public static IEnumerable<ProductOutput> ToProductsOutput(this IEnumerable<Product> products)
    {
        foreach (var product in products)
        {
            yield return product.ToProductOutput();
        }
    }
}
