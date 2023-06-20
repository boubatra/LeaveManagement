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

namespace LeaveManagement.BlazorUI.Pages.LeaveRequests
{
    public partial class EmployeeIndex
    {
        [Inject] ILeaveRequestService leaveRequestService { get; set; }
        [Inject] IJSRuntime js { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public EmployeeLeaveRequestViewVM Model { get; set; } = new();
        public string Message { get; set; } = string.Empty;

        protected async override Task OnInitializedAsync()
        {

            Model = await leaveRequestService.GetUserLeaveRequests();
        }

        async Task CancelRequestAsync(int id)
        {
            var confirm = await js.InvokeAsync<bool>("confirm", "Do you want to cancel this request?");
            if (confirm)
            {
                var response = await leaveRequestService.CancelLeaveRequest(id);
                if (response.Success)
                {
                    StateHasChanged();
                }
                else
                {
                    Message = response.Message;
                }
            }
        }
    }
}