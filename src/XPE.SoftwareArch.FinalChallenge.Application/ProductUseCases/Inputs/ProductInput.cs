namespace XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Inputs;

public class ProductInput
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
