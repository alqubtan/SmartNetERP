using SmartNetERP.Models.Master;
using SmartNetERP.RequestDTO.Master.Privilege;

namespace SmartNetERP.IRepository.Master
{
    public interface IPrivilegeRepository
    {
        public Task<Privilege> AddPrivilegeAsync(AddPrivilegeRequestDTO addPrivilegeRequestDTO);

        public Task<IEnumerable<Privilege>> GetPrivilegesAsync(Guid? ModuleId);

        public Task<Privilege> GetPrivilegeAsync(Guid Id);
        public Task<Privilege> DeletePrivilegeAsync(Privilege privilege);
        public Task<Privilege> UpdatePrivilegeAsync(Privilege existedPrivilege, UpdatePrivilegeRequestDTO updatePrivilegeRequestDTO);
    }
}
