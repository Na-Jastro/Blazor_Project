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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly BlazorAVContext blazorAVContext;
        public CompanyRepository(BlazorAVContext blazorAVContext)
        {
            this.blazorAVContext = blazorAVContext;
        }
        public async Task CreateCompanyAsync(Company company)
        {
            await this.blazorAVContext.Set<Company>().AddAsync(company);
            await this.blazorAVContext.SaveChangesAsync();
        }
        public async Task DeleteCompanyAsync(int id)
        {
            var company = await this.blazorAVContext.Set<Company>().FirstOrDefaultAsync(
                p => p.CompanyId == id);

            if (company is not null)
            {
                this.blazorAVContext.Set<Company>().Remove(company);
                await this.blazorAVContext.SaveChangesAsync();
            }
        }
        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            return await this.blazorAVContext.Set<Company>().ToListAsync();
        }
        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await this.blazorAVContext.Set<Company>()
                .FirstOrDefaultAsync(p => p.CompanyId == id);
        }
        public async Task UpdateCompanyAsync(Company company)
        {
            var com = await this.blazorAVContext.Set<Company>().FirstOrDefaultAsync(p => p.CompanyId == company.CompanyId);
            if (com is not null)
            {
                this.blazorAVContext.Set<Company>().Update(com);
                await this.blazorAVContext.SaveChangesAsync();
            }
        }
    }
}
