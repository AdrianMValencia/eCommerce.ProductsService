using FluentValidation;

namespace eCommerce.ProductsService.Application.UseCases.Products.Commands.CreateProduct;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("El nombre del producto es obligatorio.")
            .NotNull()
            .WithMessage("El nombre del producto no puede ser nulo.");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("La categoría del producto es obligatoria.")
            .NotNull()
            .WithMessage("La categoría del producto no puede ser nula.");

        RuleFor(x => x.UnitPrice)
            .GreaterThan(0)
            .WithMessage("El precio unitario debe ser mayor que cero.")
            .LessThanOrEqualTo(999999.99m)
            .WithMessage("El precio unitario no puede exceder 999,999.99.");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("El stock no puede ser negativo.")
            .LessThanOrEqualTo(100000)
            .WithMessage("El stock no puede exceder 100,000 unidades.");
    }
}
