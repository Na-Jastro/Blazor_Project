using BlazorAV.Client.Services.CompanyService;
using BlazorAV.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorAV.Client.Pages.CompaniesPages
{
    public partial class Company : ComponentBase
    {
        [Inject]
        public ICompanyService CompanyService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public int Id { get; set; }
        CompanyDto companyDto = new CompanyDto();
        public string btnText { get; set; } = string.Empty;
        protected override void OnInitialized()
        {
            btnText = Id == 0 ? "Add New Company" : "Edit Company";
        }
        protected override async Task OnParametersSetAsync()
        {
            if (Id == 0)
            {

            }
            else
            {
                await CompanyService.GetCompanyByIdAsync(Id);
                companyDto = CompanyService.Company;
            }
        }
        public async void HandleSubmit()
        {
            if (Id == 0)
            {
                await CompanyService.CreateCompanyAsync(companyDto);
                NavigationManager.NavigateTo("companies");
            }
            else
            {
                await CompanyService.UpdateCompanyAsync(companyDto);
                NavigationManager.NavigateTo("companies");
            }
        }
    }
}
