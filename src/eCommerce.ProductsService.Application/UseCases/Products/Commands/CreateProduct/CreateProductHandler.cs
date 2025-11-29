using eCommerce.ProductsService.Application.Abstractions.Messaging;
using eCommerce.ProductsService.Application.Commons.Bases;
using eCommerce.ProductsService.Application.Interfaces.Services;
using eCommerce.ProductsService.Domain.Entities;
using Mapster;

namespace eCommerce.ProductsService.Application.UseCases.Products.Commands.CreateProduct;

internal sealed class CreateProductHandler(
    IUnitOfWork unitOfWork, 
    HandlerExecutor handlerExecutor) 
    : ICommandHandler<CreateProductCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HandlerExecutor _handlerExecutor = handlerExecutor;

    public async Task<BaseResponse<bool>> Handle(
        CreateProductCommand command, 
        CancellationToken cancellationToken)
    {
        return await _handlerExecutor.ExecuteAsync(
            command,
            () => CreateProductAsync(command, cancellationToken),
            cancellationToken
            );
    }

    private async Task<BaseResponse<bool>> CreateProductAsync(
        CreateProductCommand command, 
        CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var product = command.Adapt<Product>();
            await _unitOfWork.ProductRepository.AddProductAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;
            response.Message = "Se registró correctamente.";
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = $"An error occurred while creating the product {ex.Message}";
        }

        return response;
    }
}
