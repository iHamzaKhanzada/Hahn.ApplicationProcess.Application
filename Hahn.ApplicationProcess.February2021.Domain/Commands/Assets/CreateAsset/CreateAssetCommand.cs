using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Commands.Assets.CreateAsset
{
    public class CreateAssetCommand : IRequest<int>
    {
        public string AssetName { get; set; }
        public string Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EMailAdressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Broken { get; set; }
    }

}
