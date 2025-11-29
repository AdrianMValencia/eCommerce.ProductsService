using eCommerce.ProductsService.Application.Abstractions.Messaging;
using eCommerce.ProductsService.Application.Commons.Bases;
using eCommerce.ProductsService.Application.Interfaces.Services;

namespace eCommerce.ProductsService.Application.UseCases.Products.Commands.DeleteCommand;

internal class DeleteProductHandler(IUnitOfWork unitOfWork) 
    : ICommandHandler<DeleteProductCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<BaseResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            
            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(request.ProductId, cancellationToken);
            if (product == null)
            {
                response.IsSuccess = false;
                response.Message = "Producto no encontrado";
                response.Data = false;
                return response;
            }

            await _unitOfWork.ProductRepository.DeleteProductAsync(request.ProductId, cancellationToken);
            
            response.IsSuccess = true;
            response.Message = "Producto eliminado";
            response.Data = true;
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = "ocurrio un error al eliminar un producto.";
            response.Errors = new List<BaseError> 
            { 
                new BaseError 
                { 
                    PropertyName = "DeleteProductError", 
                    ErrorMessage = ex.Message 
                } 
            };
        }

        return response;
    }
}
