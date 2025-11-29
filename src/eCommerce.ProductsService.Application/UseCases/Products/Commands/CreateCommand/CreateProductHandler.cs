using eCommerce.ProductsService.Application.Abstractions.Messaging;
using eCommerce.ProductsService.Application.Commons.Bases;
using eCommerce.ProductsService.Application.Interfaces.Services;
using eCommerce.ProductsService.Domain.Entities;
using Mapster;

namespace eCommerce.ProductsService.Application.UseCases.Products.Commands.CreateCommand;

internal class CreateProductHandler(IUnitOfWork unitOfWork) 
    : ICommandHandler<CreateProductCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<BaseResponse<bool>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try 
        {
            var product = request.Adapt<Product>();
            await _unitOfWork.ProductRepository.AddProductAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            response.IsSuccess = true;
            response.Message = "Producto creado exitosamente";
            

        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = "Ocurrio un error al crear el producto.";
            response.Errors = new List<BaseError> 
            { 
                new BaseError 
                { 
                    PropertyName = "CreateProductError", 
                    ErrorMessage = ex.Message 
                } 
            };
        }

        return response;
    }
}
