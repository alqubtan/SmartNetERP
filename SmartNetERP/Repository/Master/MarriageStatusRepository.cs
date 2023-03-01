using Microsoft.EntityFrameworkCore;
using SmartNetERP.Data;
using SmartNetERP.IRepository.Master;
using SmartNetERP.Models.Master;
using SmartNetERP.RequestDTO.Master.MarriageStatus;

namespace SmartNetERP.Repository.Master
{
    public class MarriageStatusRepository : IMarriageStatusRepository
    {
        private ApplicationDbContext _context { get; set; }
        public MarriageStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<MarriageStatus> AddMarriageStatusAsync(AddMarriageStatusRequestDTO addMarriageStatusRequestDTO)
        {
            var marriageStatus = new MarriageStatus { Id = Guid.NewGuid(), Name = addMarriageStatusRequestDTO.Name, IsActive = true };
            try
            {
                await _context.MarriageStatuses.AddAsync(marriageStatus);
                await _context.SaveChangesAsync();
                return marriageStatus;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<MarriageStatus> DeleteMarriageStatusAsync(MarriageStatus marriageStatus)
        {
            try
            {
                _context.MarriageStatuses.Remove(marriageStatus);
                await _context.SaveChangesAsync();
                return marriageStatus;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<MarriageStatus> GetMarriageStatusAsync(Guid Id)
        {
            var marriageStatus = await _context.MarriageStatuses.FirstOrDefaultAsync(p => p.Id == Id);
            return marriageStatus;
        }

        public async Task<IEnumerable<MarriageStatus>> GetMarriageStatusesAsync()
        {
            try
            {
                var marriageStatuses = await _context.MarriageStatuses.ToListAsync();
                return marriageStatuses;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<MarriageStatus> UpdateMarriageStatusAsync(MarriageStatus existedMarriageStatus, UpdateMarriageStatusRequestDTO updateMarriageStatusRequestDTO)
        {
            try
            {
                existedMarriageStatus.Name = updateMarriageStatusRequestDTO.Name;
                existedMarriageStatus.IsActive = updateMarriageStatusRequestDTO.IsActive;
                _context.Entry(existedMarriageStatus).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return existedMarriageStatus;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
