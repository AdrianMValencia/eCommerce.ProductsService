using eCommerce.ProductsService.Application.Abstractions.Messaging;
using eCommerce.ProductsService.Application.Commons.Bases;
using eCommerce.ProductsService.Application.Dtos.Products;
using eCommerce.ProductsService.Application.Interfaces.Services;
using Mapster;

namespace eCommerce.ProductsService.Application.UseCases.Products.Queries.GetProductById;

internal sealed class GetProductByIdHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetProductByIdQuery, GetAllProductsResponseDto>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<BaseResponse<GetAllProductsResponseDto>> Handle(
		GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<GetAllProductsResponseDto>();

		try
		{
			var product = await _unitOfWork.ProductRepository
				.GetProductByIdAsync(query.ProductID, cancellationToken);

			if (product is null)
			{
				response.IsSuccess = false;
				response.Message = "Product no encontrado.";
				return response;
			}

			response.IsSuccess = true;
			response.Data = product.Adapt<GetAllProductsResponseDto>();
			response.Message = "Operación realizada exitosamente.";
        }
		catch (Exception ex)
		{
			response.IsSuccess = false;
			response.Message = $"Ocurrió un error inesperado. {ex.Message}";
			return response;
		}

		return response;
    }
}
