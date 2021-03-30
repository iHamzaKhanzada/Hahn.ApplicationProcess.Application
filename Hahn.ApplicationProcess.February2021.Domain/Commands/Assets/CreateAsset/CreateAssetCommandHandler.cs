using Hahn.ApplicationProcess.February2021.Domain.Entities;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Commands.Assets.CreateAsset
{
    public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, int>
    {
        private readonly IHahnDbContext _context;

        public CreateAssetCommandHandler(IHahnDbContext context)
        {
            this._context = context;
        }

        public async Task<int> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            Enum.TryParse(request.Department, out Department selectedDepartment);

            var entity = new Asset
            {
                Department = selectedDepartment,
                AssetName = request.AssetName,
                Broken = request.Broken,
                CountryOfDepartment = request.CountryOfDepartment,
                EMailAdressOfDepartment = request.EMailAdressOfDepartment,
                PurchaseDate = request.PurchaseDate                
            };

            await _context.Assets.AddAsync(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
