using Application.PickList.Commands.AddPickList;
using Application.Products.Commands.AddProducts;
using Application.Products.Commands.GetProducts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionApi.Validators.Models.Product
{
  
    public class AddPickListCommandValidator : AbstractValidator<AddPickListCommand>
    {
        public AddPickListCommandValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty();
            RuleFor(r => r.Status).NotNull();
           
        }
    }
}
