using Microsoft.EntityFrameworkCore;
using XPE.SoftwareArch.FinalChallenge.Domain.ProductAggregate.Entitites;
using XPE.SoftwareArch.FinalChallenge.Infra.ProductData;

namespace XPE.SoftwareArch.FinalChallenge.Infra;

public class FinalChallengeDbContext : DbContext
{
    public FinalChallengeDbContext(DbContextOptions<FinalChallengeDbContext> options)
        : base(options) { }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }

}
