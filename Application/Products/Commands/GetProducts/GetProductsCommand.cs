using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.Commands.GetProducts
{
   public class GetProductsCommand : IRequest<List<Product>>
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string AssetType { get; set; }
        public string BusinessCriticality { get; set; }
        public string Vendor { get; set; }
        public string ConfigItem { get; set; }
        public string Comments { get; set; }
        public string Strategy { get; set; }
        public string Image { get; set; }
    }

    public class GetProductsCommandHandler : IRequestHandler<GetProductsCommand, List<Product>>
    {
      //  private readonly IFractolDbContext _context;
        public GetProductsCommandHandler(
            // IFractolDbContext context
            )
        {
          //  _context = context;
        }

        public async Task<List<Product>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
           List <Product > products = new List<Product>
            {
                new Product 
                {
                              Id= 1697,
                              Title= "Risk",
                              Status= "Active",
                              AssetType= "Application",
                              BusinessCriticality= "2 - Somewhat Critical",
                              Vendor= "Palisade LTD",
                              ConfigItem= null,
                              Comments= "1 pilot licence has been purchased with view to obtain more in 2021 if successful.",
                              Strategy= null,
                              Image=null,
               },
                new Product
                {
                              Id= 1698,
                              Title= "Risk",
                              Status= "Active",
                              AssetType= "Application",
                              BusinessCriticality= "2 - Somewhat Critical",
                              Vendor= "Palisade LTD",
                              ConfigItem= null,
                              Comments= "1 pilot licence has been purchased with view to obtain more in 2021 if successful.",
                              Strategy= null,
                              Image=null}
               
                };

            return products;
        }
    }
}
