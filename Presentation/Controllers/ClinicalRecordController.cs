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
        public ActionResult<List<ClinicalRecordDTO>> Get()
        {
            var clinicalRecords = _clinicalRecordService.GetAll();
            return Ok(clinicalRecords);
        }

        [HttpGet("{id}")]
        public ActionResult<ClinicalRecordDTO> GetById([FromRoute] int id)
        {
            var clinicalRecord = _clinicalRecordService.GetById(id);
            if (clinicalRecord == null) return NotFound("El registro clínico no existe");

            return Ok(clinicalRecord);
        }

        [HttpPost]
        public ActionResult<ClinicalRecordDTO> Add([FromBody] CreateClinicalRecordDTO clinicalRecord)
        {
            var createdClinicalRecord = _clinicalRecordService.Add(clinicalRecord);
            if (createdClinicalRecord == null) return BadRequest("El registro clínico no pudo ser creado");

            return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new {id = createdClinicalRecord.Id},
            value: createdClinicalRecord
            );
        }

        [HttpPut("{id}")]
        public ActionResult<ClinicalRecordDTO> Update([FromBody] ClinicalRecordDTO clinicalRecord, [FromRoute] int id)
        {
            if (clinicalRecord == null) return BadRequest("Los datos del registro clínico están incompletos");
            if (clinicalRecord.Id != id) return BadRequest("El Id de la ruta no coincide con el del registro clínico");

            var updateClinicalRecord = _clinicalRecordService.Update(clinicalRecord);
            if (updateClinicalRecord == null) return NotFound($"El registro clínico con el Id:{clinicalRecord.Id} no pudo ser actualizado");

            return Ok(updateClinicalRecord);
        }

        [HttpDelete("{id}")]
        public ActionResult<ClinicalRecordDTO> Delete([FromRoute] int id)
        {
            var clinicalRecord = _clinicalRecordService.Delete(id);
            if (clinicalRecord == null) return NotFound("El registro clínico no existe");
            
            return Ok(clinicalRecord);
        }
    }
}