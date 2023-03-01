namespace SmartNetERP.RequestDTO.Master.Privilege
{
    public class UpdatePrivilegeRequestDTO
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid ModuleId { get; set; }
    }
}
