using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using  Domain.Entities;
namespace Application.PickList.Commands.UpdatePickList
{
   public class UpdatePickListCommand : IRequest<Picklist>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }

    public class AddPickListCommandHandler : IRequestHandler<UpdatePickListCommand, Picklist>
    {
      //  private readonly IFractolDbContext _context;
        public AddPickListCommandHandler(
            // IFractolDbContext context
            )
        {
          //  _context = context;
        }

        public async Task<Picklist> Handle(UpdatePickListCommand request, CancellationToken cancellationToken)
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
