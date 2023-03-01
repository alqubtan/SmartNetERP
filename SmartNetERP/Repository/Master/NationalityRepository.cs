using Microsoft.EntityFrameworkCore;
using SmartNetERP.Data;
using SmartNetERP.IRepository.Master;
using SmartNetERP.Models.Master;
using SmartNetERP.RequestDTO.Master.Nationality;

namespace SmartNetERP.Repository.Master
{
    public class NationalityRepository : INationalityRepository
    {
        private ApplicationDbContext _context { get; set; }
        public NationalityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Nationality> AddNationalityAsync(AddNationalityRequestDTO addNationalityRequestDTO)
        {
            var nationality = new Nationality { Id = Guid.NewGuid(), Name = addNationalityRequestDTO.Name, IsActive = true };
            try
            {
                await _context.Nationalities.AddAsync(nationality);
                await _context.SaveChangesAsync();
                return nationality;
            }
            catch (Exception)
            {

                return null;
            };
        }

        public async Task<Nationality> DeleteNationalityAsync(Nationality nationality)
        {
            try
            {
                _context.Nationalities.Remove(nationality);
                await _context.SaveChangesAsync();
                return nationality;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IEnumerable<Nationality>> GetNationalitiesAsync()
        {
            try
            {
                var nationalities = await _context.Nationalities.ToListAsync();
                return nationalities;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<Nationality> GetNationalityAsync(Guid Id)
        {
            var nationality = await _context.Nationalities.FirstOrDefaultAsync(p => p.Id == Id);
            return nationality;
        }

        public async Task<Nationality> UpdateNationalityAsync(Nationality existedNationality, UpdateNationalityRequestDTO updateNationalityRequestDTO)
        {
            try
            {
                existedNationality.Name = updateNationalityRequestDTO.Name;
                existedNationality.IsActive = updateNationalityRequestDTO.IsActive;
                _context.Entry(existedNationality).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return existedNationality;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
