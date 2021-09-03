using Application.Products.Commands.GetProducts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Validators.Models
{
  
    public class GetProductCommandValidator : AbstractValidator<GetProductsCommand>
    {
        public GetProductCommandValidator()
        {
            RuleFor(r => r.Id).NotNull().NotEmpty();
            RuleFor(r => r.Title).NotNull();
           
        }
    }
}
