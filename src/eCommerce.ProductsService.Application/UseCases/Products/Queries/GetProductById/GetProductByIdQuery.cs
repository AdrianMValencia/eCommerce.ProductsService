using eCommerce.ProductsService.Application.Abstractions.Messaging;
using eCommerce.ProductsService.Application.Dtos.Products;

namespace eCommerce.ProductsService.Application.UseCases.Products.Queries.GetProductById;

public sealed class GetProductByIdQuery : IQuery<GetAllProductsResponseDto>
{
    public Guid ProductID { get; set; }
}
