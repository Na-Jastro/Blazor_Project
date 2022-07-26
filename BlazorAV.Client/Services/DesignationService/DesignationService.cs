using BlazorAV.Models.Dtos;
using System.Net.Http.Json;

namespace BlazorAV.Client.Services.DesignationService
{
    public class DesignationService : IDesignationService
    {
        private readonly HttpClient httpClient;
        public List<DesignationDto> Designations { get; set; } = new List<DesignationDto>();
        public DesignationDto Designation { get; set; }
        public DesignationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task CreateDesignationAsync(DesignationDto designationDto)
        {
            try
            {
                var response = await this.httpClient.PostAsJsonAsync<DesignationDto>("api/designation", designationDto);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Designation = new DesignationDto();
                    }
                    Designation = await response.Content.ReadFromJsonAsync<DesignationDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} Message : {message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error {ex.Message}");
            }
        }

        public async Task DeleteDesignationAsync(int id)
        {
            try
            {
                var response = await this.httpClient.DeleteAsync($"api/designation/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Designations = new List<DesignationDto>();
                    }
                    Designations = await response.Content.ReadFromJsonAsync<List<DesignationDto>>();
                }
                else
                {
                    var message = response.Content.ReadAsStringAsync();
                    throw new Exception($"http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error {ex.Message}");
            }
        }

        public async Task GetDesignationByIdAsync(int id)
        {
            try
            {
                var response = await this.httpClient.GetAsync($"api/designation/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Designation = new DesignationDto();
                    }
                    Designation = await response.Content.ReadFromJsonAsync<DesignationDto>();
                }
                else
                {
                    var message = response.Content.ReadAsStringAsync();
                    throw new Exception($"http status code {response.StatusCode} Message {message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error {ex.Message}");
            }
        }

        public async Task GetDesignationsAsync()
        {
            try
            {
                var response = await this.httpClient.GetAsync("api/designation");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Designations = new List<DesignationDto>();
                    }
                    Designations = await response.Content.ReadFromJsonAsync<List<DesignationDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"http status code {response.StatusCode} Message : {message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error {ex.Message}");
            }
        }

        public async Task UpdateDesignationAsync(DesignationDto designationDto)
        {
            try
            {
                var response = await this.httpClient.PutAsJsonAsync("api/designation", designationDto);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Designation = new DesignationDto();
                    }
                    Designation = await response.Content.ReadFromJsonAsync<DesignationDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"http status code: {response.StatusCode} Message: {message}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Server error {ex.Message}");
            }
        }
    }
}
