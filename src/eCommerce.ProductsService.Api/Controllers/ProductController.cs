using eCommerce.ProductsService.Application.Abstractions.Messaging;
using eCommerce.ProductsService.Application.Dtos.Products;
using eCommerce.ProductsService.Application.UseCases.Products.Commands.CreateProduct;
using eCommerce.ProductsService.Application.UseCases.Products.Commands.DeleteProduct;
using eCommerce.ProductsService.Application.UseCases.Products.Commands.UpdateProduct;
using eCommerce.ProductsService.Application.UseCases.Products.Queries.GetAllProducts;
using eCommerce.ProductsService.Application.UseCases.Products.Queries.GetProductById;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.ProductsService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IDispatcher dispatcher) : ControllerBase
{
    private readonly IDispatcher _dispatcher = dispatcher;

    [HttpGet]
    public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQuery query,
        CancellationToken cancellationToken)
    {
        var response = await _dispatcher.Dispatch<GetAllProductsQuery,
            IEnumerable<GetAllProductsResponseDto>>(query, cancellationToken);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet("{productID:guid}")]
    public async Task<IActionResult> GetProductById([FromRoute] Guid productID,
        CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery { ProductID = productID };
        var response = await _dispatcher.Dispatch<GetProductByIdQuery,
            GetAllProductsResponseDto>(query, cancellationToken);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var response = await _dispatcher
            .Dispatch<CreateProductCommand, bool>(command, cancellationToken);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        var response = await _dispatcher
            .Dispatch<UpdateProductCommand, bool>(command, cancellationToken);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{productID:guid}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid productID,
        CancellationToken cancellationToken)
    {
        var response = await _dispatcher
            .Dispatch<DeleteProductCommand, bool>(
                new DeleteProductCommand { ProductID = productID },
                cancellationToken);

        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }
}
