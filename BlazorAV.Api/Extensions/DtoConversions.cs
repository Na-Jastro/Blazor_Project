using BlazorAV.Core.Models;
using BlazorAV.Models.Dtos;

namespace BlazorAV.Api.Extensions
{
    public static class DtoConversions
    {
        public static List<CompanyDto> ConvertCompanyToCompanyDto(this List<Company> companies)
        {
            return (from company in companies
                    select new CompanyDto
                    {
                        CompanyId = company.CompanyId,
                        CompanyName = company.CompanyName,
                        Deleted = company.Deleted,
                        IsActive = company.IsActive,
                        LastDateModified = company.LastDateModified,
                        ParentComapnyId = company.ParentComapnyId,
                        PortalAccess = company.PortalAccess,
                        UpdatedSystemUserId = company.UpdatedSystemUserId,
                    }).ToList();
        }
    }
}
