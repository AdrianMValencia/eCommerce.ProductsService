using eCommerce.ProductsService.Application.Abstractions.Messaging;
using eCommerce.ProductsService.Application.Commons.Bases;
using eCommerce.ProductsService.Application.Interfaces.Services;
using eCommerce.ProductsService.Domain.Entities;
using Mapster;

namespace eCommerce.ProductsService.Application.UseCases.Products.Commands.UpdateProduct;

internal sealed class UpdateProductHandler(
    IUnitOfWork unitOfWork,
    HandlerExecutor handlerExecutor)
    : ICommandHandler<UpdateProductCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly HandlerExecutor _handlerExecutor = handlerExecutor;

    public async Task<BaseResponse<bool>> Handle(UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        return await _handlerExecutor.ExecuteAsync(
            command,
            () => UpdateProductAsync(command, cancellationToken),
            cancellationToken
            );
    }

    private async Task<BaseResponse<bool>> UpdateProductAsync(UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var product = command.Adapt<Product>();
            _unitOfWork.ProductRepository.UpdateProduct(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;
            response.Message = "Product updated successfully.";
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = $"An error occurred while updating the product {ex.Message}";
        }

        return response;
    }
}
