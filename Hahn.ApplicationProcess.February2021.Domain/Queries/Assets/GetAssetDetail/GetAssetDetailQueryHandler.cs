using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace Hahn.ApplicationProcess.February2021.Domain.Queries.Assets.GetAssetDetail
{
    public class GetAssetDetailQueryHandler : IRequestHandler<GetAssetDetailQuery, AssetDetailVM>
    {
        private readonly IHahnDbContext _context;
        private readonly IMapper _mapper;

        public GetAssetDetailQueryHandler(IHahnDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<AssetDetailVM> Handle(GetAssetDetailQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.Assets
                .ProjectTo<AssetDetailVM>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (vm == null)
                throw new NotFoundException(nameof(Asset), request.Id);


            return vm;
        }
    }
}
