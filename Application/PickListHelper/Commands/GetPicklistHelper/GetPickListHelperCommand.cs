using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.PickListHelper.Commands.GetPickListHelper
{
   public class GetPickListHelperCommand : IRequest<PicklistHelper>
    {
        public string TableName { get; set; }
    }

    public class GetPickListHelperCommandHandler : IRequestHandler<GetPickListHelperCommand, PicklistHelper>
    {
        private readonly IFractolDbContext _context;
        public GetPickListHelperCommandHandler(IFractolDbContext context)
        {
            _context = context;
        }

        public async Task<PicklistHelper> Handle(GetPickListHelperCommand request, CancellationToken cancellationToken)
        {
           List <PicklistHelper> PicklistHelper = new List<PicklistHelper>
            {
                new PicklistHelper
                {
                              PickListHelperID= 1,  
                              TableName = "AssetType",
                              HelperText = "Indicate what is the current status of the asset: In development, Active, Sunset."
               },
                new PicklistHelper
                {
                              PickListHelperID= 2,
                              TableName = "BusinessCriticality",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 3,
                              TableName = "AutomatedTesting",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 4,
                              TableName = "BackupType",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 5,
                              TableName = "Category",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 7,
                              TableName = "CertificateType",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 8,
                              TableName = "ConfigurationItemLocation",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "CypherAlgorithmType",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "CypherLength",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "DataClassification",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "DataSecurityType",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "NetworkEncryption",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "PhysicalEntryControls",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "ProductHosting",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "RestorationTestCadence",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "ServerTypesUsed",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "Status",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "Strategy",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "SupportGroups",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                },
                new PicklistHelper
                {
                              PickListHelperID= 9,
                              TableName = "SupportType",
                              HelperText = "Indicates the business criticality of the asset from a support, outage, and business processes continuity perspective"
                }

                };

            return PicklistHelper.Where(a=>a.TableName==request.TableName).ToList().FirstOrDefault();
        }
    }
}
