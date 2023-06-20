using LeaveManagement.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<RegistrationResponse> Register (RegistrationRequest request);
        Task<AuthResponse> Login (AuthRequest request);
    }
}
