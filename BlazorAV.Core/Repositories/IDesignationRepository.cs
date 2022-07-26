using BlazorAV.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAV.Core.Repositories
{
    public interface IDesignationRepository
    {
        Task<List<Designation>> GetAllDesignationsAsync();
        Task<Designation> GetDesignationByIdAsync(int designationId);
        Task CreateDesignationAsync(Designation designation);
        Task UpdateDesignationAsync(Designation designation);
        Task DeleteDesignationAsync(int id);
    }
}

