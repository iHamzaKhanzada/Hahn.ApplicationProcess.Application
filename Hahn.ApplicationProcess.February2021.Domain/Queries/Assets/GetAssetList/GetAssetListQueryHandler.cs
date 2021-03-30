using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Queries.Assets.GetAssetList
{
    public class GetAssetListQueryHandler : IRequestHandler<GetAssetListQuery, AssetListVM>
    {
        private readonly IHahnDbContext _context;
        private readonly IMapper _mapper;

        public GetAssetListQueryHandler(IHahnDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<AssetListVM> Handle(GetAssetListQuery request, CancellationToken cancellationToken)
        {
            var assets = await _context.Assets
                           .ProjectTo<AssetDTO>(_mapper.ConfigurationProvider)
                           .OrderBy(p => p.AssetName)
                           .ToListAsync(cancellationToken);

            var vm = new AssetListVM
            {
                Assets = assets,
                CreateEnabled = true // TODO: Set based on user permissions.
            };

            return vm;
        }
    }
}
