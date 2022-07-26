using BlazorAV.Client.Services.CompanyService;
using BlazorAV.Client.Services.DesignationService;
using BlazorAV.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorAV.Client.Pages.DesignationPages
{
    public partial class Designations : ComponentBase
    {
        [Inject]
        public IDesignationService DesignationService { get; set; }
        [Inject]
        public ICompanyService CompanyService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await DesignationService.GetDesignationsAsync();
        }
        public void CreateDesignation()
        {
            NavigationManager.NavigateTo("designation");
        }
        public void UpdateDesignation(int id)
        {
            NavigationManager.NavigateTo($"designation/{id}");
        }
        public async Task DeleteDesignation(int id)
        {
            await DesignationService.DeleteDesignationAsync(id);
        }
    }
}
