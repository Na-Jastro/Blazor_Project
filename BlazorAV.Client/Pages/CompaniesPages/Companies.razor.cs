using BlazorAV.Client.Services.CompanyService;
using BlazorAV.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorAV.Client.Pages.CompaniesPages
{
    public partial class Companies : ComponentBase
    {
        [Inject]
        public ICompanyService CompanyService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await CompanyService.GetCompaniesAsync();
        }
        public void CreateNewCompany()
        {
            NavigationManager.NavigateTo("company");
        }
        public void EditCompany(int id)
        {
            NavigationManager.NavigateTo($"company/{id}");
        }
        public async Task DeleteCompany(int id)
        {
            await CompanyService.DeleteCompanyAsync(id);
            NavigationManager.NavigateTo("companies");
        }
    }
}
