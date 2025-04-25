namespace XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Outputs;

public record ProductOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
