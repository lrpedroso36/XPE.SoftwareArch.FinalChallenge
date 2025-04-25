using XPE.SoftwareArch.FinalChallenge.Api.Models.ProductsModels;
using XPE.SoftwareArch.FinalChallenge.Api.Models.ProductsModels.Base;
using XPE.SoftwareArch.FinalChallenge.Api.Models.SharedModels;
using XPE.SoftwareArch.FinalChallenge.Application.Exceptions;
using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Inputs;
using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Outputs;
using XPE.SoftwareArch.FinalChallenge.Domain.Exceptions;

namespace XPE.SoftwareArch.FinalChallenge.Api.Models.Extensions;

public static class ViewModelExtensions
{
    public static ResponseErrorViewModel ToViewModel(this Exception exception)
        => GetViewModel(exception.Source, exception.Message);

    public static ResponseErrorViewModel ToViewModel(this NotFoundException exception)
        => GetViewModel(exception.Source, exception.Message);

    public static ResponseErrorViewModel ToViewModel(this DataBaseException exception)
        => GetViewModel(exception.Source, exception.Message);

    public static ResponseErrorViewModel ToViewModel(this EntityValidationException exception)
        => GetViewModel(exception.Source, exception.Message);

    private static ResponseErrorViewModel GetViewModel(string? source, string message)
        => new() { Source = source, Message = message };

    public static ProductInput ToInput(this BaseProductViewModel viewModel)
    {
        return new ProductInput
        {
            Id = viewModel.Id,
            Name = viewModel.Name,
            Price = viewModel.Price,
            StockQuantity = viewModel.StockQuantity,
            Description = viewModel.Description
        };
    }

    public static ProductViewModel ToViewModel(this ProductOutput output)
    {
        return new ProductViewModel
        {
            Id = output.Id,
            Name = output.Name,
            Price = output.Price,
            StockQuantity = output.StockQuantity,
            Description = output.Description
        };
    }

    public static IEnumerable<ProductViewModel> ToViewModels(this IEnumerable<ProductOutput> outputs)
    {
        foreach (var output in outputs)
        {
            yield return output.ToViewModel();
        }
    }
}
