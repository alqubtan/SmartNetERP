using Microsoft.AspNetCore.Mvc;
using SmartNetERP.IRepository.Master;
using SmartNetERP.RequestDTO.Master.MarriageStatus;
using SmartNetERP.ResponseDTO.Master.MarriageStatus;

namespace SmartNetERP.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarriageStatusesController : ControllerBase
    {
        private readonly IMarriageStatusRepository _IMarriageStatusRepository;
        public MarriageStatusesController(IMarriageStatusRepository marriageStatusRepository)
        {
            _IMarriageStatusRepository = marriageStatusRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetMarriageStatuses()
        {
            var marriageStatuses = await _IMarriageStatusRepository.GetMarriageStatusesAsync();

            if (marriageStatuses == null) return BadRequest(StatusCodes.Status500InternalServerError);

            List<MarriageStatusResponseDTO> marriageStatusResponseDTOs = new List<MarriageStatusResponseDTO>();

            marriageStatuses.ToList().ForEach(module =>
            {
                marriageStatusResponseDTOs.Add(new MarriageStatusResponseDTO { Id = module.Id, Name = module.Name, IsActive = module.IsActive });
            });

            return Ok(marriageStatusResponseDTOs);

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetMarriageStatus(Guid id)
        {
            var marriageStatus = await _IMarriageStatusRepository.GetMarriageStatusAsync(id);

            if (marriageStatus == null) return BadRequest(StatusCodes.Status404NotFound);

            MarriageStatusResponseDTO responseDTO = new MarriageStatusResponseDTO()
            {
                Id = marriageStatus.Id,
                Name = marriageStatus.Name,
                IsActive = marriageStatus.IsActive
            };

            return Ok(responseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddMarriageStatus(AddMarriageStatusRequestDTO addMarriageStatusRequestDTO)
        {
            var marriageStatus = await _IMarriageStatusRepository.AddMarriageStatusAsync(addMarriageStatusRequestDTO);

            if (marriageStatus == null) return BadRequest(StatusCodes.Status500InternalServerError);

            MarriageStatusResponseDTO responseDTO = new MarriageStatusResponseDTO()
            {
                Id = marriageStatus.Id,
                Name = marriageStatus.Name,
                IsActive = marriageStatus.IsActive,

            };
            return Ok(responseDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMarriageStatus(Guid id)
        {
            var marriageStatus = await _IMarriageStatusRepository.GetMarriageStatusAsync(id);

            if (marriageStatus == null) return BadRequest(StatusCodes.Status400BadRequest);

            var deletedMarriageStatus = await _IMarriageStatusRepository.DeleteMarriageStatusAsync(marriageStatus);

            if (deletedMarriageStatus == null) return BadRequest(StatusCodes.Status500InternalServerError);


            MarriageStatusResponseDTO responseDTO = new MarriageStatusResponseDTO()
            {
                Id = deletedMarriageStatus.Id,
                Name = deletedMarriageStatus.Name,
                IsActive = deletedMarriageStatus.IsActive

            };
            return Ok(responseDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> MarriageStatus(Guid id, UpdateMarriageStatusRequestDTO updateMarriageStatusRequestDTO)
        {


            var existingMirrageStatus = await _IMarriageStatusRepository.GetMarriageStatusAsync(id);
            if (existingMirrageStatus == null)
            {
                return NotFound();
            }

            var updatedMirrageStatus = await _IMarriageStatusRepository.UpdateMarriageStatusAsync(existingMirrageStatus, updateMarriageStatusRequestDTO);

            if (updatedMirrageStatus == null) BadRequest(StatusCodes.Status500InternalServerError);

            MarriageStatusResponseDTO responseDTO = new MarriageStatusResponseDTO()
            {
                Id = updatedMirrageStatus.Id,
                Name = updatedMirrageStatus.Name,
                IsActive = updatedMirrageStatus.IsActive
            };

            return Ok(responseDTO);
        }
    }
}
