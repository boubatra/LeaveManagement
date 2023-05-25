﻿using LeaveManagement.Application.Contracts.Persistence;
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

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocation = await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);
        return leaveAllocation;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
    {
        var leaveAllocations = await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .ToListAsync();
        return leaveAllocations;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
    {
        var leaveAllocations = await _context.LeaveAllocations.Where(q => q.EmployeeId == userId)
            .Include(q => q.LeaveType)
            .ToListAsync();
        return leaveAllocations;
    }

    public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeid)
    {
        return await _context.LeaveAllocations
            .FirstOrDefaultAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeid);
    }
}
