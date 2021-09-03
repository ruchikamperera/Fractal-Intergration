using Application.PickListHelper.Commands.GetPickListHelper;
using Application.Products.Commands.GetProducts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionApi.Validators.Models.PickList
{
  
    public class GetPickListHelperCommandValidator : AbstractValidator<GetPickListHelperCommand>
    {
        public GetPickListHelperCommandValidator()
        {
            RuleFor(r => r.TableName).NotNull().NotEmpty();
           
        }
    }
}
