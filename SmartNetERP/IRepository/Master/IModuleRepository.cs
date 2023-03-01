using SmartNetERP.Models.Master;
using SmartNetERP.RequestDTO.Master.Module;

namespace SmartNetERP.IRepository.Master
{
    public interface IModuleRepository
    {
        public Task<Module> AddModuleAsync(AddModuleRequestDTO addModuleRequestDTO);

        public Task<IEnumerable<Module>> GetModulesAsync();

        public Task<Module> GetModuleAsync(Guid Id);
        public Task<Module> DeleteModuleAsync(Module module);
        public Task<Module> UpdateModuleAsync(Module existedModule, UpdateModuleRequestDTO updateModuleRequestDTO);
    }
}
