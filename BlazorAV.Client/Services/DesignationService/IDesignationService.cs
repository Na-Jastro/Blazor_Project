using BlazorAV.Models.Dtos;

namespace BlazorAV.Client.Services.DesignationService
{
    public interface IDesignationService
    {
        public List<DesignationDto> Designations { get; set; }
        public DesignationDto Designation { get; set; }
        Task GetDesignationsAsync();
        Task GetDesignationByIdAsync(int id);
        Task CreateDesignationAsync(DesignationDto designationDto);
        Task UpdateDesignationAsync(DesignationDto designationDto);
        Task DeleteDesignationAsync(int id);
    }
}
