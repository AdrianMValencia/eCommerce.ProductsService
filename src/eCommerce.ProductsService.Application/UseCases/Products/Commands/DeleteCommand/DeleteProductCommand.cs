using eCommerce.ProductsService.Application.Abstractions.Messaging;

namespace eCommerce.ProductsService.Application.UseCases.Products.Commands.DeleteCommand;

public class DeleteProductCommand : ICommand<bool>
{
    public Guid ProductId { get; set; }
}
