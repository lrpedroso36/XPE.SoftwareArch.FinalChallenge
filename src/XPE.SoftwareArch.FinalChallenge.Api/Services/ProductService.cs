using Microsoft.AspNetCore.Mvc;
using XPE.SoftwareArch.FinalChallenge.Api.Helpers;
using XPE.SoftwareArch.FinalChallenge.Api.Models.Extensions;
using XPE.SoftwareArch.FinalChallenge.Api.Models.ProductsModels;
using XPE.SoftwareArch.FinalChallenge.Api.Services.Absctractions;
using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Absctrations;

namespace XPE.SoftwareArch.FinalChallenge.Api.Services;

public class ProductService : IProductService
{
    private readonly IProductUseCase _useCase;
    public ProductService(IProductUseCase useCase)
    {
        _useCase = useCase;
    }

    public async Task<ActionResult> PostAsync(ProductCreateViewModel viewModel, CancellationToken cancellation)
    {
        return await ActionResultHelper.ExecuteWithHandlingAsync(async () =>
        {
            var input = viewModel.ToInput();
            await _useCase.CreateAsync(input, cancellation);
            return new CreatedAtActionResult(null, null, null, viewModel);
        });
    }

    public async Task<ActionResult> UpdateAsync(Guid id, ProductUpdateViewModel viewModel, CancellationToken cancellation)
    {
        return await ActionResultHelper.ExecuteWithHandlingAsync(async () =>
        {
            viewModel.Id = id;
            var input = viewModel.ToInput();
            await _useCase.UpdateAsync(input, cancellation);
            return new OkObjectResult(viewModel);
        });
    }

    public async Task<ActionResult> GetByIdAsync(Guid id, CancellationToken cancellation)
    {
        return await ActionResultHelper.ExecuteWithHandlingAsync(async () =>
        {
            var output = await _useCase.GetByIdAsync(id, cancellation);
            return new OkObjectResult(output.ToViewModel());
        });
    }

    public async Task<ActionResult> GetByNameAsync(string name, CancellationToken cancellation)
    {
        return await ActionResultHelper.ExecuteWithHandlingAsync(async () =>
        {
            var output = await _useCase.GetByNameAsync(name, cancellation);
            return new OkObjectResult(output.ToViewModel());
        });
    }

    public async Task<ActionResult> GetAllAsync(CancellationToken cancellation)
    {
        return await ActionResultHelper.ExecuteWithHandlingAsync(async () =>
        {
            var outputs = await _useCase.GetAllAsync(cancellation);
            return new OkObjectResult(outputs.ToViewModels());
        });
    }

    public async Task<ActionResult> DeleteAsync(Guid id, CancellationToken cancellation)
    {
        return await ActionResultHelper.ExecuteWithHandlingAsync(async () =>
        {
            await _useCase.DeleteAsync(id, cancellation);
            return new NoContentResult();
        });
    }

    public async Task<ActionResult> CountAsync(CancellationToken cancellation)
    {
        return await ActionResultHelper.ExecuteWithHandlingAsync(async () =>
        {
            var result = await _useCase.CountAsync(cancellation);
            return new OkObjectResult(new ProductCountViewModel(result));
        });
    }
}
