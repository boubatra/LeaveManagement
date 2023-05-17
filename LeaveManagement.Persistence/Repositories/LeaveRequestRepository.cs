using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Domain;
using LeaveManagement.Persistence.DatabaseContext;

namespace LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDatabaseContext context) : base(context)
    {
    }

    public Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
    {
        throw new NotImplementedException();
    }
}
