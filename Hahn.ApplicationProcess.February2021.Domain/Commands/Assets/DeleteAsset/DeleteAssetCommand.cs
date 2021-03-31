using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Commands.Assets.DeleteAsset
{
    public class DeleteAssetCommand : IRequest
    {
        public int Id { get; set; }
    }
}
