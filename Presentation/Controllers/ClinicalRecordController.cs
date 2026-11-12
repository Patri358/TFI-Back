using Application.Interfaces;
using Application.Models.ClinicalRecord;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicalRecordController : ControllerBase
    {
        private readonly IClinicalRecordService _clinicalRecordService;
        public ClinicalRecordController(IClinicalRecordService clinicalRecordService)
        {
            _clinicalRecordService = clinicalRecordService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClinicalRecordDTO>>> Get()
        {
            var clinicalRecords = await _clinicalRecordService.GetAllAsync();
            return Ok(clinicalRecords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClinicalRecordDTO>> GetById([FromRoute] int id)
        {
            var clinicalRecord = await _clinicalRecordService.GetByIdAsync(id);
            if (clinicalRecord == null) 
                return NotFound("El registro clínico no existe");

            return Ok(clinicalRecord);
        }

        [HttpGet("pet/{petId}")]
        public async Task<ActionResult<List<ClinicalRecordDTO>>> GetByPetIdAsync([FromRoute] int petId)
        {
            var clinicalRecords = await _clinicalRecordService.GetByPetIdAsync(petId);
            return Ok(clinicalRecords);
        }

        [HttpGet("veterinary/{veterinaryId}")]
        public async Task<ActionResult<List<ClinicalRecordDTO>>> GetByVeterinaryIdAsync([FromRoute] int veterinaryId)
        {
            var clinicalRecords = await _clinicalRecordService.GetByVeterinaryIdAsync(veterinaryId);
            return Ok(clinicalRecords);
        }

        [HttpPost]
        public async Task<ActionResult<ClinicalRecordDTO>> Add([FromBody] CreateClinicalRecordDTO clinicalRecord)
        {
            var createdClinicalRecord = await _clinicalRecordService.AddAsync(clinicalRecord);
            if (createdClinicalRecord == null) return 
                    BadRequest("El registro clínico no pudo ser creado");

            return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new {id = createdClinicalRecord.Id},
            value: createdClinicalRecord
            );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClinicalRecordDTO>> Update([FromBody] ClinicalRecordDTO clinicalRecord, [FromRoute] int id)
        {
            if (clinicalRecord == null) 
                return BadRequest("Los datos del registro clínico están incompletos");
            if (clinicalRecord.Id != id) 
                return BadRequest("El Id de la ruta no coincide con el del registro clínico");

            var updateClinicalRecord = await _clinicalRecordService.UpdateAsync(clinicalRecord);
            if (updateClinicalRecord == null) 
                return NotFound($"El registro clínico con el Id:{clinicalRecord.Id} no pudo ser actualizado");

            return Ok(updateClinicalRecord);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClinicalRecordDTO>> Delete([FromRoute] int id)
        {
            var clinicalRecord = await _clinicalRecordService.DeleteAsync(id);
            if (clinicalRecord == null)
                return NotFound("El registro clínico no existe");
            
            return Ok(clinicalRecord);
        }
    }
}