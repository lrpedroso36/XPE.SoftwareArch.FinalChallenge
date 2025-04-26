using Microsoft.AspNetCore.Mvc;
using XPE.SoftwareArch.FinalChallenge.Api.Models.ProductsModels;

namespace XPE.SoftwareArch.FinalChallenge.Api.Services.Absctractions
{
    public interface IProductService
    {
        Task<ActionResult> CountAsync(CancellationToken cancellation);
        Task<ActionResult> DeleteAsync(Guid id, CancellationToken cancellation);
        Task<ActionResult> GetAllAsync(CancellationToken cancellation);
        Task<ActionResult> GetByIdAsync(Guid id, CancellationToken cancellation);
        Task<ActionResult> GetByNameAsync(string name, CancellationToken cancellation);
        Task<ActionResult> PostAsync(ProductCreateViewModel viewModel, CancellationToken cancellation);
        Task<ActionResult> UpdateAsync(Guid id, ProductUpdateViewModel viewModel, CancellationToken cancellation);
    }
}