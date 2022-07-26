using BlazorAV.Models.Dtos;

namespace BlazorAV.Client.Services.CompanyService
{
    public interface ICompanyService
    {
        public List<CompanyDto> Companies { get; set; }
        public CompanyDto Company { get; set; }
        Task GetCompaniesAsync();
        Task GetCompanyByIdAsync(int id);
        Task CreateCompanyAsync(CompanyDto companyDto);
        Task UpdateCompanyAsync(CompanyDto companyDto);
        Task DeleteCompanyAsync(int id);
    }
}
