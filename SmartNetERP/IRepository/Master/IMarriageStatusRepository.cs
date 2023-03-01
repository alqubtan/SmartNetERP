using SmartNetERP.Models.Master;
using SmartNetERP.RequestDTO.Master.MarriageStatus;
using SmartNetERP.RequestDTO.Master.Module;

namespace SmartNetERP.IRepository.Master
{
    public interface IMarriageStatusRepository
    {
        public Task<MarriageStatus> AddMarriageStatusAsync(AddMarriageStatusRequestDTO addMarriageStatusRequestDTO);

        public Task<IEnumerable<MarriageStatus>> GetMarriageStatusesAsync();

        public Task<MarriageStatus> GetMarriageStatusAsync(Guid Id);
        public Task<MarriageStatus> DeleteMarriageStatusAsync(MarriageStatus marriageStatus);
        public Task<MarriageStatus> UpdateMarriageStatusAsync(MarriageStatus existedMarriageStatus, UpdateMarriageStatusRequestDTO updateMarriageStatusRequestDTO);
    }
}
