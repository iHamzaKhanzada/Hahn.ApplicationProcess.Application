using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Queries.Assets.GetAssetList
{
    public class GetAssetListQuery : IRequest<AssetListVM>
    {
    }
}
