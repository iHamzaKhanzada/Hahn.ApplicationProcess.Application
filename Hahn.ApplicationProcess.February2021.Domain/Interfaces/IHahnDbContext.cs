using Hahn.ApplicationProcess.February2021.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Interfaces
{
    public interface IHahnDbContext
    {
        DbSet<Asset> Assets { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
