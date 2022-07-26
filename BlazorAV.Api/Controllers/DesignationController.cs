using AutoMapper;
using BlazorAV.Core.Models;
using BlazorAV.Core.Repositories;
using BlazorAV.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationRepository designationRepository;
        private readonly IMapper mapper;
        public DesignationController(IDesignationRepository designationRepository,
            IMapper mapper)
        {
            this.designationRepository = designationRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ActionName("GetAllDesignations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<DesignationDto>>> GetAllDesignationsAsync()
        {
            try
            {
                var designations = await this.designationRepository.GetAllDesignationsAsync();
                if (designations.Count == 0)
                {
                    return NotFound("Designation data not available");
                }
                var mappedDesignations = this.mapper.Map<List<DesignationDto>>(designations);
                return Ok(mappedDesignations);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}")]
        [ActionName("GetDesignationByIdAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DesignationDto>> GetDesignationByIdAsync(int id)
        {
            try
            {
                var designation = await this.designationRepository.GetDesignationByIdAsync(id);
                if (designation == null)
                {
                    return NotFound("Designation data is not available");
                }
                var mappedDesignation = this.mapper.Map<DesignationDto>(designation);
                return Ok(mappedDesignation);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost()]
        [ActionName("CreateDesignationAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DesignationDto>> CreateDesignationAsync(DesignationDto designationDto)
        {
            try
            {
                Designation designation = new Designation
                {
                    CompanyId = designationDto.CompanyId,
                    Deleted = designationDto.Deleted,
                    DesignationDescription = designationDto.DesignationDescription,
                    LastDateModified = designationDto.LastDateModified,
                    UpdatedSystemUserId = designationDto.UpdatedSystemUserId
                };
                await this.designationRepository.CreateDesignationAsync(designation);

                return Ok(designation);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut()]
        [ActionName("UpdateDesignationAsyc")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DesignationDto>> UpdateDesignationAsyc(DesignationDto designationDto)
        {
            try
            {
                var designation = await this.designationRepository.GetDesignationByIdAsync(designationDto.DesignationId);
                if (designation == null)
                {
                    return NotFound("Designation data not availdable");
                }

                designation.DesignationId = designationDto.DesignationId;
                designation.Deleted = designationDto.Deleted;
                designation.DesignationDescription = designationDto.DesignationDescription;
                designation.LastDateModified = designationDto.LastDateModified;
                designation.UpdatedSystemUserId = designationDto.UpdatedSystemUserId;
                designation.CompanyId = designationDto.CompanyId;
                await this.designationRepository.UpdateDesignationAsync(designation);
                var mappedDesignation = this.mapper.Map<DesignationDto>(designation);

                return Ok(mappedDesignation);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [ActionName("DeleteDesignationAsync")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DesignationDto>>> DeleteDesignationAsync(int id)
        {
            try
            {
                var designation = await this.designationRepository.GetDesignationByIdAsync(id);
                if (designation == null)
                {
                    return NotFound("Designation data unvaialbe");
                }

                await this.designationRepository.DeleteDesignationAsync(id);

                var designations = await this.designationRepository.GetAllDesignationsAsync();

                var mappedDesignations = this.mapper.Map<List<DesignationDto>>(designations);
                return Ok(mappedDesignations);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
