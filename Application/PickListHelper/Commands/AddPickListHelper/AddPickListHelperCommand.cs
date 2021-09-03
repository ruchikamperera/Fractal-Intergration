using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using  Domain.Entities;
using Application.Common.Interfaces;

namespace Application.PickListHelper.Commands.AddPickListHelper
{
   public class AddPickListHelperCommand : IRequest<PicklistHelper>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }

    public class AddPickListHelperCommandHandler : IRequestHandler<AddPickListHelperCommand, PicklistHelper>
    {
        private readonly IFractolDbContext _context;
        public AddPickListHelperCommandHandler(IFractolDbContext context)
        {
            _context = context;
        }

        public async Task<PicklistHelper> Handle(AddPickListHelperCommand request, CancellationToken cancellationToken)
        {
            return new PicklistHelper
            {
                PickListHelperID = 10,
                TableName = "Pick List",
                HelperText = ""
            };               
        }
    }
}
