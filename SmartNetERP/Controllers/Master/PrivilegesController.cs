using Microsoft.AspNetCore.Mvc;
using SmartNetERP.IRepository.Master;
using SmartNetERP.RequestDTO.Master.Privilege;
using SmartNetERP.ResponseDTO.Master.Privilege;

namespace SmartNetERP.Controllers.Master
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivilegesController : ControllerBase
    {
        private readonly IPrivilegeRepository _IPrivilegeRepository;
        public PrivilegesController(IPrivilegeRepository privilegeRepository)
        {
            _IPrivilegeRepository = privilegeRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetPrivileges(Guid? ModuleId = null)
        {
            var privileges = await _IPrivilegeRepository.GetPrivilegesAsync(ModuleId);

            if (privileges == null) return BadRequest(StatusCodes.Status500InternalServerError);

            List<PrivilegeResponseDTO> privilegeResponseDTOs = new List<PrivilegeResponseDTO>();

            privileges.ToList().ForEach(privilege =>
            {
                privilegeResponseDTOs.Add(new PrivilegeResponseDTO { Id = privilege.Id, Name = privilege.Name, ModuleId = privilege.ModuleId, IsActive = privilege.IsActive });
            });

            return Ok(privilegeResponseDTOs);

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPrivilege(Guid id)
        {
            var privilege = await _IPrivilegeRepository.GetPrivilegeAsync(id);

            if (privilege == null) return BadRequest(StatusCodes.Status404NotFound);

            var privilegeDTO = new PrivilegeResponseDTO { Id = privilege.Id, Name = privilege.Name,ModuleId=privilege.ModuleId, IsActive = privilege.IsActive };
            return Ok(privilegeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddPrivilege(AddPrivilegeRequestDTO addPrivilegeRequestDTO)
        {
            var privilege = await _IPrivilegeRepository.AddPrivilegeAsync(addPrivilegeRequestDTO);

            if (privilege == null) return BadRequest(StatusCodes.Status500InternalServerError);

            var privilegeDTO = new PrivilegeResponseDTO { Id = privilege.Id, Name = privilege.Name, IsActive = privilege.IsActive };
            return Ok(privilegeDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePrivilege(Guid id)
        {
            var privilege = await _IPrivilegeRepository.GetPrivilegeAsync(id);

            if (privilege == null) return BadRequest(StatusCodes.Status400BadRequest);

            var deletedPrivilege = await _IPrivilegeRepository.DeletePrivilegeAsync(privilege);

            if (deletedPrivilege == null) return BadRequest(StatusCodes.Status500InternalServerError);

            var privilegeDTO = new PrivilegeResponseDTO { Id = deletedPrivilege.Id, Name = deletedPrivilege.Name, IsActive = deletedPrivilege.IsActive };
            return Ok(privilegeDTO);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrivilege(Guid id, UpdatePrivilegeRequestDTO updatePrivilegeRequestDTO)
        {


            var existingPrivilege = await _IPrivilegeRepository.GetPrivilegeAsync(id);
            if (existingPrivilege == null)
            {
                return NotFound();
            }

            var updatedPrivilege = await _IPrivilegeRepository.UpdatePrivilegeAsync(existingPrivilege, updatePrivilegeRequestDTO);

            if (updatedPrivilege == null) BadRequest(StatusCodes.Status500InternalServerError);

            PrivilegeResponseDTO responseDTO = new PrivilegeResponseDTO()
            {
                Id = updatedPrivilege.Id,
                Name = updatedPrivilege.Name,
                ModuleId = updatedPrivilege.ModuleId,
                IsActive = updatedPrivilege.IsActive,

            };

            return Ok(responseDTO);
        }
    }
}
