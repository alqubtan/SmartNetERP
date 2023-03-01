using Microsoft.EntityFrameworkCore;
using SmartNetERP.Data;
using SmartNetERP.IRepository.Master;
using SmartNetERP.Models.Master;
using SmartNetERP.RequestDTO.Master.Module;

namespace SmartNetERP.Repository.Master
{
    public class ModuleRepository : IModuleRepository
    {
        private ApplicationDbContext _context { get; set; }
        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Module> AddModuleAsync(AddModuleRequestDTO addModuleRequestDTO)
        {
            var module = new Module { Id = Guid.NewGuid(), Name = addModuleRequestDTO.Name, IsActive=true };
            try
            {
                await _context.Modules.AddAsync(module);
                await _context.SaveChangesAsync();
                return module;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<Module>> GetModulesAsync()
        {
            try
            {
                var modules = await _context.Modules.ToListAsync();
                return modules;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<Module> GetModuleAsync(Guid Id)
        {
            var module = await _context.Modules.FirstOrDefaultAsync(p => p.Id == Id);
            return module;
        }

        public async Task<Module> DeleteModuleAsync(Module module)
        {
            try
            {
                _context.Modules.Remove(module);
                await _context.SaveChangesAsync();
                return module;

            }
            catch (Exception)
            {

                return null;
            }
            
        }

        public async Task<Module> UpdateModuleAsync(Module existedModule, UpdateModuleRequestDTO updateModuleRequestDTO)
        {
            try
            {
                existedModule.Name = updateModuleRequestDTO.Name;
                existedModule.IsActive = updateModuleRequestDTO.IsActive;
               _context.Entry(existedModule).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return existedModule;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
