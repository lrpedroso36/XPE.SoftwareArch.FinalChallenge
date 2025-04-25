namespace XPE.SoftwareArch.FinalChallenge.Api.Models.ProductsModels.Base;

public abstract class BaseProductViewModel
{
    public virtual Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
