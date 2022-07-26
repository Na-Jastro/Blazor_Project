using AutoMapper;
using BlazorAV.Core.Models;
using BlazorAV.Core.Repositories;
using BlazorAV.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;
        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ActionName("GetAllCompaniesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<CompanyDto>>> GetAllCompaniesAsync()
        {
            try
            {
                var companies = await this.companyRepository.GetAllCompaniesAsync();
                if (companies.Count == 0)
                    return NotFound("No Companies Available");

                var mappedcompanies = this.mapper.Map<List<CompanyDto>>(companies);
                return Ok(mappedcompanies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}")]
        [ActionName("GetCompanyByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CompanyDto>> GetCompanyByIdAsync(int id)
        {
            try
            {
                var company = await this.companyRepository.GetCompanyByIdAsync(id);
                if (company == null)
                    return NotFound("No Company Available");

                var mappedCompany = this.mapper.Map<CompanyDto>(company);
                return Ok(mappedCompany);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost()]
        [ActionName("CreateCompanyAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CompanyDto>> CreateCompanyAsync(CompanyDto companyDto)
        {
            try
            {
                Company company = new Company()
                {
                    CompanyId = companyDto.CompanyId,
                    CompanyName = companyDto.CompanyName,
                    IsActive = companyDto.IsActive,
                    Deleted = companyDto.Deleted,
                    LastDateModified = companyDto.LastDateModified,
                    ParentComapnyId = companyDto.ParentComapnyId,
                    UpdatedSystemUserId = companyDto.UpdatedSystemUserId,
                    PortalAccess = companyDto.PortalAccess,
                };

                await this.companyRepository.CreateCompanyAsync(company);

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut()]
        [ActionName("UpdateCompanyAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CompanyDto>> UpdateCompanyAsync(CompanyDto companyDto)
        {
            try
            {
                var company = await this.companyRepository.GetCompanyByIdAsync(companyDto.CompanyId);

                if (company == null)
                {
                    return NotFound("No Company Data");
                }

                company.CompanyName = companyDto.CompanyName;
                company.IsActive = companyDto.IsActive;
                company.Deleted = companyDto.Deleted;
                company.LastDateModified = companyDto.LastDateModified;
                company.ParentComapnyId = companyDto.ParentComapnyId;
                company.UpdatedSystemUserId = companyDto.UpdatedSystemUserId;
                company.PortalAccess = companyDto.PortalAccess;

                await this.companyRepository.UpdateCompanyAsync(company);

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ActionName("DeleteCompanyAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CompanyDto>>> DeleteCompanyAsync(int id)
        {
            try
            {
                var company = await this.companyRepository.GetCompanyByIdAsync(id);
                if (company is null)
                {
                    return NotFound();
                }
                await this.companyRepository.DeleteCompanyAsync(id);

                var companies = await this.companyRepository.GetAllCompaniesAsync();

                var mappedCompanies = this.mapper.Map<List<CompanyDto>>(companies);
                return Ok(mappedCompanies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
