using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeid, int period)
    {
        return await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId
        && q.LeaveTypeId == leaveTypeid
        && q.Period == period);
    }

    public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeid)
    {
        throw new NotImplementedException();
    }
}
