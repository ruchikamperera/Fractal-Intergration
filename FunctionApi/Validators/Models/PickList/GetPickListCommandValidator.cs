using Application.Products.Commands.GetProducts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionApi.Validators.Models.PickList
{
  
    public class GetPickListCommandValidator : AbstractValidator<GetProductsCommand>
    {
        public GetPickListCommandValidator()
        {
            RuleFor(r => r.Id).NotNull().NotEmpty();
           // RuleFor(r => r.Title).NotNull();
           
        }
    }
}
