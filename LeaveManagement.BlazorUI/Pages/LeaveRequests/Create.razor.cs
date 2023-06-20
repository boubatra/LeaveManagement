using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using LeaveManagement.BlazorUI;
using LeaveManagement.BlazorUI.Pages.LeaveTypes;
using LeaveManagement.BlazorUI.Shared;
using LeaveManagement.BlazorUI.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.BlazorUI.Contracts;
using LeaveManagement.BlazorUI.Models.LeaveRequests;
using LeaveManagement.BlazorUI.Models.LeaveTypes;

namespace LeaveManagement.BlazorUI.Pages.LeaveRequests
{
    public partial class Create
    {
        [Inject] ILeaveTypeService leaveTypeService { get; set; }
        [Inject] ILeaveRequestService leaveRequestService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        LeaveRequestVM LeaveRequest { get; set; } = new LeaveRequestVM();
        List<LeaveTypeVM> leaveTypeVMs { get; set; } = new List<LeaveTypeVM>();

        protected override async Task OnInitializedAsync()
        {
            leaveTypeVMs = await leaveTypeService.GetLeaveTypes();
        }

        private async Task HandleValidSubmit()
        {
            // Perform form submission here
            await leaveRequestService.CreateLeaveRequest(LeaveRequest);
            NavigationManager.NavigateTo("/leaverequests/");
        }
    }
}