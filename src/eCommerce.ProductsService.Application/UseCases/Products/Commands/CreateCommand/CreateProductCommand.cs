using eCommerce.ProductsService.Application.Abstractions.Messaging;

namespace eCommerce.ProductsService.Application.UseCases.Products.Commands.CreateCommand;

public sealed class CreateProductCommand : ICommand<bool>
{
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public int StockQuantity { get; set; }
}
