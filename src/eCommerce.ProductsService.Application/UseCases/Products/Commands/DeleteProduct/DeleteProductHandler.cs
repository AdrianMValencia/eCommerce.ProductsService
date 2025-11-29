using eCommerce.ProductsService.Application.Abstractions.Messaging;
using eCommerce.ProductsService.Application.Commons.Bases;
using eCommerce.ProductsService.Application.Interfaces.Services;

namespace eCommerce.ProductsService.Application.UseCases.Products.Commands.DeleteProduct;

internal sealed class DeleteProductHandler(IUnitOfWork unitOfWork) 
    : ICommandHandler<DeleteProductCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<BaseResponse<bool>> Handle(DeleteProductCommand command, 
        CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var existsProduct = await _unitOfWork.ProductRepository
                .GetProductByIdAsync(command.ProductID, cancellationToken);

            if (existsProduct is null)
            {
                response.IsSuccess = false;
                response.Message = "Product not found.";
                return response;
            }

            await _unitOfWork.ProductRepository
                .DeleteProductAsync(command.ProductID, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;
            response.Message = "Product deleted successfully.";
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = $"An error occurred while deleting the product {ex.Message}";
        }

        return response;
    }
}
