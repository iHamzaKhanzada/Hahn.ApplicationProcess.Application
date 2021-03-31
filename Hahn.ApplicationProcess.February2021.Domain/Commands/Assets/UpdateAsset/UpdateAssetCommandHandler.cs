using Hahn.ApplicationProcess.February2021.Domain.Entities;
using Hahn.ApplicationProcess.February2021.Domain.Exceptions;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Commands.Assets.UpdateAsset
{
    public class UpdateAssetCommandHandler : IRequestHandler<UpdateAssetCommand>
    {
        private readonly IHahnDbContext _context;

        public UpdateAssetCommandHandler(IHahnDbContext context)
        {
            this._context = context;
        }

        public async Task<Unit> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Assets.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Asset), request.Id);

            Enum.TryParse(request.Department, out Department selectedDepartment);

            entity.Department = selectedDepartment;
            entity.AssetName = request.AssetName;
            entity.Broken = request.Broken;
            entity.CountryOfDepartment = request.CountryOfDepartment;
            entity.EMailAdressOfDepartment = request.EMailAdressOfDepartment;
            entity.PurchaseDate = request.PurchaseDate;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
