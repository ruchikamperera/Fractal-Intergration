using Application.PickList.Commands.AddPickList;
using Application.PickListHelper.Commands.AddPickListHelper;
using Application.Products.Commands.AddProducts;
using Application.Products.Commands.GetProducts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionApi.Validators.Models.Product
{
  
    public class UpdatePickListHelperCommandValidator : AbstractValidator<AddPickListHelperCommand>
    {
        public UpdatePickListHelperCommandValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty();
            RuleFor(r => r.Status).NotNull();
           
        }
    }
}
