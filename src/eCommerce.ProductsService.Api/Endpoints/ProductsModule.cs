using Carter;
using eCommerce.ProductsService.Application.Abstractions.Messaging;
using eCommerce.ProductsService.Application.Commons.Bases;
using eCommerce.ProductsService.Application.Dtos.Products;
using eCommerce.ProductsService.Application.UseCases.Products.Commands.CreateProduct;
using eCommerce.ProductsService.Application.UseCases.Products.Commands.DeleteProduct;
using eCommerce.ProductsService.Application.UseCases.Products.Commands.UpdateProduct;
using eCommerce.ProductsService.Application.UseCases.Products.Queries.GetAllProducts;
using eCommerce.ProductsService.Application.UseCases.Products.Queries.GetProductById;

namespace eCommerce.ProductsService.Api.Endpoints;

//public class ProductsModule : ICarterModule
//{
//    public void AddRoutes(IEndpointRouteBuilder app)
//    {
//        var group = app.MapGroup("api/product")
//            .WithTags("Products");

//        group.MapGet("", GetAllProducts)
//            .WithName("GetAllProducts")
//            .Produces<BaseResponse<IEnumerable<GetAllProductsResponseDto>>>();

//        group.MapGet("{productID:guid}", GetProductById)
//            .WithName("GetProductById")
//            .Produces<BaseResponse<GetAllProductsResponseDto>>();

//        group.MapPost("", CreateProduct)
//            .WithName("CreateProduct")
//            .Produces<BaseResponse<bool>>();

//        group.MapPut("", UpdateProduct)
//            .WithName("UpdateProduct")
//            .Produces<BaseResponse<bool>>();

//        group.MapDelete("{productID:guid}", DeleteProduct)
//            .WithName("DeleteProduct")
//            .Produces<BaseResponse<bool>>();
//    }

//    private static async Task<IResult> GetAllProducts(
//        [AsParameters] GetAllProductsQuery query,
//        IDispatcher dispatcher,
//        CancellationToken cancellationToken)
//    {
//        var response = await dispatcher.Dispatch<GetAllProductsQuery,
//            IEnumerable<GetAllProductsResponseDto>>(query, cancellationToken);

//        return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
//    }

//    private static async Task<IResult> GetProductById(
//        Guid productID,
//        IDispatcher dispatcher,
//        CancellationToken cancellationToken)
//    {
//        var query = new GetProductByIdQuery { ProductID = productID };
//        var response = await dispatcher.Dispatch<GetProductByIdQuery,
//            GetAllProductsResponseDto>(query, cancellationToken);

//        return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
//    }

//    private static async Task<IResult> CreateProduct(
//        CreateProductCommand command,
//        IDispatcher dispatcher,
//        CancellationToken cancellationToken)
//    {
//        var response = await dispatcher
//            .Dispatch<CreateProductCommand, bool>(command, cancellationToken);

//        return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
//    }

//    private static async Task<IResult> UpdateProduct(
//        UpdateProductCommand command,
//        IDispatcher dispatcher,
//        CancellationToken cancellationToken)
//    {
//        var response = await dispatcher
//            .Dispatch<UpdateProductCommand, bool>(command, cancellationToken);

//        return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
//    }

//    private static async Task<IResult> DeleteProduct(
//        Guid productID,
//        IDispatcher dispatcher,
//        CancellationToken cancellationToken)
//    {
//        var response = await dispatcher
//            .Dispatch<DeleteProductCommand, bool>(
//                new DeleteProductCommand { ProductID = productID },
//                cancellationToken);

//        return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
//    }
//}
