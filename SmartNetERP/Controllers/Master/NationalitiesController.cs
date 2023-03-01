using Microsoft.AspNetCore.Mvc;
using SmartNetERP.IRepository.Master;
using SmartNetERP.RequestDTO.Master.Module;
using SmartNetERP.RequestDTO.Master.Nationality;
using SmartNetERP.ResponseDTO.Master.Module;
using SmartNetERP.ResponseDTO.Master.Nationality;

namespace SmartNetERP.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController : ControllerBase
    {
        private readonly INationalityRepository _INationalityRepository;
        public NationalitiesController(INationalityRepository nationalityRepository)
        {
            _INationalityRepository = nationalityRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetNationalities()
        {
            var nationalites = await _INationalityRepository.GetNationalitiesAsync();

            if(nationalites == null) return BadRequest(StatusCodes.Status500InternalServerError);

            List<NationalityResponseDTO> nationalityResponseDTOs = new List<NationalityResponseDTO>();

            nationalites.ToList().ForEach(nationality =>
            {
                nationalityResponseDTOs.Add(new NationalityResponseDTO { Id = nationality.Id, Name = nationality.Name,IsActive =nationality.IsActive });
            });

            return Ok(nationalityResponseDTOs);

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetNationality(Guid id)
        {
            var nationality = await _INationalityRepository.GetNationalityAsync(id);

            if (nationality == null) return BadRequest(StatusCodes.Status404NotFound);

            NationalityResponseDTO responseDTO = new NationalityResponseDTO()
            {
                Id = nationality.Id,
                Name = nationality.Name,
                IsActive = nationality.IsActive
            };
            return Ok(responseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddNationality(AddNationalityRequestDTO addNationalityRequestDTO) 
        {
            var nationality = await _INationalityRepository.AddNationalityAsync(addNationalityRequestDTO);

            if (nationality == null) return BadRequest(StatusCodes.Status500InternalServerError);

            ModuleResponseDTO responseDTO = new ModuleResponseDTO()
            {
                Id = nationality.Id,
                Name = nationality.Name,
                IsActive = nationality.IsActive,
                
            };
            return Ok(responseDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteModule(Guid id)
        {
            var nationality = await _INationalityRepository.GetNationalityAsync(id);

            if (nationality == null) return BadRequest(StatusCodes.Status400BadRequest);

            var deletedNationality = await _INationalityRepository.DeleteNationalityAsync(nationality);

            if (deletedNationality == null) return BadRequest(StatusCodes.Status500InternalServerError);


            ModuleResponseDTO responseDTO = new ModuleResponseDTO()
            {
                Id = deletedNationality.Id,
                Name = deletedNationality.Name,
                IsActive = deletedNationality.IsActive

            };
            return Ok(responseDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(Guid id, UpdateNationalityRequestDTO updateNationalityRequestDTO)
        {
            

            var existingNationality = await _INationalityRepository.GetNationalityAsync(id);
            if (existingNationality == null)
            {
                return NotFound();
            }

            var updatedNationality = await _INationalityRepository.UpdateNationalityAsync(existingNationality, updateNationalityRequestDTO);

            if (updatedNationality == null) BadRequest(StatusCodes.Status500InternalServerError);

            ModuleResponseDTO responseDTO = new ModuleResponseDTO()
            {
                Id = updatedNationality.Id,
                Name = updatedNationality.Name,
                IsActive = updatedNationality.IsActive      
            };

            return Ok(responseDTO);
        }
    }
}
