namespace BlazorAV.Core.Models
{
    public class ProtectionType
    {
        public int ProtectionId { get; set; }
        public int CompanyId { get; set; }
        public string ProtectionDescription { get; set; }
        public int UpdatedSystemUserId { get; set; }
        public DateTime LastDateModified { get; set; }
        public bool Deleted { get; set; }
        public Company Company { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}