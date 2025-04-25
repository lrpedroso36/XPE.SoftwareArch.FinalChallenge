using System.Text.Json.Serialization;
using XPE.SoftwareArch.FinalChallenge.Api.Models.ProductsModels.Base;

namespace XPE.SoftwareArch.FinalChallenge.Api.Models.ProductsModels;

public class ProductCreateViewModel : BaseProductViewModel
{
    [JsonIgnore]
    public override Guid Id { get; set; }
}
