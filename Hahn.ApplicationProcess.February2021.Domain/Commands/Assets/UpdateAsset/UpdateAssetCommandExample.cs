using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Commands.Assets.UpdateAsset
{
    public class UpdateAssetCommandExample : IExamplesProvider<UpdateAssetCommand>
    {
        public UpdateAssetCommand GetExamples()
        {
            return new UpdateAssetCommand()
            {
                Id = 1,
                AssetName = "Home Building",
                Broken = true,
                CountryOfDepartment = "India",
                Department = "HQ",
                EMailAdressOfDepartment = "noreply@headquarters.com",
                PurchaseDate = DateTime.Now.AddMonths(-8),
            };
        }
    }
}
