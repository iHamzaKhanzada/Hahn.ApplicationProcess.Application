using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Queries.Assets.GetAssetList
{
    public class AssetListVM
    {
        public IList<AssetDTO> Assets { get; set; }

        public bool CreateEnabled { get; set; }
    }
}
