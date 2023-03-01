namespace SmartNetERP.ResponseDTO.Master.Privilege
{
    public class PrivilegeResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ModuleId { get; set; }
        public bool IsActive { get; set; }
    }
}
