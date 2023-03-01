using Microsoft.EntityFrameworkCore;
using SmartNetERP.Data;
using SmartNetERP.IRepository.Master;
using SmartNetERP.Models.Master;
using SmartNetERP.RequestDTO.Master.Privilege;

namespace SmartNetERP.Repository.Master
{
    public class PrivilegeRepository : IPrivilegeRepository
    {
        private ApplicationDbContext _context { get; set; }
        public PrivilegeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Privilege> AddPrivilegeAsync(AddPrivilegeRequestDTO addPrivilegeDTO)
        {
            var previliege = new Privilege { Id = Guid.NewGuid(), Name = addPrivilegeDTO.Name, ModuleId = addPrivilegeDTO.ModuleId, IsActive = true };
            try
            {
                await _context.Privileges.AddAsync(previliege);
                await _context.SaveChangesAsync();
                return previliege;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<Privilege>> GetPrivilegesAsync(Guid? ModuleId)
        {
            try
            {
                if (ModuleId == null)
                {

                    var privileges = await _context.Privileges.ToListAsync();
                    return privileges;
                }
                else
                {
                    var privileges = await _context.Privileges.Where(p => p.ModuleId == ModuleId).ToListAsync();
                    return privileges;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<Privilege> GetPrivilegeAsync(Guid Id)
        {

            var privilege = await _context.Privileges.FirstOrDefaultAsync(p => p.Id == Id);
            return privilege;


        }

        public async Task<Privilege> DeletePrivilegeAsync(Privilege privilege)
        {
            try
            {
                _context.Privileges.Remove(privilege);
                await _context.SaveChangesAsync();
                return privilege;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public async Task<Privilege> UpdatePrivilegeAsync(Privilege existedPrivilege, UpdatePrivilegeRequestDTO updatePrivilegeRequestDTO)
        {
            try
            {
                existedPrivilege.Name = updatePrivilegeRequestDTO.Name;
                existedPrivilege.ModuleId = updatePrivilegeRequestDTO.ModuleId;
                existedPrivilege.IsActive = updatePrivilegeRequestDTO.IsActive;
                _context.Entry(existedPrivilege).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return existedPrivilege;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
