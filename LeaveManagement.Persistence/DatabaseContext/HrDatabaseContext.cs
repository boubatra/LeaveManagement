using LeaveManagement.Application.Contracts.Identity;
using LeaveManagement.Domain;
using LeaveManagement.Domain.Common;
using LeaveManagement.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistence.DatabaseContext;

public class HrDatabaseContext : DbContext
{
    private readonly IUserService _userService;

    public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options, IUserService userService) : base(options)
    {
        this._userService = userService;
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //APPLY ALL THE CONFIGURATIONS IN THE ASSEMBLY
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);
        
        //APPLY CONFIGURATION ONE BY ONE
        //modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());

        //GO TO THE CONFIGURATION TO SEED THE TABLE
        //modelBuilder.Entity<LeaveType>().HasData(
        //    new LeaveType
        //    {
        //        Id = 1,
        //        Name = "Vacation",
        //        DefaultDays = 10,
        //        DateCreated = DateTime.Now,
        //        DateModified = DateTime.Now

        //    });
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State ==EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.DateModified = DateTime.Now;
            entry.Entity.ModifiedBy = _userService.UserId;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now;
                entry.Entity.CreatedBy = _userService.UserId;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

}
