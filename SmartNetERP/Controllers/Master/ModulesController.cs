using Microsoft.AspNetCore.Mvc;
using SmartNetERP.IRepository.Master;
using SmartNetERP.RequestDTO.Master.Module;
using SmartNetERP.ResponseDTO.Master.Module;
using SmartNetERP.ResponseDTO.Master.Privilege;

namespace SmartNetERP.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleRepository _IModuleRepository;
        public ModulesController(IModuleRepository modulesRepository)
        {
            _IModuleRepository = modulesRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetModules()
        {
            var modules = await _IModuleRepository.GetModulesAsync();

            if(modules == null) return BadRequest(StatusCodes.Status500InternalServerError);

            List<ModuleResponseDTO> moduleResponseDTOs = new List<ModuleResponseDTO>();

            modules.ToList().ForEach(module =>
            {
                moduleResponseDTOs.Add(new ModuleResponseDTO { Id = module.Id, Name = module.Name,IsActive =module.IsActive });
            });

            return Ok(moduleResponseDTOs);

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetModule(Guid id)
        {
            var module = await _IModuleRepository.GetModuleAsync(id);

            if (module == null) return BadRequest(StatusCodes.Status404NotFound);

            ModuleResponseDTO responseDTO = new ModuleResponseDTO()
            {
                Id = module.Id,
                Name = module.Name,
                IsActive = module.IsActive
            };
            
            return Ok(responseDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddModule(AddModuleRequestDTO addModuleRequestDTO) 
        {
            var module = await _IModuleRepository.AddModuleAsync(addModuleRequestDTO);

            if (module == null) return BadRequest(StatusCodes.Status500InternalServerError);

            ModuleResponseDTO responseDTO = new ModuleResponseDTO()
            {
                Id = module.Id,
                Name = module.Name,
                IsActive = module.IsActive,
                
            };
            return Ok(responseDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteModule(Guid id)
        {
            var module = await _IModuleRepository.GetModuleAsync(id);

            if (module == null) return BadRequest(StatusCodes.Status400BadRequest);

            var deletedModule = await _IModuleRepository.DeleteModuleAsync(module);

            if (deletedModule == null) return BadRequest(StatusCodes.Status500InternalServerError);


            ModuleResponseDTO responseDTO = new ModuleResponseDTO()
            {
                Id = deletedModule.Id,
                Name = deletedModule.Name,
                IsActive = deletedModule.IsActive
                
            };
            return Ok(responseDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(Guid id, UpdateModuleRequestDTO updateModuleRequestDTO)
        {
            

            var existingModule = await _IModuleRepository.GetModuleAsync(id);
            if (existingModule == null)
            {
                return NotFound();
            }

            var updatedModule = await _IModuleRepository.UpdateModuleAsync(existingModule, updateModuleRequestDTO);

            if (updatedModule == null) BadRequest(StatusCodes.Status500InternalServerError);

            ModuleResponseDTO responseDTO = new ModuleResponseDTO()
            {
                Id = updatedModule.Id,
                Name = updatedModule.Name,
                IsActive = updatedModule.IsActive      
            };

            return Ok(responseDTO);
        }
    }
}
