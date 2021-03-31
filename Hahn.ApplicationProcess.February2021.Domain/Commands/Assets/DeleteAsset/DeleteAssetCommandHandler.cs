using Hahn.ApplicationProcess.February2021.Domain.Entities;
using Hahn.ApplicationProcess.February2021.Domain.Exceptions;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Commands.Assets.DeleteAsset
{
    public class DeleteAssetCommandHandler : IRequestHandler<DeleteAssetCommand>
    {
        private readonly IHahnDbContext _context;

        public DeleteAssetCommandHandler(IHahnDbContext context)
        {
            this._context = context;
        }

        public async Task<Unit> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Assets.FindAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Asset), request.Id);

            _context.Assets.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
