using SmartNetERP.Models.Master;
using SmartNetERP.RequestDTO.Master.Nationality;

namespace SmartNetERP.IRepository.Master
{
    public interface INationalityRepository
    {
        public Task<Nationality> AddNationalityAsync(AddNationalityRequestDTO addNationalityRequestDTO);

        public Task<IEnumerable<Nationality>> GetNationalitiesAsync();

        public Task<Nationality> GetNationalityAsync(Guid Id);
        public Task<Nationality> DeleteNationalityAsync(Nationality nationality);
        public Task<Nationality> UpdateNationalityAsync(Nationality existedNationality, UpdateNationalityRequestDTO updateNationalityRequestDTO);
    }
}
