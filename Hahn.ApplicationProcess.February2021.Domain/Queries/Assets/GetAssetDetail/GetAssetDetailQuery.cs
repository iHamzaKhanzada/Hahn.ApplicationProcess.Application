using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Queries.Assets.GetAssetDetail
{
    public class GetAssetDetailQuery : IRequest<AssetDetailVM>
    {
        public int Id { get; set; }
    }
}
