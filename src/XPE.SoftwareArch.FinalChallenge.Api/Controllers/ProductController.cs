using Microsoft.AspNetCore.Mvc;
using XPE.SoftwareArch.FinalChallenge.Api.Controllers.Helpers;
using XPE.SoftwareArch.FinalChallenge.Api.Models.Extensions;
using XPE.SoftwareArch.FinalChallenge.Api.Models.ProductsModels;
using XPE.SoftwareArch.FinalChallenge.Api.Models.SharedModels;
using XPE.SoftwareArch.FinalChallenge.Application.ProductUseCases.Absctrations;

namespace XPE.SoftwareArch.FinalChallenge.Api.Controllers;

[ApiController]
[Route("v1/api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductUseCase _useCase;

    public ProductController(IProductUseCase useCase)
    {
        _useCase = useCase;
    }

    /// <summary>
    /// Rota responsável por cadastrar um produto.
    /// </summary>
    /// <response code="201">Produto cadastrado com sucesso.</response>    
    /// <response code="409">Dados inválidos para cadastrar um produto.</response>
    /// <response code="500">Erro na aplicação ao cadastrar um produto.</response>
    /// <param name="viewModel">Dados do produto.</param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductCreateViewModel))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ResponseErrorViewModel))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorViewModel))]
    public async Task<ActionResult> PostAsync([FromBody] ProductCreateViewModel viewModel, CancellationToken cancellation)
    {
        return await ControllerHelper.ExecuteWithHandlingAsync(async () =>
        {
            var input = viewModel.ToInput();
            await _useCase.CreateAsync(input, cancellation);
            return Created("", viewModel);
        });
    }

    /// <summary>
    /// Rota responsável por atualizar um produto.
    /// </summary>
    /// <response code="200">Produto atualizado som sucesso.</response>
    /// <response code="404">Produto não encontrado.</response>
    /// <response code="409">Dados inválidos para atualizar um produto.</response>
    /// <response code="500">Erro na aplicação ao atualizar um produto.</response>
    /// <param name="id">Código do produto que será atualizado</param>
    /// <param name="viewModel">Dados do produto.</param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPut("id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductUpdateViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorViewModel))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ResponseErrorViewModel))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorViewModel))]
    public async Task<ActionResult> PutAsync([FromQuery] Guid id, [FromBody] ProductUpdateViewModel viewModel, CancellationToken cancellation)
    {
        return await ControllerHelper.ExecuteWithHandlingAsync(async () =>
        {
            viewModel.Id = id;
            var input = viewModel.ToInput();
            await _useCase.UpdateAsync(input, cancellation);
            return Ok(viewModel);
        });
    }

    /// <summary>
    /// Rota responsável por obter o produto pelo o código.
    /// </summary>
    /// <response code="200">Dados do produto.</response>
    /// <response code="404">Produto não encontrado.</response>
    /// <response code="500">Erro na aplicação ao obter um produto.</response>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorViewModel))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorViewModel))]
    public async Task<ActionResult> GetByIdAsync([FromQuery] Guid id, CancellationToken cancellation)
    {
        return await ControllerHelper.ExecuteWithHandlingAsync(async () =>
        {
            var output = await _useCase.GetByIdAsync(id, cancellation);
            return Ok(output.ToViewModel());
        });
    }

    /// <summary>
    /// Rota responsável por obter um produto pelo o nome.
    /// </summary>
    /// <response code="200">Dados do produto.</response>
    /// <response code="404">Produto não encontrado.</response>
    /// <response code="500">Erro na aplicação ao obter um produto.</response>
    /// <param name="name">Nome do produto</param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet("name")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductViewModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorViewModel))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorViewModel))]
    public async Task<ActionResult> GetByNameAsync([FromQuery] string name, CancellationToken cancellation)
    {
        return await ControllerHelper.ExecuteWithHandlingAsync(async () =>
        {
            var output = await _useCase.GetByNameAsync(name, cancellation);
            return Ok(output.ToViewModel());
        });
    }

    /// <summary>
    /// Rota responsável por obter todos os produtos.
    /// </summary>
    /// <response code="200">Dados dos produtos.</response>
    /// <response code="500">Erro na aplicação ao obter os produtos.</response>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductViewModel))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorViewModel))]
    public async Task<ActionResult> GetAllAsync(CancellationToken cancellation)
    {
        return await ControllerHelper.ExecuteWithHandlingAsync(async () =>
        {
            var outputs = await _useCase.GetAllAsync(cancellation);
            return Ok(outputs.ToViewModels());
        });
    }

    /// <summary>
    /// Rota responsável por excluir um produto pelo o código.
    /// </summary>
    /// <response code="204">Produto excluído com sucesso.</response>
    /// <response code="404">Produto não encontrado.</response>
    /// <response code="500">Erro na aplicação ao excluir um produto.</response>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpDelete("id")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorViewModel))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorViewModel))]
    public async Task<ActionResult> DeleteAsync([FromQuery] Guid id, CancellationToken cancellation)
    {
        return await ControllerHelper.ExecuteWithHandlingAsync(async () =>
        {
            await _useCase.DeleteAsync(id, cancellation);
            return NoContent();
        });
    }

    /// <summary>
    /// Rota responsável por obter q quantidade total dos produtos.
    /// </summary>
    /// <response code="200">Quantidade dos produtos.</response>
    /// <response code="500">Erro na aplicação ao obter a quantidade dos produtos.</response>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet("count")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductCountViewModel))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseErrorViewModel))]
    public async Task<ActionResult> CountAsync(CancellationToken cancellation)
    {
        return await ControllerHelper.ExecuteWithHandlingAsync(async () =>
        {
            var result = await _useCase.CountAsync(cancellation);
            return Ok(new ProductCountViewModel(result));
        });
    }
}
