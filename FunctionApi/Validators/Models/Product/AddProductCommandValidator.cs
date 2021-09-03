using Application.Products.Commands.AddProducts;
using Application.Products.Commands.GetProducts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionApi.Validators.Models.Product
{
  
    public class AddProductCommandValidator : AbstractValidator<AddProductsCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(r => r.Id).NotNull().NotEmpty();
            RuleFor(r => r.Title).NotNull();
           
        }
    }
}
