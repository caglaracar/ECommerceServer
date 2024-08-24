using ECommerceServer.Application.ViewModels.Products;
using FluentValidation;

namespace ECommerceServer.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş girmeyiniz")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Lütfen Ürün Adını 5 ile 150 karakter arasında giriniz");

            RuleFor(p => p.Stock)
            .NotEmpty()
            .NotNull()
                .WithMessage("Lütfen stok bilgisini boş girmeyiniz")
            .Must(s => s >= 0)
                .WithMessage("Lütfen stok bilgisini 0 ve daha büyük  giriniz");


            RuleFor(p => p.Price)
           .NotEmpty()
           .NotNull()
               .WithMessage("Lütfen ürün adını boş girmeyiniz")
           .Must(p => p >= 0)
                .WithMessage("Lütfen fiyat bilgisini 0 ve daha büyük  giriniz");
        }
    }
}
