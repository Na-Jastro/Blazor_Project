using BlazorAV.Models.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace BlazorAV.Client.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient httpClient;
        public List<CompanyDto> Companies { get; set; } = new List<CompanyDto>();
        public CompanyDto Company { get; set; } = new CompanyDto();
        public CompanyService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task GetCompaniesAsync()
        {
            try
            {
                var response = await this.httpClient.GetAsync($"api/Company");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        Companies = new List<CompanyDto>();
                    }
                    Companies = await response.Content.ReadFromJsonAsync<List<CompanyDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error {ex.Message}");
            }
        }

        public async Task GetCompanyByIdAsync(int id)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"api/company/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        Company = new CompanyDto();
                    }
                    Company = await response.Content.ReadFromJsonAsync<CompanyDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error {ex.Message}");
            }
        }

        public async Task CreateCompanyAsync(CompanyDto companyDto)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync<CompanyDto>($"api/company", companyDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        Company = new CompanyDto();
                    }
                    Company = await response.Content.ReadFromJsonAsync<CompanyDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error {ex.Message}");
            }
        }

        public async Task UpdateCompanyAsync(CompanyDto companyDto)
        {
            try
            {
                var response = await this.httpClient.PutAsJsonAsync<CompanyDto>("api/company", companyDto);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        Company = new CompanyDto();
                    }
                    Company = await response.Content.ReadFromJsonAsync<CompanyDto>();
                }
                else
                {
                    var messgae = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message - {messgae}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Server Error {ex.Message}");
            }
        }
        public async Task DeleteCompanyAsync(int id)
        {
            try
            {
                var response = await this.httpClient.DeleteAsync($"api/company/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        Companies = new List<CompanyDto>();
                    }
                    Companies = await response.Content.ReadFromJsonAsync<List<CompanyDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"http status code: {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error {ex.Message}");
            }
        }
    }
}
