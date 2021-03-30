using Hahn.ApplicationProcess.February2021.Domain.Entities;
using Hahn.ApplicationProcess.February2021.Domain.Entities.Common;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data
{
    public class HahnDbContext : DbContext, IHahnDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public HahnDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public HahnDbContext(DbContextOptions dbContextOptions, ICurrentUserService currentUserService) : base(dbContextOptions)
        {
            this._currentUserService = currentUserService;
        }

        public DbSet<Asset> Assets { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
