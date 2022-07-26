using BlazorAV.Core.Models;
using BlazorAV.Core.Repositories;
using BlazorAV.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAV.Infrastructure.Repository
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly BlazorAVContext blazorAVContext;
        public DesignationRepository(BlazorAVContext blazorAVContext)
        {
            this.blazorAVContext = blazorAVContext;
        }
        public async Task CreateDesignationAsync(Designation designation)
        {
            await this.blazorAVContext.Set<Designation>().AddAsync(designation);
            await this.blazorAVContext.SaveChangesAsync();
        }
        public async Task DeleteDesignationAsync(int id)
        {
            var designation = await this.blazorAVContext.Set<Designation>()
                .Include(p => p.Company)
               .FirstOrDefaultAsync(p => p.DesignationId == id);
            if (designation != null)
            {
                this.blazorAVContext.Set<Designation>().Remove(designation);
                await this.blazorAVContext.SaveChangesAsync();
            }
        }
        public async Task<List<Designation>> GetAllDesignationsAsync()
        {
            return await this.blazorAVContext.Set<Designation>()
                .Include(p => p.Company).ToListAsync();
        }
        public async Task<Designation> GetDesignationByIdAsync(int designationId)
        {
            return await this.blazorAVContext.Set<Designation>()
                .Include(p => p.Company).
                FirstOrDefaultAsync(p => p.DesignationId == designationId);
        }
        public async Task UpdateDesignationAsync(Designation designation)
        {
            var desig = await this.blazorAVContext.Set<Designation>()
                .Include(p => p.Company)
                .FirstOrDefaultAsync(p => p.DesignationId == designation.DesignationId);
            if (desig != null)
            {
                this.blazorAVContext.Set<Designation>().Update(designation);
                await this.blazorAVContext.SaveChangesAsync();
            }
        }
    }
}
