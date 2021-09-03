using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PickList.Commands.GetPickList
{
   public class GetPickListCommand : IRequest<List<Picklist>>
    {

        public string Type { get; set; }
    }

    public class GetPickListCommandHandler : IRequestHandler<GetPickListCommand, List<Picklist>>
    {
      //  private readonly IFractolDbContext _context;
        public GetPickListCommandHandler(
            // IFractolDbContext context
            )
        {
          //  _context = context;
        }

        public async Task<List<Picklist>> Handle(GetPickListCommand request, CancellationToken cancellationToken)
        {
            List<Picklist> Picklist = new List<Picklist>();

            for (int i = 1; i <=3; i++)
            {
                Picklist res = new Picklist();
                res.Id = i + 1;
                res.Name = request.Type + " " + i.ToString();
                res.Status = true;
                Picklist.Add(res);
            }
              

            return Picklist;
        }
    }
}
