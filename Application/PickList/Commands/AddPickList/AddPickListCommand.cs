using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using  Domain.Entities;
namespace Application.PickList.Commands.AddPickList
{
   public class AddPickListCommand : IRequest<Picklist>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }

    public class AddPickListCommandHandler : IRequestHandler<AddPickListCommand, Picklist>
    {
      //  private readonly IFractolDbContext _context;
        public AddPickListCommandHandler(
            // IFractolDbContext context
            )
        {
          //  _context = context;
        }

        public async Task<Picklist> Handle(AddPickListCommand request, CancellationToken cancellationToken)
        {


            return new Picklist
            {
                Id = 100,
                Name = "Pick List",
                Status = true


            };               
        }
    }
}
