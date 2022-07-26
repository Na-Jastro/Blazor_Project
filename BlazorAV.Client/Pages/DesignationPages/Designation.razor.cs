using BlazorAV.Client.Services.CompanyService;
using BlazorAV.Client.Services.DesignationService;
using BlazorAV.Models.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorAV.Client.Pages.DesignationPages
{
    public partial class Designation : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IDesignationService DesignationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ICompanyService CompanyService { get; set; }
        DesignationDto designationDto = new DesignationDto();
        string btnText = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            btnText = Id == 0 ? "Create new Designation" : "Update Designation";
            await CompanyService.GetCompaniesAsync();
        }
        protected override async Task OnParametersSetAsync()
        {
            if (Id == 0)
            {
            }
            else
            {
                await DesignationService.GetDesignationByIdAsync(Id);
                designationDto = DesignationService.Designation;
            }
        }
        async Task HandleSubmit()
        {
            if (Id == 0)
            {
                await DesignationService.CreateDesignationAsync(designationDto);
            }
            else
            {
                await DesignationService.UpdateDesignationAsync(designationDto);

            }
        }
        public async Task DeleteDesignationAsync(int id)
        {
            await DesignationService.DeleteDesignationAsync(id);
            NavigationManager.NavigateTo("designations");
        }
    }
}
