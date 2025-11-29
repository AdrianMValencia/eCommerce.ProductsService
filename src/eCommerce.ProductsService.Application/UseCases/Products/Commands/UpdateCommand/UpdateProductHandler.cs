using eCommerce.ProductsService.Application.Abstractions.Messaging;
using eCommerce.ProductsService.Application.Commons.Bases;
using eCommerce.ProductsService.Application.Interfaces.Services;
using eCommerce.ProductsService.Domain.Entities;
using Mapster;

namespace eCommerce.ProductsService.Application.UseCases.Products.Commands.UpdateCommand;

internal class UpdateProductHandler(IUnitOfWork unitOfWork) : ICommandHandler<UpdateProductCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<BaseResponse<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {

        var response = new BaseResponse<bool>();

		try
		{
            var product = request.Adapt<Product>();
            product.ProductID = request.ProductID;

            _unitOfWork.ProductRepository.UpdateProduct(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;
            response.Message = "Actualizacion exitosa";

        }
		catch (Exception ex)
		{
			response.Message = ex.Message;
            response.Message = "Ocurrio un error al actualizar el producto.";
            response.Errors = new List<BaseError>
            {
                new BaseError
                {
                    PropertyName = "UpdateProductError",
                    ErrorMessage = ex.Message
                }
            };

        }

        return response;

    }
}
