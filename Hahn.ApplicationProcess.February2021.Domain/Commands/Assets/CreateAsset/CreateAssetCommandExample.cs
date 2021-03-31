using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Commands.Assets.CreateAsset
{
    public class CreateAssetCommandExample : IExamplesProvider<CreateAssetCommand>
    {
        public CreateAssetCommand GetExamples()
        {
            return new CreateAssetCommand()
            {
                AssetName = "Office Building",
                Broken = false,
                CountryOfDepartment = "Pakistan",
                Department = "MaintenanceStation",
                EMailAdressOfDepartment = "noreply@MaintenanceStation.com",
                PurchaseDate = DateTime.Now.AddMonths(-6),
            };
        }
    }
}
